import java.io.*;
import java.util.*;

class Practice {

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(
            new InputStreamReader(System.in)
        );

        String s = br.readLine();
        int n = Integer.parseInt(br.readLine());
        System.out.println(s + "  " + n);
    }
}
