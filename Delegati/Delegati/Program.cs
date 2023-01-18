using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegati
{
    internal class Program
    {
        delegate string Spremeni(string s);
        static void Main(string[] args)
        {
            //Spremeni metoda = V_velike;
            Func<string, string> metoda = x => x.ToUpper(); //če imamo več kode kot samo eno vrstico jih damo v "{ }" !!!
            string ime = "Erik";
            Console.WriteLine(metoda(ime));

            Console.ReadLine();
        }
        //če se rabi da delegat vrača void se nuca
        //Action<int> vrača VOID in prejme parameter int !!!!!!!!!!!!!!

        //pri delegatu je ta metoda že napisana v delegatu. Se pravi je ne rabimo.
        private static string V_velike(string s)
        {
            return s.ToUpper();
        }
    }
}
