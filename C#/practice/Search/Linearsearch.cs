using System;

namespace Search
{
    class Linearsearch
    {
        public int LinearSearch(int[] arr, int target)
        {
            for(int i = 0 ; i < arr.Length ; i++)
            {
                if ( arr[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }
    }

}