import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Iterator;

/**
 * This class demonstrates the core concepts and functionalities of the ArrayList in Java.
 * An ArrayList is a resizable array, which can be found in the java.util package.
 * It provides dynamic arrays, meaning it can grow or shrink in size as needed.
 *
 * Key Characteristics of ArrayList:
 * - Implements the List interface.
 * - Allows duplicate elements.
 * - Maintains insertion order.
 * - Is not synchronized (not thread-safe by default).
 * - Allows random access because it works on an index basis.
 * - Manipulation is slower than LinkedList because a lot of shifting needs to occur if any element is removed from the array list.
 */
class ArrayListss {

    public static void main(String[] args) {
        //================================================================
        // 1. DECLARATION AND INITIALIZATION
        //================================================================
        // An ArrayList is created to store elements of a specific type. Here, it's String.
        // The angle brackets <> contain the type of objects the list will hold (Generics).
        System.out.println("--- 1. Declaration and Initialization ---");
        ArrayList<String> list = new ArrayList<String>();
        System.out.println("An empty ArrayList has been created: " + list);
        System.out.println("Initial size: " + list.size());
        System.out.println();

        //================================================================
        // 2. ADDING ELEMENTS
        //================================================================
        // The .add() method appends elements to the end of the list.
        // ArrayList allows duplicate elements ("second word" is added twice).
        System.out.println("--- 2. Adding Elements ---");
        list.add("Suman");
        list.add("first word");
        list.add("second word");
        list.add("2"); // This is a String "2", not an integer 2.
        list.add("second word"); // Adding a duplicate element.

        System.out.println("List after adding elements: " + list);
        System.out.println("Current size: " + list.size());
        System.out.println();

        //================================================================
        // 3. REMOVING ELEMENTS
        //================================================================
        // Elements can be removed by their index or by their value.
        System.out.println("--- 3. Removing Elements ---");

        // .remove(index): Removes the element at the specified position (0-based).
        // Removing the element at index 3, which is "2".
        list.remove(3);
        System.out.println("List after removing element at index 3: " + list);

        // .remove(Object): Removes the first occurrence of the specified element.
        list.remove("first word");
        System.out.println(
            "List after removing the object 'first word': " + list
        );
        System.out.println();

        //================================================================
        // 4. ACCESSING ELEMENTS
        //================================================================
        // The .get(index) method retrieves the element at a specific index.
        System.out.println("--- 4. Accessing Elements ---");
        String name = list.get(0); // Accessing the first element.
        System.out.println("Element at index 0 is: '" + name + "'");
        int lengthOfName = name.length();
        System.out.println(
            "Length of the string '" + name + "' is: " + lengthOfName
        );
        System.out.println();

        //================================================================
        // 5. SEARCHING FOR ELEMENTS
        //================================================================
        System.out.println("--- 5. Searching for Elements ---");

        // .contains(Object): Returns true if the list contains the specified element.
        boolean hasSuman = list.contains("Suman");
        System.out.println("Does the list contain 'Suman'? " + hasSuman);

        boolean hasMissing = list.contains("Missing Element");
        System.out.println(
            "Does the list contain 'Missing Element'? " + hasMissing
        );

        // .indexOf(Object): Returns the index of the first occurrence of the element.
        // Returns -1 if the element is not found.
        int firstIndex = list.indexOf("second word");
        System.out.println("Index of the first 'second word': " + firstIndex);

        // .lastIndexOf(Object): Returns the index of the last occurrence of the element.
        int lastIndex = list.lastIndexOf("second word");
        System.out.println("Index of the last 'second word': " + lastIndex);
        System.out.println();

        //================================================================
        // 6. ITERATING THROUGH THE LIST
        //================================================================
        // An Iterator is an object that enables you to traverse through a collection.
        System.out.println("--- 6. Iterating with an Iterator ---");
        Iterator<String> var = list.iterator();

        System.out.print("Elements from iterator: ");
        while (var.hasNext()) {
            // .hasNext() checks if there is a next element.
            System.out.print(var.next() + " | "); // .next() moves to the next element and returns it.
        }
        System.out.println("\n");

        //================================================================
        // 7. CONVERTING TO AN ARRAY
        //================================================================
        // The .toArray() method converts the ArrayList into a standard Java array of Objects.
        System.out.println("--- 7. Converting to an Array ---");
        Object[] arr = list.toArray();

        // Arrays.toString() is a utility to print the contents of an array.
        System.out.println(
            "Array representation of the list: " + Arrays.toString(arr)
        );
        System.out.println();

        //================================================================
        // 8. CLEARING THE LIST
        //================================================================
        // The .clear() method removes all elements from the list, making it empty.
        System.out.println("--- 8. Clearing the List ---");
        System.out.println("List before clearing: " + list);
        list.clear();
        System.out.println("List after clearing: " + list);

        // .isEmpty() is a convenient way to check if the list has any elements.
        if (list.isEmpty()) {
            // Equivalent to checking if list.size() == 0
            System.out.println("The list is now empty.");
        }
        System.out.println();
    }
}
