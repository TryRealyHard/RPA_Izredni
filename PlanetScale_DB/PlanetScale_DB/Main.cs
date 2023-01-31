using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Google.Protobuf.WellKnownTypes;
using static System.Net.Mime.MediaTypeNames;
using Org.BouncyCastle.Math;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Reflection;
using PlanetScale_DB.Properties;

namespace PlanetScale_DB
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private static string connectionString = "Host=" + Resources.Host + ":" + Resources.Port + ";Username=" + Resources.Username + ";Password=" + Resources.Password + ";Database=" + Resources.Database;
        private static string uporabnik, geslo = "";
        private List<Listki> Seznam_listkov = new List<Listki>();

        //public void Scurk_DB_povezava()
        //{
        //    //ščurk_db povezava, kjer sme na PC namestil certifikat za PostgreeSQL.
        //    //rabiš NuGet paket Npgsql !!!
        //    //@"postgresql://Listki_Application:0aPpeaRifrZ9BI-PjFxmXQ@testni-listki-5152.7tc.cockroachlabs.cloud:26257/defaultdb?sslmode=verify-full";
        //    var dataSource = NpgsqlDataSource.Create(connectionString);
        //    var cmd = dataSource.CreateCommand("SELECT * FROM Listki WHERE id_stars = @User");
            
        //    NpgsqlParameter param_user_id = new NpgsqlParameter("@user", NpgsqlTypes.NpgsqlDbType.Integer);
        //    param_user_id.Value = Trenutna_prijava.UID_DB;
        //    cmd.Parameters.Add(param_user_id);
            
        //    NpgsqlDataReader reader = cmd.ExecuteReader();

        //    lbl_status.Text = "";

        //    while (reader.Read())//ker poizvedba lahko vrne več vrstic
        //    {
        //        long indeks = reader.GetInt64(0);
        //        lbl_status.Text += Environment.NewLine + indeks.ToString();

        //        for (int i = 1; i < reader.FieldCount; i++)
        //        {
        //            //reader.getstring(Št_stolpca) - index se začne z 0 in vrne vrednost poizvedbe na stolpcu
        //            //reader.getStrings(Št_vrstice) - vrne array vrednosti vrstice (dolžina je enaka številu stolpcev poizvedbe -1)
        //            lbl_status.Text += Environment.NewLine + reader.GetString(i);
        //        }
        //    }
        //    reader.Close();

        //    cmd.Dispose();
        //    dataSource.Dispose();
        //}

        public void Dodaj_lstek()
        {
            try
            {
                string naslov = "Naslov 1";
                string vsebina = "Vsebina 1";

                var dataSource = NpgsqlDataSource.Create(connectionString);
                var cmd = dataSource.CreateCommand("INSERT INTO listki (" +
                                                    "id_stars, naslov, vsebina, datum_kreiranja) " +
                                                    "VALUES (" +
                                                    "@id_user, @naslov, @vsebina, @datum_kreacije" +
                                                    ");");

                NpgsqlParameter param_uporabnik = new NpgsqlParameter("@id_user", NpgsqlTypes.NpgsqlDbType.Bigint);
                param_uporabnik.Value = Trenutna_prijava.UID_DB;
                cmd.Parameters.Add(param_uporabnik);

                NpgsqlParameter param_naslov = new NpgsqlParameter("@naslov", NpgsqlTypes.NpgsqlDbType.Varchar);
                param_naslov.Value = naslov;
                cmd.Parameters.Add(param_naslov);

                NpgsqlParameter param_vsebina = new NpgsqlParameter("@vsebina", NpgsqlTypes.NpgsqlDbType.Text);
                param_vsebina.Value = vsebina;
                cmd.Parameters.Add(param_vsebina);

                NpgsqlParameter param_datum = new NpgsqlParameter("@datum_kreacije", NpgsqlTypes.NpgsqlDbType.Timestamp);
                param_datum.Value = DateTime.Now;
                cmd.Parameters.Add(param_datum);

                int spremenjene_vrstice = cmd.ExecuteNonQuery();
                if (spremenjene_vrstice > 0)
                    label1.Text = "Uspešno dodan vnos listka.";

                cmd.Dispose();
                dataSource.Dispose();

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                label1.Text = ex.Message;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Spremeni_GUI();
        }

        private void btn_prijava_Click(object sender, EventArgs e)
        {
            uporabnik = tbx_uporabnisko.Text;
            geslo = tbx_geslo.Text;

            var dataSource = NpgsqlDataSource.Create(connectionString);
            var cmd = dataSource.CreateCommand("SELECT * FROM uporabniki " +
                                                "WHERE uporabnisko LIKE @uporabnisko " +
                                                "AND geslo LIKE @geslo;");

            NpgsqlParameter param_uporabnik = new NpgsqlParameter("@uporabnisko", NpgsqlTypes.NpgsqlDbType.Varchar);
            param_uporabnik.Value = uporabnik;
            cmd.Parameters.Add(param_uporabnik);

            NpgsqlParameter param_geslo = new NpgsqlParameter("@geslo", NpgsqlTypes.NpgsqlDbType.Varchar);
            param_geslo.Value = geslo;
            cmd.Parameters.Add(param_geslo);

            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    long indeks = reader.GetInt64(0);
                    Trenutna_prijava.UID_DB = indeks;
                    Trenutna_prijava.Uporabnisko_ime = reader.GetString(4);
                    Trenutna_prijava.Je_prijavljen = true;
                    //TODO: Urihtaj boljš način za spreminjanje besedil v GUI-u.
                    Spremeni_GUI();
                }
                catch (Exception ex)
                {
                    lbl_status.Text = ex.Message;
                }
            }
            reader.Close();

            cmd.Dispose();
            dataSource.Dispose();
        }

        private void btn_registracija_Click(object sender, EventArgs e)
        {
            Registracija registracija = new Registracija();
            registracija.Show();
        }

        public void Spremeni_GUI()
        {
            if (Trenutna_prijava.Je_prijavljen)
            {
                lbl_strp_pozdrav.Text = "Pozdravljen" + Trenutna_prijava.Uporabnisko_ime + ".";
                lbl_status.Text = "";
                lbl_uporabnisko.Visible = false;
                lbl_geslo.Visible = false;
                tbx_uporabnisko.Text = "";
                tbx_uporabnisko.Visible = false;
                tbx_geslo.Text = "";
                tbx_geslo.Visible = false;
                lbl_status.Text = "";
                lbl_status.Visible = false;
                flow_panel_vertikal.FlowDirection = FlowDirection.TopDown;
                flow_panel_vertikal.Visible = true;
                flow_panel_vertikal.Dock = DockStyle.Fill;
                btn_registracija.Visible = false;
                btn_prijava.Visible = false;
            }
            else
            {
                lbl_strp_pozdrav.Text = "Uporabnik ni prijavljen.";
                lbl_status.Text = "";
                lbl_uporabnisko.Visible = true;
                lbl_geslo.Visible = true;
                tbx_uporabnisko.Text = "";
                tbx_uporabnisko.Visible = true;
                tbx_geslo.Text = "";
                tbx_geslo.Visible = true;
                lbl_status.Text = "";
                lbl_status.Visible = true;
                flow_panel_vertikal.Visible = false;
                btn_registracija.Visible = true;
                btn_prijava.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)//za namene testiranja vstavljanja vrednosti v DB.
        {
            //Dodaj_lstek();
            Posodobi_listke();
            Prikazi_listke();
        }
        public void Posodobi_listke()
        {
            var dataSource = NpgsqlDataSource.Create(connectionString);
            var cmd = dataSource.CreateCommand("SELECT * FROM listki " +
                                                "WHERE id_stars = @id_user;");

            NpgsqlParameter param_uporabnik = new NpgsqlParameter("@id_user", NpgsqlTypes.NpgsqlDbType.Bigint);
            param_uporabnik.Value = Trenutna_prijava.UID_DB;
            cmd.Parameters.Add(param_uporabnik);

            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    Listki listek = new Listki(reader.GetInt64(0), 
                        reader.GetInt64(1),reader.GetString(2),
                        reader.GetString(3),reader.GetDateTime(4));
                    
                    Seznam_listkov.Add(listek);
                }
                catch (Exception ex)
                {
                    lbl_status.Text = ex.Message;
                }
            }
            reader.Close();

            cmd.Dispose();
            dataSource.Dispose();
        }

        public void Prikazi_listke()
        {
            flow_panel_vertikal.Controls.Add(label2);

        }
    }
}
