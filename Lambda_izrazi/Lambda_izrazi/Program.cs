using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_izrazi
{
    internal class Program
    {
        //delegat (enako kot enum - nov podatkovni tip)
        delegate bool Funkcija_za_nize(string s); // neka metoda je "Funkcija_za_nize", če ima točno tako glavo!!!
        static void Main(string[] args)
        {
            string[] imena = { "David", "Blaž", "Ivan", "Neža", "Alen", "Saša", "Erik", "Simon", "Mitja", "Kristjan" };

            //List<string> naS = new List<string>();
            ////Vsa Imena Na "S"
            ////običen način
            //foreach(var ime in imena)
            //    if (ime.StartsWith("S"))
            //    {
            //        naS.Add(ime);
            //        Console.WriteLine(ime.ToString());
            //    }

            List<string> a = Delaj_operacijo_nad_nizi(imena, Zacne_S);
            //List<string> b = Delaj_operacijo_nad_nizi(imena, Konca_n);

            //dej ka naredimo Konca_n anonimno
            Funkcija_za_nize anonimna = delegate (string s) { return s.EndsWith("n"); }; //dvojno podpičje ker je od prvotne vrstice.
            //List<string> b = Delaj_operacijo_nad_nizi(imena, anonimna);//ni še ker se kliče "anonimna"
            //List<string> b = Delaj_operacijo_nad_nizi(imena, delegate (string s) { return s.EndsWith("n"); });//zdaj pa je res anonimna!
            //dej ka naredimo z Lambda izrazom:
            List<string> b = Delaj_operacijo_nad_nizi(imena, s=> s.EndsWith("n"));//lambda izraz "Parameter" na levi "=>" znak in "return-ena vrednost" na desni.

            //Že napisani delegati
            //Func<int> vrne int ne prejme parametrov
            //Func<string, int> vrne string, prejme 1 parameter tipa int


            foreach (string x in b)
                Console.WriteLine(x);

            Console.ReadLine();
        }
        //oldscool:
        //static List<string> Delaj_operacijo_nad_nizi(string[] moj_niz, Funkcija_za_nize moja_funkcija)
        //z delegatom:
        static List<string> Delaj_operacijo_nad_nizi(string[] moj_niz, Func<string, bool> moja_funkcija)
        {
            List<string> rezultat = new List<string>();
            foreach(var x in moj_niz)
            {
                if (moja_funkcija(x))
                    rezultat.Add(x);
            }
            return rezultat;
        }
        //poljubne metode katere soupadajo z delegatom.
        static bool Zacne_S(string a)
        {
            return a.StartsWith("S");
        }
        static bool Zacne_A(string a)
        {
            return a.StartsWith("A");
        }
        static bool Konca_n(string a)
        {
            return a.EndsWith("n");
        }
    }
}
