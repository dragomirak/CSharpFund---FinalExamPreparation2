using System;
using System.Diagnostics.Tracing;

namespace P01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] instructions = input.Split(">>>");
                string command = instructions[0];

                if (command == "Contains")
                {
                    string substring = instructions[1];
                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    string type = instructions[1];
                    int startIndex = int.Parse(instructions[2]);
                    int endIndex = int.Parse(instructions[3]);
                    int length = endIndex - startIndex;
                    string stringToModify = activationKey.Substring(startIndex, length);

                    if (type == "Upper")
                    {
                        string stringToUpper = stringToModify.ToUpper();
                        activationKey = activationKey.Replace(stringToModify, stringToUpper);
                    }
                    else if (type == "Lower")
                    {
                        string stringToLower = stringToModify.ToLower();
                        activationKey = activationKey.Replace(stringToModify, stringToLower);
                    }
                    Console.WriteLine(activationKey);
                }
                else if (command == "Slice")
                {
                    int startIndex = int.Parse(instructions[1]);
                    int endIndex = int.Parse(instructions[2]);
                    int length = endIndex - startIndex;
                    activationKey = activationKey.Remove(startIndex, length);
                    Console.WriteLine(activationKey);
                }
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}