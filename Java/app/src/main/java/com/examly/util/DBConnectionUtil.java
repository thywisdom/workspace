package com.examly.util;

import java.sql.*;

public class DBConnectionUtil {

    static   String url = "jdbc:mysql://localhost:3306/school";
    static   String usr = "root";
    static   String pass = "suman";
        

    public static Connection getConnection() {
        
        try{
             return DriverManager.getConnection(url,usr,pass);

        }catch(Exception e){

           System.out.println("Connection Failed");
           return null;
        }
    }
    
}
