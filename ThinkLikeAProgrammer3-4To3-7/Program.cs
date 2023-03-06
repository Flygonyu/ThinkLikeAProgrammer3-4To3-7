using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace ThinkLikeAProgrammer3_4To3_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ex3dash4();
            Ex3dash7();
        }

        // 3-4 to 3-6

        static void Ex3dash4()
        {
            char[] letters =       { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
                                     'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            //char[] cipherLetters = { 'D', 'E', 'P', 'Y', 'A', 'C', 'W', 'Z', 'Q', 'T', 'S', 'N', 'L',
            //                         'B', 'F', 'G', 'I', 'K', 'H', 'J', 'M', 'O', 'R', 'X', 'U', 'V' };
            char[] cipherLetters = RandomizeCipherArray(letters);
            foreach (char letter in cipherLetters) Console.WriteLine(letter);
            string plainText = Console.ReadLine().ToUpper();
            
            string cipherText = GetCipherText(plainText, letters, cipherLetters);
            string rePlainText = GetCipherText(cipherText, cipherLetters, letters); //Ex3dash5
            Console.WriteLine(cipherText);
            Console.WriteLine(rePlainText);
        }

        //static char[] RandomizeCipherArray(char[] letters) //Ex3dash6 random index
        //{
        //    Random random = new Random();
        //    char[] cipherLetters = new char[letters.Length];

        //    int count = 0;
        //    while (true)
        //    {
        //        int randomIndex = random.Next(letters.Length);
        //        if (count >= cipherLetters.Length) break;

        //        if (cipherLetters.Contains(letters[randomIndex]) || randomIndex == count) continue;
        //        cipherLetters[count] = letters[randomIndex];
        //        count++;
        //    }
        //    return cipherLetters;
        //}

        static char[] RandomizeCipherArray(char[] letters) //Ex3dash6 random char
        {
            Random random = new Random();
            char[] cipherLetters = new char[letters.Length];

            int count = 0;
            while (true)
            {
                char randomLetter = Convert.ToChar(random.Next(65, 91));
                if (count >= cipherLetters.Length) break;

                if (letters[count] == randomLetter || cipherLetters.Contains(randomLetter)) continue;
                cipherLetters[count] = randomLetter;
                count++;
            }
            return cipherLetters;
        }

        private static string GetCipherText(string plainText, char[] letters, char[] cipherLetters)
        {
            string cipherText = "";
            for (int i = 0; i < plainText.Length; i++)
            {
                cipherText += NewLetter(plainText[i], letters, cipherLetters);
            }
            return cipherText;
        }

        static char NewLetter(char letter, char[] letters, char[] cipherLetters)
        {
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] == letter) return cipherLetters[i];
            }
            return letter;
        }

        // 3-7

        static void Ex3dash7()
        {
            int[] intArray = { 1, 4, 6, 4, 8, 2, 9, 2, 4, 6 }; // find the mode
            Array.Sort(intArray);

            int highestCount = 1;
            int currentCount = 1;
            int mode = 0;

            for (int i = 1; i < intArray.Length; i++)
            {
                if (intArray[i] == intArray[i - 1]) currentCount++;
                else currentCount = 1;

                if (currentCount > highestCount)
                {
                    mode = intArray[i];
                    highestCount = currentCount;
                }
            }
            Console.WriteLine($"The mode is {mode}, appearing {highestCount} times");
        }
    }
}