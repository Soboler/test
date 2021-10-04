using System;
using System.Collections.Generic;

namespace Interview
{
    /* Задача:

    Даны два целых неотрицательных числа, записанных следующим образом. Каждая цифра записывается её 
    английским названием, первая буква цифры большая, остальные - маленькие.

    Например, число 1293 записывается как "OneTwoNineThree", число 135 как "OneThreeFive", число 0 
    как "Zero". Ведущие нули в записи отсутствуют (за исключением самого числа 0).

    Нужно сравнить эти два числа (сравнивать их нужно как числа) и вернуть:
    -1, если первое число меньше, 
    0, если значения чисел совпадают, 
    1, если первое число больше.

    Пример использования:
    var result = new NumberStringsComparer().Compare("OneTwoNineThree", "OneThreeFive");
 
    Для проверки решения необходимо запустить тесты.

    Подсказка:
    При использовании класса System.Numerics.BigInteger не пройдут тесты TestBig (числа из 200 тысяч цифр).
    */

    public class NumberStringsComparer
    {
        private static readonly string[] digits =
        {
            "Zero",
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
        };

        public int Compare(string first, string second)
        {
            var firstDigits = ConvertToDigits(first);
            var secondDigits = ConvertToDigits(second);
            return CompareListsOfDigits(firstDigits, secondDigits);
        }

        private List<int> ConvertToDigits(string s)
        {
            var result = new List<int>();

            int prevUpper = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (char.IsUpper(s[i]))
                {
                    var textDigit = s[prevUpper..i];
                    prevUpper = i;

                    result.Add(Array.IndexOf(digits, textDigit));
                }
                else continue;
            }
            string lastDigitt = s.Substring(prevUpper);
            result.Add(Array.IndexOf(digits, lastDigitt));

            return result;
        }

        private int CompareListsOfDigits(List<int> first, List<int> second)
        {
            if (first.Count > second.Count)
                return 1;
            if (first.Count < second.Count)
                return -1;

            for (int i = 0; i < first.Count; i++)
            {
                if (first[i] == second[i])
                    continue;
                if (first[i] > second[i])
                    return 1;
                if (first[i] < second[i])
                    return -1;
            }
            return 0;
        }
    }
}