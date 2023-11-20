using System;
using System.Collections.Generic;
using System.IO;




/*
 

MIT License

by Vlad Chernenko (IPZ-41/1)
 
Ticket 15

Lab2


[Task]:

    У заданому слові S знайти кількість так званих "майже паліндромів" в яких необхідно змінити не більше ніж K букв щоб це слово вважалось паліндромом


[Solution]:

    1) Шукємо всі підслова в слові S
    2) Запускаємо по них цикл
    3) Всередині цього цикла - вкладений цикл по символам слова. Від word[0] до word[length-1] зі зміщенням до центру слова
    4) На кожному кроці вкладеного циклу перевіряємо рівність символів. Якщо вони не співпадають - фіксуємо це. При перебільшені K можна виходити з даного циклу так як немає сенсу більше перевіряти слово
    5) Також на кожному кроці робимо перевірку умов виходу з нього. Якщо слово складається з парної кількості букв, то вихід буде при startOfWordIndex + 1 == endOfWordIndex, інакше при startOfWordIndex == endOfWordIndex
    6) Після виходу з вкладеного циклу перевіряємо чи не було виходу по причині переповнення K. Якщо ні - збільшуємо кількість майже паліндромів та додаємо в масив(щоб потім наглядно вивести)
    7) Записуємо фінальну кількість до output.txt
 
*/



namespace Lab5PreviousTasks
{

    public class Lab2
    {
        public static string Lab2Execution(string inputPath, string outputPath)
        {
            string word;
            int K;


            using (StreamReader reader = new StreamReader(inputPath))
            {

                K = int.Parse(reader.ReadLine().Split(" ")[1]);

                word = reader.ReadLine();

            }

            // Get the list of subwords to find almost pallindroms
             List<string> subwords = FindSubwords(word);

             return FindAlmostPalindromes(subwords, K, outputPath);
        }

        static List<string> FindSubwords(string word)
        {
            List<string> subwords = new List<string>();
            int wordLength = word.Length;

            // Проходимося по всім можливим комбінаціям позицій для вибору підслова
            for (int start = 0; start < wordLength; start++)
            {
                for (int end = start + 1; end <= wordLength; end++)
                {
                    string subword = word.Substring(start, end - start);
                    subwords.Add(subword);
                }
            }

            return subwords;
        }

        static string FindAlmostPalindromes(List<string> subwords, int K, string outputPath)
        {
            int totalNumberOfAlmostPalindromes = 0;
            List<string> almostPalindromes = new List<string>();

            string response = "";

            // Ітеруємось по всіх підсловах для пошуку майже-паліндромів
            foreach (string subword in subwords)
            {
                int numberOfRequiredChanges = 0;
                int startOfWordIndex = 0;
                int endOfWordIndex = subword.Length - 1;
                bool thisIsAlmostPalindrome = true;

                while (true)
                {

                    // Фіксуємо чи треба змінити літеру
                    if (subword[startOfWordIndex] != subword[endOfWordIndex])
                        numberOfRequiredChanges++;

                    // Якщо вже більше K - не має сенсу перевіряти підслово далі
                    if (numberOfRequiredChanges > K)
                    {
                        thisIsAlmostPalindrome = false;
                        break;
                    }

                    // Перевіряємо чи все підслово було пропарсене
                    if (subword.Length % 2 == 0)
                    {
                        if (startOfWordIndex + 1 == endOfWordIndex)
                            break;
                    }
                    else if (startOfWordIndex == endOfWordIndex)
                    {
                        break;
                    }

                    // Рухаємось далі
                    startOfWordIndex++;
                    endOfWordIndex--;
                }

                if (thisIsAlmostPalindrome)
                {
                    totalNumberOfAlmostPalindromes++;
                    almostPalindromes.Add(subword);
                }
            }

            response += "Total number of almost palindromes => " + totalNumberOfAlmostPalindromes + "\n";

            response += "List of almost palindromes => " + string.Join(", ", almostPalindromes) + "\n";


            // Записуємо результати у файл
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.WriteLine("Total number of almost palindromes => " + totalNumberOfAlmostPalindromes);

                response += "Total number of almost palindromes => " + totalNumberOfAlmostPalindromes + "\n";

            }

            return response;

        }

    }
}