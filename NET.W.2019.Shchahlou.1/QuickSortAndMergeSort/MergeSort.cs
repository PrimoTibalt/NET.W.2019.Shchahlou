namespace QuickSortAndMergeSort
{
    public struct MergeSort
    {
        /// <summary>
        /// Sort part(low, high) of input array
        /// </summary>
        /// <param name="input"></param>
        /// <param name="low">Bottom line</param>
        /// <param name="high">Upper bound</param>
        public static void Sort(int[] input, int low, int high)
        {
            if (input == null)
            {
                throw new System.ArgumentNullException("Array is null, nothing to sort!");
            }

            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                Sort(input, low, middle);
                Sort(input, middle + 1, high);
                Merge(input, low, middle, high);
            }
        }

        /// <summary>
        /// Sorts entire input array.
        /// </summary>
        /// <param name="input"></param>
        public static void Sort(int[] input)
        {
            if (input == null)
            {
                throw new System.ArgumentNullException("Array is null, nothing to sort!");
            }

            Sort(input, 0, input.Length - 1);
        }

        /// <summary>
        /// Main algorithm of sorting
        /// </summary>
        /// <param name="input">array to sort</param>
        /// <param name="low">bottom line of array to sort</param>
        /// <param name="middle"></param>
        /// <param name="high">upper bound of array to sort</param>
        private static void Merge(int[] input, int low, int middle, int high)
        {
            int left = low;
            int right = middle + 1;
            int[] tmp = new int[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (input[left] < input[right])
                {
                    tmp[tmpIndex] = input[left];
                    left++;
                }
                else
                {
                    tmp[tmpIndex] = input[right];
                    right++;
                }

                tmpIndex++;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = input[left];
                    left++;
                    tmpIndex++;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = input[right];
                    right++;
                    tmpIndex++;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                input[low + i] = tmp[i];
            }
        }
    }
}
