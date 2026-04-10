import java.util.HashMap;
import java.util.Map; // Import Map interface for good practice

/**
 * This class is a hands-on tutorial for learning Java's HashMap.
 * Each step is printed to the console to make it easy to follow.
 */
public class HashMapLearning {

    public static void main(String[] args) {
        System.out.println("### Welcome to the HashMap Learning Example! ###");

        // =================================================================
        // 1. DECLARATION
        // =================================================================
        System.out.println("\n--- 1. Declaration ---");
        System.out.println("We declare a HashMap. It will store Country (String) as the key and Capital City (String) as the value.");
        // The syntax is: HashMap<KeyType, ValueType> variableName = new HashMap<>();
        HashMap<String, String> capitals = new HashMap<>();
        System.out.println("An empty HashMap has been created!");
        System.out.println("Is the map empty? " + capitals.isEmpty());
        System.out.println("Current HashMap state: " + capitals);


        // =================================================================
        // 2. ESSENTIAL MANIPULATIONS (put, get, remove)
        // =================================================================
        System.out.println("\n--- 2. Essential Manipulations ---");

        // A. put() - Adding key-value pairs
        System.out.println("\n   --- A. Using put() to add elements ---");
        capitals.put("USA", "Washington D.C.");
        capitals.put("Japan", "Tokyo");
        capitals.put("France", "Paris");
        System.out.println("Added 3 key-value pairs.");
        System.out.println("Current HashMap state: " + capitals);

        // put() can also UPDATE the value for an existing key
        System.out.println("\n   --- Using put() to update an existing key ---");
        System.out.println("The key 'Japan' already exists. Let's update its value.");
        // The old value "Tokyo" will be replaced.
        capitals.put("Japan", "Kyoto (Old Capital)");
        System.out.println("Updated the value for key 'Japan'.");
        System.out.println("Current HashMap state: " + capitals);
        // Let's fix it back
        capitals.put("Japan", "Tokyo");


        // B. get() - Retrieving a value using its key
        System.out.println("\n   --- B. Using get() to retrieve a value ---");
        String capitalOfFrance = capitals.get("France");
        System.out.println("Action: capitals.get(\"France\")");
        System.out.println("Result: The capital of France is " + capitalOfFrance);

        // What happens if the key doesn't exist?
        System.out.println("\n   --- Using get() with a non-existent key ---");
        String capitalOfGermany = capitals.get("Germany");
        System.out.println("Action: capitals.get(\"Germany\")");
        System.out.println("Result: The capital of Germany is " + capitalOfGermany + " (null because the key was not found)");


        // C. remove() - Deleting a key-value pair
        System.out.println("\n   --- C. Using remove() to delete a pair ---");
        System.out.println("Action: capitals.remove(\"France\")");
        capitals.remove("France");
        System.out.println("The 'France' entry has been removed.");
        System.out.println("Current HashMap state: " + capitals);


        // =================================================================
        // 3. OTHER USEFUL BUILT-IN FUNCTIONS
        // =================================================================
        System.out.println("\n--- 3. Other Useful Built-in Functions ---");

        // A. containsKey() - Check if a key exists
        System.out.println("\n   --- A. Using containsKey() ---");
        boolean hasUsa = capitals.containsKey("USA");
        boolean hasFrance = capitals.containsKey("France");
        System.out.println("Does the map contain the key 'USA'? " + hasUsa);
        System.out.println("Does the map contain the key 'France'? " + hasFrance);

        // B. containsValue() - Check if a value exists
        System.out.println("\n   --- B. Using containsValue() ---");
        boolean hasTokyo = capitals.containsValue("Tokyo");
        boolean hasParis = capitals.containsValue("Paris");
        System.out.println("Does the map contain the value 'Tokyo'? " + hasTokyo);
        System.out.println("Does the map contain the value 'Paris'? " + hasParis);

        // C. size() - Get the number of key-value pairs
        System.out.println("\n   --- C. Using size() ---");
        int mapSize = capitals.size();
        System.out.println("The number of key-value pairs in the map is: " + mapSize);


        // =================================================================
        // 4. ITERATING (LOOPING) OVER A HASHMAP
        // =================================================================
        System.out.println("\n--- 4. Iterating over the HashMap ---");
        System.out.println("Let's add a few more capitals for a better example.");
        capitals.put("India", "New Delhi");
        capitals.put("United Kingdom", "London");
        System.out.println("Current HashMap state: " + capitals);

        // A. Iterating over Keys using keySet()
        System.out.println("\n   --- A. Iterating over just the keys using keySet() ---");
        for (String country : capitals.keySet()) {
            System.out.println("Found Country (Key): " + country);
        }

        // B. Iterating over Values using values()
        System.out.println("\n   --- B. Iterating over just the values using values() ---");
        for (String capital : capitals.values()) {
            System.out.println("Found Capital (Value): " + capital);
        }

        // C. Iterating over Key-Value Pairs using entrySet() - MOST EFFICIENT
        System.out.println("\n   --- C. Iterating over keys and values using entrySet() ---");
        System.out.println("(This is the most efficient way to loop if you need both the key and value)");
        for (Map.Entry<String, String> entry : capitals.entrySet()) {
            String country = entry.getKey();
            String capital = entry.getValue();
            System.out.println("Entry: " + country + " -> " + capital);
        }


        // =================================================================
        // 5. CLEARING THE HASHMAP
        // =================================================================
        System.out.println("\n--- 5. Clearing the HashMap ---");
        System.out.println("Action: capitals.clear()");
        capitals.clear();
        System.out.println("The map has been cleared.");
        System.out.println("Final size of map: " + capitals.size());
        System.out.println("Is the map empty now? " + capitals.isEmpty());
        System.out.println("Final HashMap state: " + capitals);

        System.out.println("\n### End of the HashMap Learning Example! ###");
    }
}
