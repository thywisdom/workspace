using System;
using System.Net.Security;

namespace Sortings
{
    class QuickSort
    {   

        public void Swap(int[] arr, int a , int b){ int temp = arr[a]; arr[a] = arr[b] ; arr[b] = temp;}
        public int Partition(int[] arr, int l , int h)
        {
            int pivot = arr[(l+h)/2];
            int i = l  , j = h;
            
            while (i <= j)
            {
                while(arr[i] < pivot){ i++;};
                while(arr[j] > pivot){ j--;};

                Swap(arr,i,j);
                i++; j--;
            }

            return i;
        }
        public void Quicksort(int[] arr , int l , int h)
        {
            if (l < h)
            {
                int i = Partition(arr,l,h);
                Quicksort(arr,l,i-1);
                Quicksort(arr,i+1,h);
            }
        }
    }
}