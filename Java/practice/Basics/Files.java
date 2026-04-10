import java.io.FileOutputStream;
import java.io.File;
import java.io.IOException;

public class Files {
  public static void main(String[] args) {
    // resource is opened inside try()
    try (File output  = new File("filename.txt");) {
        if(output.canWrite()) System.out.println(" file is writable !");
    
      //output.write("Hello".getBytes());
      // no need to call close() here
      System.out.println("Successfully wrote to the file.");
    } catch (IOException e) {
      System.out.println("Error writing file.");
    }

  }
}