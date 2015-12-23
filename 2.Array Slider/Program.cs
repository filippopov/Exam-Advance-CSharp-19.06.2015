using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Array_Slider
{
    using System.Text.RegularExpressions;

    class Program
    {
        private static long[] inputArray;

        private static string inputCommands;

        private static long[] result;

        private static long sumIndex;

        static void Main(string[] args)
        {
            string pattern = @"\s+";
            inputArray =
                Regex.Split(Console.ReadLine(),pattern)
                    .Select(long.Parse)
                    .ToArray();
            result = inputArray;
            inputCommands = string.Empty;
            while (true)
            {
                
                inputCommands = Console.ReadLine();
                if (inputCommands == "stop")
                {
                    break;
                }
                string[] commandsArray = inputCommands.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                long index = long.Parse(commandsArray[0]);
                string operatorValue = commandsArray[1].Trim();
                int value = int.Parse(commandsArray[2]);

                sumIndex += index;
                if (index >= 0)
                {
                    

                    if (sumIndex >= inputArray.Length)
                    {
                        sumIndex = sumIndex % inputArray.Length;
                    }
                }
                else
                {
                    index = index * -1;
                    sumIndex =  index % inputArray.Length;
                    if (sumIndex != 0)
                    {
                        sumIndex = inputArray.Length - sumIndex;
                    }

                    
                }

                

                ChangeValueInResultArray(sumIndex, operatorValue, value);
            }

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 0)
                {
                    result[i] = 0;
                }
            }

            Console.WriteLine($"[{string.Join(", ",result)}]");

        }

        private static void ChangeValueInResultArray(long index, string operatorValue, long value)
        {
            switch (operatorValue)
            {
                case "*":
                    {
                        result[index] = inputArray[index] * value;
                    }
                    break;
                case "/":
                    {
                        result[index] = inputArray[index] / value;
                    }
                    break;
                case "+":
                    {
                        result[index] = inputArray[index] + value;
                    }
                    break;
                case "-":
                    {
                        result[index] = inputArray[index] - value;
                    }
                    break;
                case "&":
                    {
                        result[index] = inputArray[index] & value;
                    }
                    break;
                case "^":
                    {
                        result[index] = inputArray[index] ^ value;
                    }
                    break;
                case "|":
                    {
                        result[index] = inputArray[index] | value;
                    }
                    break;
            }
        }
    }
}
