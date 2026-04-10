class solution{
    static int isPrimePalyndrome(int a){
        int i , num;
        for(i=a ; i>a ; i++){
            for(j=2 ; j<i ;j++){
                if(i%j != 0)
                    if(j== i-1){
                        num = i;
                    }
                
            }
        }
        int [] arr = Integer.toArray(num);
        for(int k = 0;k < arr.length/2; k++){
            if(arr[k] == arr[arr.length-1]){
                if(arr[k] == arr.lenght/2)
                    return num;
                isPrimePalyndrome(num);
            }
        }
    }
}