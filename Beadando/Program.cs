using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Beadando
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = new List<int>();
            lista.Add(1); lista.Add(2); lista.Add(3); lista.Add(4); lista.Add(5);
            
            ConcurrentBag<int> bag = new ConcurrentBag<int>(lista);
            Console.WriteLine("Az alábbi számokat hozzáadtuk a listához:");
            Console.WriteLine(string.Join(",", bag.ToArray()));

            int osszesen = bag.Count;
            Console.WriteLine("Az elemek darabszáma összesen: ");
            Console.WriteLine(osszesen);

            Console.WriteLine("Az alábbi számokat adja vissza a yield return:");
            foreach (int i in SzuroYield(lista)) {
                 Console.WriteLine(i);
             }

            bag.Clear();
            Console.WriteLine("Az elemek törlésre kerültek.");

            bool ures = bag.IsEmpty;
            if (bag.Count == 0){
                Console.WriteLine("Ellenőrzés: az elemek törlése sikeres volt.");
                }
            else {
                Console.WriteLine("Ellenőrzés: az elemek törlése nem volt sikeres.");
            }

            bag.Add(10); bag.Add(20); bag.Add(30); bag.Add(40); bag.Add(50);
            bag.Add(11); bag.Add(22); bag.Add(33); bag.Add(44); bag.Add(55);
            bag.Add(01); bag.Add(02); bag.Add(03); bag.Add(04); bag.Add(05);
            bag.Add(12); bag.Add(13); bag.Add(14); bag.Add(15); bag.Add(16);
            Console.WriteLine("Az alábbi számokat újra hozzáadtuk a listához:");
            Console.WriteLine(string.Join(",", bag.ToArray()));

            bool kiemel = bag.TryPeek(out int result);
            Console.WriteLine("Ez a listában az első elem: ");
            Console.WriteLine(result);
            Console.WriteLine("Az alábbi számokat tartalmazza a lista TryPeek után:");
            Console.WriteLine(string.Join(",", bag.ToArray()));

            bool kivesz = bag.TryTake(out result);
            Console.WriteLine("Ez a listában az első elem, amit most kiveszek a listából: ");
            Console.WriteLine(result);
            Console.WriteLine("Az alábbi számokat tartalmazza a lista TryTake után:");
            Console.WriteLine(string.Join(",", bag.ToArray()));
        }
        public static IEnumerable<int> SzuroYield(List<int> lista)
        {
            foreach (int i in lista)
            {
                if (i > 3)
                {
                    yield return i;
                }
            }
        }
    }
}
