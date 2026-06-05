using System.Text;

namespace Algorithm.CodeWars
{
    public class StringKatas
    {
        /*
        Deoxyribonucleic acid (DNA) is a chemical found in the nucleus of cells and carries the "instructions" for the development 
        and functioning of living organisms. If you want to know more: http://en.wikipedia.org/wiki/DNA
        In DNA strings, symbols "A" and "T" are complements of each other, as "C" and "G". Your function receives one side
        of the DNA (string, except for Haskell); you need to return the other complementary side. DNA strand is never empty
        or there is no DNA at all (again, except for Haskell). 
        More similar exercise are found here: http://rosalind.info/problems/list-view/ 

        Example: (input --> output)
        "ATTGC" --> "TAACG"
        "GTAT" --> "CATA"
         */

        public static string MakeComplement(string dna)
        { 
            string GetComplement(char nucleotide) => nucleotide switch
            {
                'A' => "T",
                'T' => "A",
                'C' => "G",
                'G' => "C",
                _ => string.Empty
            };

            int dnaLength = dna.Length;
            StringBuilder complement = new StringBuilder(dnaLength);

            for (var i = 0; i < dnaLength; i++)
            {
                string matchingNucleotide = GetComplement(dna[i]);
                complement.Append(matchingNucleotide);
            }

            return complement.ToString();
        }

        /*
         In this kata you are required to, given a string, replace every letter with its position in the alphabet.
        If anything in the text isn't a letter, ignore it and don't return it.
        "a" = 1, "b" = 2, etc.

        Example
        Input = "The sunset sets at twelve o' clock."
        Output = "20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11"
         */

        public static string AlphabetPosition(string text)
        {
            int textLength = text.Length;
            var result = new StringBuilder(textLength);
            var positionMatch = new Dictionary<string, int>
            {
                {"A", 1 }, {"B", 2 }, {"C", 3 }, {"D", 4 }, {"E", 5 }, {"F", 6 },
                {"G", 7 }, {"H", 8 }, {"I", 9 }, {"J", 10 }, {"K", 11 }, {"L", 12 },
                {"M", 13 }, {"N", 14 }, {"O", 15 }, {"P", 16 }, {"Q", 17 }, {"R", 18 },
                {"S", 19 }, {"T", 20 }, {"U", 21 }, {"V", 22 }, {"W", 23 }, {"X", 24 },
                {"Y", 25 }, {"Z", 26 }
            };

            for (var i = 0; i < textLength; i++)
            {
                if (positionMatch.TryGetValue(text[i].ToString().ToUpper(), out int matchingNumber))
                {
                    result.Append(matchingNumber + " ");
                }
            }

            return result.ToString().TrimEnd();
        }

        /*
            Complete the solution so that it returns true if the first argument(string) passed in ends with the 2nd argument (also a string).
            Examples:

            Inputs: "abcd", "cd"
            Output: true

            Inputs: "abc", "d"
            Output: false
         */

        public static bool ConfirmFirstArgumentEndStringEndsWith2ndArg(string startStr, string endString)
        {
            if (startStr.Length < endString.Length)
            {
                return false;
            }

            int lengthDiff = startStr.Length - endString.Length;
            StringBuilder builder = new StringBuilder(endString.Length);

            for (int i = lengthDiff; i < startStr.Length; i++)
            {
                builder.Append(startStr[i]);
            }

            return builder.ToString() == endString;
        }

        /*
         Write a function that takes an integer as input, and returns the number of bits that are equal to one in 
         the binary representation of that number. You can guarantee that input is non-negative.
         Example: The binary representation of 1234 is 10011010010, so the function should return 5 in this case        
         */

        public static int CountBits(int num)
        {
            int bitCounts = 0;

            while (num is not 0)
            {
                int quotient = num / 2;
                int remainder = num % 2;

                if (remainder == 1)
                {
                    bitCounts += 1;
                }

                num = quotient;
            }

            return bitCounts;
        }

        //Title case problem
        public static string TitleCase(string title, string minorWords = "")
        {
            int titleLength = title.Length;
            var strBuilder = new StringBuilder(titleLength);
            var titleWordsArr = title.Split(' ');

            if (string.IsNullOrEmpty(minorWords) || minorWords.Equals("null"))
            {
                for (int i = 0; i < titleWordsArr.Length; i++)
                {
                    strBuilder.Append(CapitalizeFirstWord(titleWordsArr[i]) + " ");
                }

                return strBuilder.ToString().TrimEnd();
            }

            var minorWordsArr = minorWords.Split(' ');

            for (int i = 0; i < titleWordsArr.Length; i++)
            {
                if (i == 0 && minorWordsArr.Contains(titleWordsArr[i], StringComparer.OrdinalIgnoreCase))
                {
                    strBuilder.Append(CapitalizeFirstWord(titleWordsArr[i]) + " ");
                }
                else if (minorWordsArr.Contains(titleWordsArr[i], StringComparer.OrdinalIgnoreCase))
                {
                    strBuilder.Append(titleWordsArr[i].ToLower() + " ");
                }
                else
                {
                    strBuilder.Append(CapitalizeFirstWord(titleWordsArr[i]) + " ");
                }
            }

            return strBuilder.ToString().TrimEnd();
        }

        private static string CapitalizeFirstWord(string word)
        {
            var result = new StringBuilder(word.Length);

            for (int i = 0; i < word.Length; i++)
            {
                if (i == 0)
                {
                    result.Append(word[i].ToString().ToUpper());
                }
                else
                {
                    result.Append(word[i].ToString().ToLower());
                }
            }

            return result.ToString();
        }

        public static bool IsSquare(int n)
        {
            if (n < 0)
                return false;

            var squareRootResult = Math.Sqrt(n);
            var squareRootIntegerValue = (int)squareRootResult;
            var squareRootDecimalValue = squareRootResult - squareRootIntegerValue;
       
            if (squareRootDecimalValue > 0)
                return false;

            return true;
        }

        /*        
            If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
            Finish the solution so that it returns the sum of all the multiples of 3 or 5 below the number passed in.

            Additionally, if the number is negative, return 0.
            Note: If a number is a multiple of both 3 and 5, only count it once.
         */
        public static int MultiplesOfNumberSum(int value)
        {
            if (value < 0)
                return 0;

            int result = 0;

            for (int currentNumber = 1; currentNumber < value; currentNumber++)
            {
                if (currentNumber % 3 == 0 || currentNumber % 5 == 0)
                {
                    result += currentNumber;
                }
            }

            return result;
        }
    }
}
