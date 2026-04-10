import java.util.*;

public class main 
{
  static void reverse(int a[])
  {
    int n=a.length;
    int r=n-1;
    for
    Scanner s = new Scanner 
    (int l=0;l<n/2;l++)
    {
      int t=a[l];
      a[l]=a[r];
      a[r]=t;
      r--;
    }
  }
  public static void main(String[] args) 
  {
    Scanner s=new Scanner(System.in);
    int n=s.nextInt();
    int arr[]=new int[n];
    for(int i=0;i<n;i++)
      arr[i]=s.nextInt();
    reverse(arr);
    for(int i=0;i<n;i++)
      System.out.print(arr[i]+" ");
  }
}