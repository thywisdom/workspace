using System;

namespace Sortings
{
class MergeSort
    {
        public void Mergesort(int[] arr , int l , int h)
        {
            if(l<h){
                int mid = l+(h-l)/2;

                Mergesort(arr,l,mid);
                Mergesort(arr,mid+1,h);

                Merge(arr,l,mid,h);
            }
        }
        public void Merge(int[] arr, int l ,int m, int h)
        {
            int n1 = m - l + 1;
            int n2 = h - m;

            int[] L = new int[n1];
            int[] R = new int[n2];

            int i , j ; // NOTE: In C#, loop variables declared in `for` persist in the method scope,
            // so `i` and `j` must be declared once and reused (unlike Java).


            for( i =  0 ; i < n1; i++){ L[i] = arr[l + i];}    // C# scoping: declare loop indices once; `for(int i...)` can't be reused later (unlike Java)
            for( j = 0 ; j < n2; j++){ R[j] = arr[m + 1 + j];}

             i = 0 ; j = 0 ; int  k = l;

            while( i < n1 && j < n2)
            {
                if(L[i] <= R[j]){ 
                    arr[k] = L[i]; i++;
                }
                else
                {
                    arr[k] = R[j]; j++;
                }
                k++;
            }

            while( i < n1){ arr[k] = L[i] ; i++; k++;}
            while( j < n2){ arr[k] = R[j] ; j++; k++;}
        }
    }
}