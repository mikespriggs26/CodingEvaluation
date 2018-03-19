using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerwynCodingEval
{
    class Program
    {
        static void Main(string[] args)
        {
            

            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            List<string> listC = new List<string>();
            List<string> listD = new List<string>();

            using (var reader = new StreamReader("test.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split(',');
                    listA.Add(values[0]);
                    listB.Add(values[1]);
                    listC.Add(values[2]);
                    listD.Add(values[3]);





                }
            }
            int totalValues = listA.Count + listB.Count + listC.Count + listD.Count;

            Console.WriteLine("The total number of values is: " + totalValues);

            //checking for duplicate GUIDs
            var duplicates = new List<string>();
            var hashset = new HashSet<string>();
            foreach (var item in listA)
            {
                if (!hashset.Add(item))
                {
                    duplicates.Add(item);
                    Console.WriteLine(item + "is a duplicate GUID.");

                }
            }
            //calculates the average of all Val3 entries
            int listDLength = 0;
            int count = 1;
            foreach(var item in listD)
            {
                listDLength += item.Length;
                count++;
            }
            Console.WriteLine("The average is :" + listDLength/count);
            
            
            
            
            
            
            
            
            
            
            
            
            
            //checking for largest Val1
            //int highVal1 = 0;
            //foreach (var item in listA)
            //{
            //    //item.Trim('"');
            //    for (int i = 2; i < listB.Count; i++)
            //    {

            //        for (int j = 2; j < listB.Count; j++)
            //        {
            //            if (Int32.Parse(item) > highVal1)
            //            {
            //                highVal1 = Int32.Parse(item);
            //            }


            //        }
            //    }
            //}
            //Console.WriteLine(highVal1);


           
        }
    }
}

