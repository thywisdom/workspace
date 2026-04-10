import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;
import java.sql.ResultSet;
//import java.sql.PreparedStatemant;

class SQLConnect{

    static void displayRecords(Connection conn) throws SQLException{

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

    static void InsertValue (Connection conn ,int id,  String name, String email ) throws SQLException{

        String exp = "Insert into users Values ('"+id+"', '"+name+"','"+email+"')";

        
            Statement stmt = conn.createStatement();
            int RowAffected = stmt.executeUpdate(exp);

            System.out.println(RowAffected + " Rows affected ");
        
    }

    public static void main(String arg[]){

        String url = "jdbc:mysql://localhost:3306/testdb";
        String usr = "root";
        String pass = "";

        try{
            //Class.forName("com.mysql.cj.jdbc.Driver");

            Connection conn = DriverManager.getConnection(url,usr,pass);
            System.out.println("Connected to 'testdb' database Successfully");

            InsertValue(conn,0004,"Sakthi","sakthisuman2002@gmail.com");
            displayRecords(conn);

        }catch(Exception e){
            e.printStackTrace();
        }
    }
}