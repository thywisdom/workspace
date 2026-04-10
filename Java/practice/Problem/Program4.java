import java.util.Scanner;

public class Program4 {

	public static void main(String[] args) {
		/* i.p/ abccbda
             working abbda
                      ada
           o.p/ score=3    */
		Scanner sc=new Scanner(System.in);
		StringBuffer st=new StringBuffer();
		st.append("abccbda");
		int score=0;
		for(int i=0;i<st.length()-1;i++) {
		if(st.charAt(i)==st.charAt(i+1)) {
			score++;
			st.delete(i, i+2);
			i=0;
		}
}
		System.out.println(st);
		System.out.println(score);

}}
