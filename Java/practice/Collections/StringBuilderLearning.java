/**
 * This class is a hands-on tutorial for learning Java's StringBuilder.
 * Each step is printed to the console to make it easy to follow.
 */
public class StringBuilderLearning {

    public static void main(String[] args) {
        System.out.println(
            "### Welcome to the StringBuilder Learning Example! ###"
        );

        // =================================================================
        // 0. THE CORE CONCEPT: Mutable vs. Immutable
        // =================================================================
        System.out.println(
            "\n--- 0. The Core Concept: Why use StringBuilder? ---"
        );
        System.out.println(
            "A standard 'String' in Java is IMMUTABLE. This means once it's created, it cannot be changed."
        );
        System.out.println(
            "When you do 'String s = s + \"a\";', you are actually creating a brand new String object."
        );
        System.out.println(
            "'StringBuilder' is MUTABLE. It allows you to modify the text content without creating a new object every time."
        );
        System.out.println(
            "This makes it much more efficient when you need to make many changes to a string."
        );

        // =================================================================
        // 1. CONSTRUCTORS (Creating a StringBuilder)
        // =================================================================
        System.out.println("\n--- 1. Constructors ---");

        // A. Empty constructor
        StringBuilder sb1 = new StringBuilder();
        System.out.println("A) Created an empty StringBuilder.");
        System.out.println("   - Initial content: \"" + sb1 + "\"");
        System.out.println(
            "   - Initial length (number of characters): " + sb1.length()
        );
        System.out.println(
            "   - Initial capacity (allocated memory): " + sb1.capacity()
        );

        // B. Constructor with a String
        StringBuilder sb2 = new StringBuilder("Hello");
        System.out.println(
            "\nB) Created a StringBuilder from the string 'Hello'."
        );
        System.out.println("   - Initial content: \"" + sb2 + "\"");
        System.out.println("   - Initial length: " + sb2.length());
        System.out.println(
            "   - Initial capacity: " + sb2.capacity() + " (String length + 16)"
        );

        // =================================================================
        // 2. ESSENTIAL MANIPULATION FUNCTIONS
        // =================================================================
        System.out.println("\n--- 2. Essential Manipulation Functions ---");
        StringBuilder builder = new StringBuilder("Java is");

        // A. append() - Add to the end
        System.out.println("\n   --- A. Using append() to add content ---");
        System.out.println("Initial builder state: \"" + builder + "\"");
        builder.append(" fun"); // Append a String
        builder.append('!'); // Append a char
        builder.append(" It was released in "); // Append another String
        builder.append(1995); // Append an int
        System.out.println(
            "After appending multiple types: \"" + builder + "\""
        );

        // B. insert() - Add at a specific position
        System.out.println(
            "\n   --- B. Using insert() to add content at an index ---"
        );
        // void insert(int offset, String str)
        builder.insert(8, "very "); // Insert "very " at index 8
        System.out.println(
            "After inserting 'very ' at index 8: \"" + builder + "\""
        );

        // C. delete() and deleteCharAt() - Remove content
        System.out.println("\n   --- C. Using delete() and deleteCharAt() ---");
        // StringBuilder delete(int start, int end)
        builder.delete(8, 13); // Deletes "very " (index 8 up to, but not including, 13)
        System.out.println(
            "After deleting from index 8 to 13: \"" + builder + "\""
        );
        // StringBuilder deleteCharAt(int index)
        builder.deleteCharAt(builder.length() - 1); // Deletes the last character '5'
        System.out.println(
            "After deleting the char at the end: \"" + builder + "\""
        );
        builder.append(1995); // Add it back for the next step

        // D. replace() - Replace a section
        System.out.println("\n   --- D. Using replace() ---");
        // StringBuilder replace(int start, int end, String str)
        builder.replace(0, 4, "Python"); // Replaces "Java" with "Python"
        System.out.println(
            "After replacing 'Java' with 'Python': \"" + builder + "\""
        );
        builder.replace(0, 6, "Java"); // Change it back

        // E. reverse() - Reverse the entire content
        System.out.println("\n   --- E. Using reverse() ---");
        System.out.println("Original: \"" + builder + "\"");
        builder.reverse();
        System.out.println("Reversed: \"" + builder + "\"");
        builder.reverse(); // Change it back
        System.out.println("Reversed back to original: \"" + builder + "\"");

        // =================================================================
        // 3. OTHER USEFUL FUNCTIONS
        // =================================================================
        System.out.println("\n--- 3. Other Useful Functions ---");

        // A. length() and capacity()
        System.out.println("\n   --- A. length() vs capacity() ---");
        System.out.println("Current content: \"" + builder + "\"");
        System.out.println(
            "length() is the actual number of characters: " + builder.length()
        );
        System.out.println(
            "capacity() is the total space allocated in memory: " +
                builder.capacity()
        );
        System.out.println("Let's add a lot of text to see capacity grow...");
        builder.append(
            " and is one of the most popular programming languages in the world."
        );
        System.out.println("New length(): " + builder.length());
        System.out.println(
            "New capacity() has automatically increased: " + builder.capacity()
        );

        // B. charAt() and substring()
        System.out.println("\n   --- B. charAt() and substring() ---");
        System.out.println(
            "The character at index 5 is: '" + builder.charAt(5) + "'"
        );
        // String substring(int start, int end)
        String sub = builder.substring(0, 4);
        System.out.println(
            "A substring from index 0 to 4 gives us a new String: \"" +
                sub +
                "\""
        );
        System.out.println(
            "Note: The original StringBuilder is not changed: \"" +
                builder +
                "\""
        );

        // =================================================================
        // 4. CONVERSION
        // =================================================================
        System.out.println("\n--- 4. Conversion back to a String ---");
        System.out.println(
            "After all modifications, we often need a standard String object."
        );
        System.out.println("Action: String finalString = builder.toString();");
        String finalString = builder.toString();
        System.out.println("The final String object is:");
        System.out.println("\"" + finalString + "\"");
        System.out.println(
            "You can now use it like any other immutable String."
        );

        System.out.println(
            "\n### End of the StringBuilder Learning Example! ###"
        );
    }
}
