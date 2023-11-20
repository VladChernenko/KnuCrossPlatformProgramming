/*
 

MIT License

by Vlad Chernenko (IPZ-41/1)
 
Ticket 15



[Task]:

    Find all the dividers of x which can be divided by ALL the prime divisors of x


[Solution]:

    1) We are looking for only prime divisors of the number x
    2) From this array we obtain an array of only unique values and look for their product. For the target divisor to be divisible by all of them - they all must be in the product
    3) We get the array 'rest' = prime_divisors - unique_divisors
    4) Go through the rest and multiply each element by the product unique_prime_numbers 

 
*/


namespace Lab5PreviousTasks
{
    public class Lab1
    {

        // Function to search for prime divisors
        static List<int> GetPrimeDividers(int x)
        {
            List<int> answer = new List<int>();

            int d = 2;

            while (d * d <= x)
            {
                if (x % d == 0)
                {
                    answer.Add(d);
                    x /= d;
                }
                else
                {
                    d += 1;
                }
            }
            if (x > 1)
            {
                answer.Add(x);
            }
            return answer;
        }



        public static string Lab1Execution(string inputFileName, string outputFileName)
        {

            string response = "";

            try
            {

                // Read the x from input.txt
                int x = int.Parse(File.ReadAllText(inputFileName));


                // Find & display all the prime dividers
                List<int> primeDivisors = GetPrimeDividers(x);

                response += "Prime divisors are " + string.Join(", ", primeDivisors)+"\n";

                // List the unique values
                List<int> uniquePrimeDivisors = primeDivisors.Distinct().ToList();


                response += "Unique prime divisors are " + string.Join(", ", uniquePrimeDivisors) + "\n";

                // We'll need production of unique values to product it with the rest(non-unique) values 
                int productionOfUnique = uniquePrimeDivisors.Aggregate(1, (acc, val) => acc * val);

                response += "Prime divisors are " + string.Join(", ", primeDivisors) + "\n";


                /*

                       __________________________ Start to find rest values __________________________             

                       [1] Example - if we get the [2,2,3,3,4,6] in GetPrimeDividers(), the 'rest' array will contain [2,3]

                       [2] productionOfUnique in this case will be 2*3*4*6

                       [3] uniquePrimeDivisors will be [2,3,4,6]

                */


                List<int> rest = new List<int>(primeDivisors);

                foreach (int value in uniquePrimeDivisors)
                {
                    rest.Remove(value);
                }


                response += "Rest: " + string.Join(", ", rest) + "\n";


                // This array will contain all the dividers of X which can be divided for ALL the prime dividers of X
                // We will display them & write number of them to output.txt
                List<int> result = new List<int> { productionOfUnique };

                int currentStep = productionOfUnique;

                foreach (int value in rest)
                {
                    currentStep *= value;
                    result.Add(currentStep);
                }

                string outputText = "Solution: " + string.Join(", ", result);

                File.WriteAllText(outputFileName, result.Count().ToString());
          

                response += outputText + "\n";


            }

            catch (Exception e)
            {
                Console.WriteLine();

                response += "An error occurred: " + e.Message + "\n";

            }

            return response;
        }
    }
}
