using System;

namespace Sortings
{
    class Bubblesort
    {
        public void BubbleSort(int[] arr)
        {
            for(int i = 0 ; i < arr.Length - 1 ; i++)
            {
                bool swapped = false;
                for(int j = 0 ; j < arr.Length - 1 -i ; j++)
                {
                    if(arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = temp;

                        swapped = true;
                    }
                }

                if (!swapped)
                    {
                        break;
                    }
            }
        }
    }
}