using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zadatak
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] niz = new int[] { 1, 4, 5, 3, 6, 1, 7, 4, 4, 1 };

            Zadatak(niz, 9);

        }

        public static void Binarni(int[] niz, int poz, int[] bin, int s, List<int[]> lista)
        {
            if (poz == niz.Length)
            {
                int suma = 0;

                int duzina = 0;

                for (int i = 0; i < bin.Length; i++)
                {
                    if (bin[i] == 1)
                    {
                        suma += niz[i];
                    }
                    duzina += bin[i];
                }

                if (suma == s)
                {
                    
                    int[] indeksi = new int[duzina];
                    int k = 0;

                    Console.Write("Binarni: ");
                    foreach (int item in bin)
                    {
                        Console.Write(item);
                    }
                    Console.Write(", ");

                    Console.Write("Kombinacija: ");
                    for (int i = 0; i < bin.Length; i++)
                    {
                        if (bin[i] == 1)
                        {
                            Console.Write(niz[i] + " ");
                            indeksi[k] = i;
                            k++;
                        }
                    }


                    Console.Write(", duzine: " + duzina);
                    Console.Write(", sa inteksima: ");
                    foreach (int item in indeksi)
                    {
                        Console.Write(" " + item);
                    }

                    lista.Add(indeksi);
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    bin[poz] = i;
                    Binarni(niz, poz + 1, bin, s, lista);
                }
            }
        }

        public static void Zadatak(int[] niz, int suma)
        {
            int[] bin = new int[niz.Length];
            for (int i = 0; i < niz.Length; i++)
            {
                bin[i] = 0;
            }

            List<int[]> listaIndeksa = new List<int[]>();

            Console.WriteLine("Sve kombinacije sa sumom {0}: ", suma);
            Binarni(niz, 0, bin, suma, listaIndeksa);

            int[] NizZaVracanje = new int[niz.Length];

            foreach (int[] item in listaIndeksa)
            {
                if (NizZaVracanje.Length > item.Length)
                {
                    NizZaVracanje = item;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Niz za vracanje je: ");
            foreach (int item in NizZaVracanje)
            {
                Console.Write(niz[item] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Indeksi: ");
            foreach (int item in NizZaVracanje)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
