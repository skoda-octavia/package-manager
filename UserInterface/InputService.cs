﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package_manager.UserInterface
{
    public static class InputService
    {
        public static readonly string InvalidComunicate = "Invalid value, try again.";

        public static string GetInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
            }
        }

        public static bool GetInputBool(string prompt)
        {
            string input = GetInput(prompt + "[yes]");
            if (input.ToLower() == "yes")
            {
                return true;
            }
            return false;
        }

        public static int GetIntInput(string prompt)
        {
            Console.Write(prompt);
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine(InvalidComunicate);
                Console.Write(prompt);
            }
            return result;
        }

        public static decimal GetDecimalInput(string prompt)
        {
            Console.Write(prompt);
            decimal result;
            while (!decimal.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine(InvalidComunicate);
                Console.Write(prompt);
            }
            return result;
        }

        public static T GetEnumInput<T>(string prompt) where T : struct, Enum
        {
            while (true)
            {
                Console.WriteLine(prompt);
                foreach (var value in Enum.GetValues(typeof(T)))
                {
                    Console.WriteLine($"* {value}");
                }

                Console.Write("Choose value: ");
                if (Enum.TryParse<T>(Console.ReadLine(), true, out var result))
                {
                    return result;
                }

                Console.WriteLine(InvalidComunicate);
            }
        }
    }
}
