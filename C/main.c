#include <stdio.h>
#include <stdbool.h>
#include <string.h>
#include <ctype.h>

#define length(arr) sizeof(arr)/sizeof(arr[0])

int main(){
 
  char a[]= "TeNnet";
  int count = 1;

  for(int i = 1 ; i < (strlen(a)/2); i++){
      if (tolower(a[i]) == tolower(a[strlen(a)-i0])) {
      count++;
      }
  }

  if(count == (strlen(a)/3)){
      printf("True");
  }else{
    printf("False");
  }
  printf("\n");
  printf("length %d compares to %d",length(a)/3,count);
  return 1;
}
