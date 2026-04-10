using System;

namespace Search
{
    class Binarysearch
    {
        public int BinarySearch(int[] arr , int l, int h, int target)
        {   
            if(l > h) return -1;
            
            int mid = l + (h-l)/2;
            
            if(arr[mid] == target)
            {
                return mid;
            }
            else if(arr[mid] > target)
            {
                return BinarySearch(arr,l,mid-1,target);
            }
            else
            {
                return BinarySearch(arr,mid+1,h,target);
            }

        }
    }
}
