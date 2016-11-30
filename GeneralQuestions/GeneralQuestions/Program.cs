using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {   // Open the text file using a stream reader.
                primeNums();
                using (StreamReader sr = new StreamReader("C:\\Documents\\primes.txt"))
                {
	            // Read the stream to a string, and write the string to the console.
                    string[] line = sr.ReadToEnd().Split(' ');
                    long[] longs = Array.ConvertAll(line, long.Parse);
                    using (StreamWriter sw = new StreamWriter("C:\\Documents\\BinaryPrimes.txt"))
                    {
                        foreach (long x in longs)
                        {
                            string output = Convert.ToString(x, 2);
                            sw.WriteLine(output);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
                
        }

        static void primeNums()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("C:\\Documents\\primes1.txt"))
                {
                    var primes = new List<int>();
                    primes.Add(2);
                    for (int j = 3; j <= 2000000; j += 2)
                    {
                        var currPrimes = primes.Take(primes.Count / 2);
                        bool flag = false;
                        foreach (long x in currPrimes)
                        {
                            if (j % x == 0)
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                            continue;
                        else
                        {
                            string output = Convert.ToString(j, 2);
                            sw.WriteLine(output);
                            primes.Add(j);
                        }
                    }
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        static void MissingNums()
        {
            var random = new Random();
            var numbers = new List<int>();

            int highestVal = 101;
            for (int i = 1; i < highestVal; i++)
                numbers.Add(i);

            numbers.Remove(random.Next(1, 100));
            numbers.Remove(random.Next(1, 100));

            int existingSum = 0;
            int squaredTotal = 0;
            foreach (int x in numbers)
            {
                existingSum += x;
                squaredTotal += x * x;
            }
            Console.WriteLine(existingSum + " " + squaredTotal);


            Console.Read();
        }
    }
}
