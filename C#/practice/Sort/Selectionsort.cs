using System;

namespace Sortings
{
    class Selectionsort
    {
        public void SelectionSort(int[] arr)
        {
            for(int i = 0 ; i < arr.Length - 1 ; i++)
            {
                int minIndex = i;

                for(int j = i +1 ; j < arr.Length ; j++)
                {
                    if(arr[j] < arr[i])
                    {
                        minIndex = j;
                    }
                } 

                if( minIndex != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }
        }
    }
}