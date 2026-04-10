#include <stdio.h>
#include <string.h>
#include <stdbool.h>

int main(){

  int power(int a , int b){
    int c = a;
    for(int i =1; i<b;i++){
      c*=a;
    }
    return c;
  }

  int n ;

  printf("Enter a number to check : ");
  scanf("%d",n);
  
  int rev = 0;
  int i = 0;
  int sum = 0;
  
  while(i < n){
    int digit = n%10;
    sum += power)
  }
  return 0;
}
