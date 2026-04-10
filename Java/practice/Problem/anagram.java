import java.util.*;

 class anagram{
    
    static boolean isAnagram(String str1 , String str2){
        char a[] = str1.toCharArray();
        Arrays.sort(a);
        char b[] = str2.toCharArray();
        Arrays.sort(b);
        if(a.length != b.length){
            return false;
        }
        for(int i = 0; i < a.length; i++) {
          if(a[i] != b[i]){
            return false;
          }
          
        }
        return true;

    }

  public static void main(String[] args) {
    Scanner sc = new Scanner(System.in);
    String word1 = sc.nextLine();;
    String word2 = sc.nextLine();

    System.out.println(isAnagram(word1, word2) ? 
                       word1 + " and " + word2 + " are anagrams." : 
                       word1 + " and " + word2 + " are not anagrams.");
    
    sc.close();
  }
}
