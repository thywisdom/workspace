package jpack;
import java.util.*;

public class Palindrome {
				public static void main(String arg[]) {
					
					Scanner sc = new Scanner(System.in);
					String s = sc.next();
					int count = 0;
					for(int i = 0; i<s.length()/2; i++) {
						if(s.charAt(i) == s.charAt(s.length()-i)) {
							
							count++;
						}
					}
					
					if(count == s.length()/2)
						return true;
					
				}
}
