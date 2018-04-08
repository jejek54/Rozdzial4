using System;
using System.IO;
using System.Collections.Generic;

namespace Rozdzial4
{
    static class Program
    {
        public delegate int Delegat(int a, int b);

        public static int Suma(int a, int b) => a + b;

        public static int Roznica(int a, int b) => a - b;

        public static int Wtyczka(int a, int b, Delegat delegat)
        {
            return a * b + delegat(a, b);
        }

        public delegate T Delegat_Generyczny<T>(T arg);   /* Delegaty generyczne<T>*/

        public static Double MetodaDlaDelegata<T>(T arg)
        {
            Console.WriteLine(arg.GetType().ToString() + " " + nameof(arg).ToString());
            return 0;
        }

        public static void Metoda<T>(T a, Delegat_Generyczny<T> t)
        {
            String tekst = a.ToString() + " " + t.GetType();
            Console.WriteLine(tekst);
        }



        public static int M(int g) => g + 4;

        public delegate T delegata<T>(T arg);  //Delegat ma tyle samo arg co metoda, Tworzymy delegat, nastepnie metode generyczna ktora 
                                               //przyjmie jako argument obiekt typu delegata

        public static void M_delegata<T>(T a, delegata<T> t)
        {
            a = t(a);

            Console.WriteLine(a.ToString());
        }

        public static int M2(int g) => g + 73;

        //Func<> Action<>

        public static string ZwrocStringZInt(int liczba)
        {
            string zwrotka = null;

            zwrotka = liczba.ToString() + "ROK";

            return zwrotka;
        }

        public static void BezZwrotki()
        {
            Console.WriteLine("BEZ ZWROTKI");
        }

        //EVENTY

        public static void PobieranieOK_informuj()
        {
            Console.WriteLine("\t Pobrano.");
        }
        [Obsolete("Użyj innej metody")]
        public static void PobieranieBlad_informuj()
        {
            Console.WriteLine("\t BŁĄD.");
        }

        static void pobi_ObsluStrum()
        {
            Console.WriteLine("\t Obsługuje teraz strumienie.");
        }

        static void Main(string[] args)
        {
            Delegat del = null;
            del = del + Suma;
            del = del + Roznica; //Multiemisja

            Console.WriteLine("Multiemisja " + del(5, 2));

            Console.WriteLine("Wtyczka - metoda jako parametr metody " + Wtyczka(5, 10, Suma));

            Delegat_Generyczny<double> del2 = MetodaDlaDelegata;
            del2(2.43);
            Console.WriteLine();
            Metoda(43, M);
            M_delegata(21, M2);

            //DELEGAT FUNC - gotowy delegat Func<przyjmowana, zwracana> zawsze zwraca!!

            Func<int, string> funcPointer = ZwrocStringZInt;
            Console.WriteLine(funcPointer(1442));

            //Delegat ACTION<>

            Action bezzwrotkiAction = BezZwrotki;   //Bezargumentowa metoda
            Console.WriteLine(bezzwrotkiAction);

            //Eventy

            PobieraczPlikow pobieracz = new PobieraczPlikow(3);
            pobieracz.PobieranieEventHandler += PobieranieOK_informuj;
            pobieracz.PobieranieBladEventHandler += PobieranieBlad_informuj;
            pobieracz.doPobrania = 3;


            String[] txt = null;
            Dictionary<String, int> dict = new Dictionary<string, int>();
            string line;



            using (StreamReader sr = new StreamReader("C:\\aaa\\plik.txt"))
            {
                txt = sr.ReadToEnd().Split();
            };


            for (int i = 0; i < txt.Length; i++)
            {
                if (!txt[i].Equals(' '))
                {
                    dict.TryAdd(txt[i], 1);

                }
            }



            foreach (var el in dict)
            {
                Console.WriteLine(el.Key + "\t" + el.Value);
                Console.WriteLine();

            }

           string piec = ProbnaMetoda();

            Console.ReadKey();
        }

        private static string ProbnaMetoda()
        {
            return "";
            throw new NotImplementedException();
        }
    }
}
