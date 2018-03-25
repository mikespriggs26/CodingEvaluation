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
            //            Build a C# console application to parse this file and output a result .csv file. 

            //C# Console Output: 
            //•             Output the total number of records in the file. 
            //•             Show the largest sum of Val1 and Val2 for any single row in the CSV, as well as the GUID for that row. 
            //•             Show any Duplicate GUID values.
            //•             Show the average length of Val3 across all input rows.
            //Output CSV file: 
            //•             For each input row: 
            //•             Output columns: 
            //•             GUID 
            //•             Val1 + Val2 
            //•             IsDuplicateGuid(Y or N) 
            //•             Is Val3 length greater than the average length of Val3(Y or N)



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
                    //Console.WriteLine(item.Replace('"', ' ').Trim() + " is a duplicate GUID.");

                }
            }
            Console.WriteLine("The duplicate GUIDs are: ");
            foreach (var dup in duplicates)
            {
                Console.WriteLine(dup.Replace('"', ' ').Trim());
            }
            //calculates the average of all Val3 entries
            int listVal3Length = 0;
            int count = 0;
            foreach(var item in listVal3)
            {
                listVal3Length += item.Length;
                count++;
                
            }
            Console.WriteLine("The average is length of Val3 is: " + listVal3Length/count);


            //Outputting the new file
            StreamWriter writer = new StreamWriter("outputFile.csv");
            using (writer)

            for (int i = 1; i < listGUID.Count; i++)
            
            {
                Val1Value = listVal1[i].Replace('"', ' ').Trim();
                Val2Value = listVal2[i].Replace('"', ' ').Trim();
                Val1Int = Int32.Parse(Val1Value);
                Val2Int = Int32.Parse(Val2Value);
                ValSum = Val1Int + Val2Int;
                
                Console.Write(listGUID[i]);
                Console.Write(",");

                Console.Write(ValSum);
                Console.Write(",");

                if (duplicates.Contains(listGUID[i]))
                {
                    Console.Write("Yes");
                }
                else
                {
                    Console.Write("No");
                }
                Console.Write(",");

                
                int Val3Length = listVal3[i].Count();

                if (Val3Length > listVal3Length / count)
                {
                    Console.Write("Yes");
                }
                else
                {
                    Console.Write("No");
                }

                Console.WriteLine();
                
               
                   
            }

            




            



        }
    }
}

