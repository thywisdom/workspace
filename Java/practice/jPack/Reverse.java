package jpack;

import java.util.Scanner;



public class Reverse {
	
	static String Reverse(String st, int i) {
	    if (i < 0) {
	        return "";
	    }
	    return st.charAt(i) + Reverse(st, i - 1);
	}



	public static void main(String args[]) {
		Scanner sc=new Scanner(System.in);
		String st=sc.next();
		String str= "";
		/*for(int i=0;i<st.length();i++) {
			str=str + st.charAt(st.length()-1-i);
		}
		
		System.out.println(str);
		*/
		
		
		System.out.println(Reverse(st,st.length()-1));
	}

}
