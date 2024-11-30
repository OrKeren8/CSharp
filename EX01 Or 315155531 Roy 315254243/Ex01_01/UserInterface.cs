﻿using System;
using System.Collections;
using System.Linq;
using System.Security.AccessControl;

namespace Ex01_01
{
    internal class UserInterface
    {
        
        public static void BinarySeries()
        {
            const int k_amountOfBinaryNumbers = 3;
            const int k_BinaryNumberLength = 8;
            string[] binaryNumbersArr = new string[k_amountOfBinaryNumbers];
            int[] decimalNumbersArr = new int[k_amountOfBinaryNumbers];


            System.Console.WriteLine($"Please enter {k_amountOfBinaryNumbers} binary numbers with {k_BinaryNumberLength} digits each");
            for (int i = 0; i < k_amountOfBinaryNumbers; i++)
            {
                binaryNumbersArr[i] = getUserBinaryNumInput(k_BinaryNumberLength);
                decimalNumbersArr[i] = BinaryData.convertBinaryNumberToInt(binaryNumbersArr[i]);
            }

            Array.Sort(decimalNumbersArr);  //maybe we would need to create our own
            printNumbers(decimalNumbersArr);
            printStatistics(decimalNumbersArr, binaryNumbersArr);
        }

        private static string getUserBinaryNumInput(int i_BinaryNumberLength)
        {
            string line;
            line = System.Console.ReadLine();
            while (!BinaryData.ValidateBinaryNumber(line, i_BinaryNumberLength))
            {
                System.Console.WriteLine("The input you entered is invalid. Please try again.");
                line = System.Console.ReadLine();
            }

            return line;
        }

        private static void printNumbers(int[] i_numbers)
        {
            Console.Write("The numbers are: ");
            foreach (int number in i_numbers)
            {
                Console.Write(number + " ");
            }
        }

        private static void printStatistics(int[] i_numbers, string[] i_boolNumbers)
        {
            Console.WriteLine($"The avarage of the numbres is: {Statistics.NumbersArrAverage(i_numbers)}");
            (int numIndex, int longestStrike) = Statistics.LongestBitStrike(i_boolNumbers);
            Console.WriteLine($"The longest strike of bits is: {longestStrike} ({i_boolNumbers[numIndex]})");
            int[] swapsAmount = Statistics.MaxDigitSwaps(i_boolNumbers);
            Console.Write("Num of swaps: ");
            for (int i = 0; i< i_boolNumbers.Length; i++)
            {
                Console.Write($"{swapsAmount[i]}({i_boolNumbers[i]}) ");
            }
            Console.WriteLine();

        }
    }
}   