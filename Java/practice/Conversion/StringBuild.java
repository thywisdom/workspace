import java.util.*;

class StringBuild {

    public static void main(String[] args) {

        StringBuilder sb = new StringBuilder();
        sb.append("suman");
        sb.append("is a");
        sb.append(4);
        sb.append(true);

        System.out.println(sb.toString().trim());
    }
}
