namespace Algorithm.MIU.Arrays
{
    public class MIUArray
    {
        public static int CenteredArray(int[] array)
        {
            if (array == null || array.Length == 0 || (array.Length % 2 == 0))
            {
                return 0;
            }

            int length = array.Length;
            int middleIndex = length / 2;
            int middleElement = array[middleIndex];

            for (int i = 0; i < length; i++)
            {
                if( i != middleIndex && middleElement >= array[i])
                {
                    return 0;
                }
            }

            return 1;
        }

        public static int DifferenceInSumAndEvenNumbers(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }

            int oddSum = 0;
            int evenSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evenSum += array[i];
                }
                else
                {
                    oddSum += array[i];
                }
            }

            return oddSum - evenSum;
        }

        public static char[]? LengthCharacters(char[] array, int startPosition, int length)
        {
            if (array == null || array.Length == 0 || startPosition < 0 || length < 0 || length + startPosition > array.Length)
            {
                return null;
            }

            if (length == 0)
            {
                return [];
            }

            char[] charArray = new char[length];
            int newCharIndexPos = 0;

            for (int i = startPosition; i < length + startPosition; i++)
            {
                charArray[newCharIndexPos] = array[i];
                newCharIndexPos++;
            }

            return charArray;
        }

        public static int[]? ReturnDistinctItemsInArray(int[] arrayOne, int[] arrayTwo)
        {
            if (arrayOne == null || arrayTwo == null)
                return null;

            var tempArray = new List<int>();

            for (int i = 0, k = 0; i < arrayOne.Length; i++, k++)
            {
                for (int j = 0; j < arrayTwo.Length; j++)
                {
                    if(arrayOne[i] == arrayTwo[j])
                    {
                        tempArray.Add(arrayOne[i]);
                        break;
                    }
                }
            }

            var newArray = new int[tempArray.Count];
            int idxpos = 0;

            foreach (var item in tempArray)
            {
               newArray[idxpos++] = item;
            }

            return newArray;
        }

        public static int PointOfEquilibrium(int[] array)
        {
            if(array == null || array.Length == 0 || array.Length < 3)
                return -1;

            int length = array.Length;

            for (int i = 1; i < length; i++)
            {
                var leftSum = CalculateSideSum(0, i - 1, array);
                var rightSum = CalculateSideSum(i + 1, length - 1, array);

                if (leftSum == rightSum) {  return i; }
            }

            return -1;
        }

        public int hasNValues(int[] a, int n)
        {
            if (a == null || a.Length == 0)
                return 0;

            var hashSet = new HashSet<int>();

            foreach (var item in a)
            {
                if (!hashSet.Contains(item))
                    hashSet.Add(item);
            }

            if (hashSet.Count == n)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int is123Array(int[] a)
        {
            if (a == null || a.Length == 0)
                return 0;

            int one = 1; 
            int two = 2; 
            int three = 3;

            bool firstRepetitionFound = false;
            bool secondRepetitionFound = false;
            int loopCount = 0;

            for(int i = 0; i <= a.Length - 3; i += 3)
            {
                int firstItem = a[i];
                int secondItem = a[i + 1];
                int thirdItem = a[i + 2];

                if(firstItem == one && secondItem == two && thirdItem == three && !firstRepetitionFound)
                {
                    firstRepetitionFound = true;
                }
                else if (firstItem == one && secondItem == two && thirdItem == three && loopCount < 2 && !secondRepetitionFound)
                {
                    secondRepetitionFound = true;
                }

                if (a.Length == 3 && firstRepetitionFound)
                {
                    return 1;
                }

                if(firstRepetitionFound && secondRepetitionFound)
                {
                    return 1;
                }

                loopCount++;
            }

            return 0;
        }

        public int isMercurial(int[] a)
        {
            if (a == null || a.Length == 0)
                return 1;

            bool foundOne = false;

            for (int i = 0; i < a.Length; i++) 
            {
                if (a[i] == 1)
                {
                    if (foundOne)
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (a[k] == 1)
                            {
                                break;
                            }

                            if (a[k] == 3)
                            {
                                return 0;
                            }
                        }
                    }

                    foundOne = true;
                }
            }

            return 1;
        }
        private static int CalculateSideSum(int startIdx, int stopIdx, int[] array)
        {
            int sum = 0;

            for (int i = startIdx; i <= stopIdx; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    
    }
}