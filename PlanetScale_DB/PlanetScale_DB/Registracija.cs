using Npgsql;
using PlanetScale_DB.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanetScale_DB
{
    public partial class Registracija : Form
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private static string connectionString = "Host=" + Resources.Host + ":" + Resources.Port + ";Username=" + Resources.Username + ";Password=" + Resources.Password + ";Database=" + Resources.Database;
        private static List<string> Uporabniska_imena = new List<string>();
        private string ime,priimek,email,uporabnisko,geslo="";

        private void Obstojeci_uporabniki()
        {
            lbl_status_update.Text = "";
            var dataSource = NpgsqlDataSource.Create(connectionString);
            var cmd = dataSource.CreateCommand("SELECT Uporabnisko FROM Uporabniki");
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Uporabniska_imena.Add(reader.GetString(0));
            }
        }
        private void Pucaj_polja()
        {
            tbx_ime.Clear();
            tbx_priimek.Clear();
            tbx_email.Clear();
            tbx_uporabnisko.Clear();
            tbx_geslo.Clear();
        }

        private void tbx_uporabnisko_TextChanged(object sender, EventArgs e)
        {
            if (Uporabniska_imena.Contains(tbx_uporabnisko.Text))
                lbl_status_update.Text = "Uporabniško ime je že zasedeno.";
            else
                lbl_status_update.Text = "";
        }

        private void tbx_geslo_TextChanged(object sender, EventArgs e)
        {
            if (tbx_geslo.TextLength < 8)
                lbl_status_update.Text = "Geslo je prekratko! ("+tbx_geslo.TextLength+"/8)";
            else
                lbl_status_update.Text = "";
        }

        private void Registracija_Load(object sender, EventArgs e)
        {
            Obstojeci_uporabniki();
        }

        private void btn_registracija_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbx_ime.TextLength == 0)
                    throw new Exception("Polje Ime ni izpolnjeno!");
                if (tbx_priimek.TextLength == 0)
                    throw new Exception("Polje Priimek ni izpolnjeno!");
                if (tbx_email.TextLength == 0)
                    throw new Exception("Polje E-mail ni izpolnjeno!");
                if (tbx_uporabnisko.TextLength == 0)
                    throw new Exception("Polje Uporabniško ime ni izpolnjeno!");
                if (Uporabniska_imena.Contains(tbx_uporabnisko.Text))
                    throw new Exception("Uporabniško ime je že zasedeno!");
                if (tbx_geslo.TextLength == 0)
                    throw new Exception("Polje Geslo ni izpolnjeno!");
                if (tbx_geslo.TextLength < 8)
                {
                    tbx_geslo.Clear();
                    throw new Exception("Geslo je prekratko!");
                }

                ime = tbx_ime.Text;
                priimek = tbx_priimek.Text;
                email = tbx_email.Text;
                uporabnisko = tbx_uporabnisko.Text;
                //TODO: pošlji skozi funkcijo za šifriranje!!!
                geslo = tbx_geslo.Text;

                //dodaj uporabnika v DB
                var dataSource = NpgsqlDataSource.Create(connectionString);
                var cmd = dataSource.CreateCommand("INSERT INTO Uporabniki " +
                                                    "(Ime, Priimek, Email, Uporabnisko, Geslo) " +
                                                    "VALUES" +
                                                    "(@ime, @priimek, @email, @uporabnisko, @geslo);");
                //Dodajanje vseh vnosov v Query.
                NpgsqlParameter param_ime = new NpgsqlParameter("@ime", NpgsqlTypes.NpgsqlDbType.Varchar);
                param_ime.Value = ime;
                cmd.Parameters.Add(param_ime);

                NpgsqlParameter param_priimek = new NpgsqlParameter("@priimek", NpgsqlTypes.NpgsqlDbType.Varchar);
                param_priimek.Value = priimek;
                cmd.Parameters.Add(param_priimek);

                NpgsqlParameter param_email = new NpgsqlParameter("@email", NpgsqlTypes.NpgsqlDbType.Varchar);
                param_email.Value = email;
                cmd.Parameters.Add(param_email);

                NpgsqlParameter param_uporabnisko = new NpgsqlParameter("@uporabnisko", NpgsqlTypes.NpgsqlDbType.Varchar);
                param_uporabnisko.Value = uporabnisko;
                cmd.Parameters.Add(param_uporabnisko);

                NpgsqlParameter param_gelo = new NpgsqlParameter("@geslo", NpgsqlTypes.NpgsqlDbType.Varchar);
                param_gelo.Value = geslo;
                cmd.Parameters.Add(param_gelo);

                int spremenjene_vrstice = cmd.ExecuteNonQuery();
                if (spremenjene_vrstice > 0)
                {
                    //resetiraj vnose
                    Pucaj_polja();
                    Uporabniska_imena.Add(uporabnisko);
                    lbl_status_update.Text = "Registracija uspešna. Sedaj se lahko prijavite.";
                }
                else
                    throw new Exception("Registracija ni uspela.");
            }
            catch (Exception ex)
            {
                lbl_status_update.Text = ex.Message;
            }
        }
    }
}
