import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.Statement;
// import java.sql.PreparedStatemant;

public class Main{

    static void display(Connection conn) throws SQLException{

       String exp = "Select * from users";

        Statement stmt = conn.createStatement();
        ResultSet rs = stmt.executeQuery(exp);

        while(rs.next()){
            int id = rs.getInt("ID");
            String name = rs.getString("name");
            String email = rs.getString("email");

            System.out.println(id+" "+"name is"+ name + " and their email is "+email);

        }
    }

    
    public static void main(String arg[]){

        String url = "jdbc:mysql://localhost:3306/testdb";
        String usr = "root";
        String pass = "";


        try{

        Connection conn = DriverManager.getConnection(url,usr,pass);
        System.out.println("Database connectoion established ");

        display(conn);
        }

        catch(Exception e){

            e.printStackTrace();
            System.out.println("Either Database doesnt Exits or Container nor running");

        }
        
    }
}