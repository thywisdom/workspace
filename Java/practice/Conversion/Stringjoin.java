import java.util.Arrays;

public class Stringjoin {

    public static void main(String[] args) {
        String[] words = { "Hello", "World", "from", "Java" };

        String joined = String.join(" ", words);
        String join = String.join(" ", words).trim();

        System.out.println(joined);
        System.out.println(join);
        System.out.println(Arrays.toString(words));
    }
}
