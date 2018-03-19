using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// test change 1.1

namespace Generic_List_O
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nGenerics excersises and stuff\n");

            Console.WriteLine("\nInstantiating new generic list (OList) of Skis . . . ");
            OList<Ski> testlist1 = new OList<Ski>();

            Console.WriteLine("\nAdding new Skis to the newly created list . . . ");
            for(int i = 0; i < testlist1.Length(); i++)
            {
                testlist1.Add(new Ski { ID = i + 1, Brand = "Brand" + (i+1).ToString(), Lengthcm = 176 + i });
            }

            Console.WriteLine("\nSkis in the list:");
            for(int i = 0; i < testlist1.Length(); i++)
            {
                Ski currentSki = testlist1.GetItem(ski => ski.ID == i + 1);
                Console.WriteLine("{0} length: {1} ", currentSki.Brand, currentSki.Lengthcm);
            }

            Console.ReadLine();

            Console.WriteLine("Deleting ski Brand2. . . ");
            testlist1.DeleteItem(ski => ski.Brand == "Brand2");

            Console.WriteLine("\nSkis in the list:");
            for (int i = 0; i < testlist1.Length()+1; i++)
            {
                Ski currentSki = testlist1.GetItem(ski => ski.ID == i + 1);
                if(currentSki != null) { 
                Console.WriteLine("{0} length: {1} ", currentSki.Brand, currentSki.Lengthcm);
                }
            }

            Console.WriteLine("\nList length = {0}", testlist1.Length());

            Console.WriteLine("\nTrying to get skis from the list with foreach statement . . . ");
            foreach(Ski s in testlist1)
            {
                Console.WriteLine(s.Brand + " " + s.Lengthcm);
            }

            Console.ReadLine();

        }

    }
}
