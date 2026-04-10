// import java.sql.PreparedStatement;
// import java.sql.DriverManager;
// import java.sql.ResultSet;
// import java.sql.SQLException;
// import java.sql.Connection;

import java.sql.*;

class DBConnect{

    static void display(Connection con) throws SQLException{

        String query = "Select * from Overall";

        PreparedStatement sp = con.prepareStatement(query);
        ResultSet rs = sp.executeQuery();

        while(rs.next()){
            System.out.println(
                rs.getInt("id")+" | "+
                rs.getString("name")+" | "+
                rs.getString("mail")+" | "+
                rs.getInt("score")
            );
        }
    }

     static void Insert (Connection con,int id, String name , String mail, String city, int score) 
                         throws SQLException    { 

        String query = "Insert into Overall values ( ?,?,?,?,?)";

        PreparedStatement sp = con.prepareStatement(query);
        sp.setInt(1, id);
        sp.setString(2, name);
        sp.setString(3, mail);
        sp.setString(4, city);
        sp.setInt(5, score);
        
        int row = sp.executeUpdate();

        //System.out.println("Inserted " + row);
                
    }

    static void Update (Connection con, int id, int newScore) 
                         throws SQLException    { 

        String query = "Update Overall set score = ? where id = ?";

        PreparedStatement sp = con.prepareStatement(query);
        sp.setInt(1, newScore);
        sp.setInt(2, id);

        int row = sp.executeUpdate();
    
    }


    public static void main(String args[]){

        String url ="jdbc:mysql://localhost/practice";
        String usr = "root";
        String pass = "";

        try{
            Connection con = DriverManager.getConnection(url,usr,pass);

            System.out.println("Databse connected - Practice ");
            System.out.println();

            //Insert(con,10,"Sakthi","Sakthisuman@gmail.com","Puducherry",99);

            Update(con,10,86);
            display(con);

        }catch(SQLException e){
            e.printStackTrace();
        }

    }


}