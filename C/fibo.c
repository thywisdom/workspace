#include <stdio.h>
#include <string.h>
#include <stdbool.h>


int main(){
  int n ;
    printf(" Enter a number : ");
    scanf("%i",&n);
    printf("\n");
    int a = 0;
    int b = 1;
    printf("0 -> 1");
    
    for(int i = 2 ; i < n; i++){
    printf(" -> %i",a+b);
    b=a+b;
    a=b-a;
  }

  return 0;
}
