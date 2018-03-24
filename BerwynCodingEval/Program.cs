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
            int ValMax = 0;
            string greatestGUID = "";
            int ValSum = 0;
            string Val1Value = "";
            string Val2Value = "";
            int Val1Int = 0;
            int Val2Int = 0;
            var lines = "";

            List<string> listGUID = new List<string>();
            List<string> listVal1 = new List<string>();
            List<string> listVal2 = new List<string>();
            List<string> listVal3 = new List<string>();
            
            using (var reader = new StreamReader("test.csv"))
            {

                while (!reader.EndOfStream)
                {
                    lines = reader.ReadLine();
                    var values = lines.Split(',');
                    listGUID.Add(values[0]);
                    listVal1.Add(values[1]);
                    listVal2.Add(values[2]);
                    listVal3.Add(values[3]);


                    
                    
                    



                }
            }
            
            
            
            
            //Finds the greatest sum of Val1 + Val2
            for (int i = 2; i < listVal1.Count; i++)
            {
                
                Val1Value = listVal1[i].Replace('"', ' ').Trim();
                Val2Value = listVal2[i].Replace('"', ' ').Trim();
                Val1Int = Int32.Parse(Val1Value);
                Val2Int = Int32.Parse(Val2Value);
                ValSum = Val1Int + Val2Int;
                if(ValSum > ValMax)
                {
                    ValMax = ValSum;
                    greatestGUID = listGUID[i].Replace('"', ' ').Trim();
                }
                
            }

            Console.WriteLine("The greatest sum of Val1 and Val2 is: "+ ValMax);
            Console.WriteLine("The corresponding GUID is: " + greatestGUID);
            


            //Calculates the total number of entries for all columns in all rows
            int totalValues = listGUID.Count + listVal2.Count + listVal3.Count + listVal3.Count;
            Console.WriteLine("The total number of values is: " + totalValues);



            //checking for duplicate GUIDs
            var duplicates = new List<string>();
            var hashset = new HashSet<string>();
            foreach (var item in listGUID)
            {
                if (!hashset.Add(item))
                {
                    duplicates.Add(item);
                    Console.WriteLine(item.Replace('"', ' ').Trim() + " is a duplicate GUID.");

                }
            }
            //calculates the average of all Val3 entries
            int listVal3Length = 0;
            int count = 0;
            foreach(var item in listVal3)
            {
                listVal3Length += item.Length;
                count++;
                
            }
            Console.WriteLine("The average is: " + listVal3Length/count);


            StreamWriter writer = new StreamWriter("outputFile.csv");
            //using (writer)
            //{
            //for (int i = 0; i < 4; i++)
            int counter = 0;
            foreach(var line in lines)
            {
                Val1Value = listVal1[line].Replace('"', ' ').Trim();
                Val2Value = listVal2[line].Replace('"', ' ').Trim();
                Val1Int = Int32.Parse(Val1Value);
                Val2Int = Int32.Parse(Val2Value);
                ValSum = Val1Int + Val2Int;
                //int sum = Int32.Parse(listVal1[line]) + Int32.Parse(listVal2[line]);
                Console.Write(listGUID[line]);
                Console.Write(",");
                Console.Write(ValSum);
                Console.WriteLine();
                Console.WriteLine(counter);
                counter++;
                   
            }


            //}

















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

