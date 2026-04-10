package com.examly.service;

import java.sql.*;
import com.examly.entity.Student;


import  com.examly.util.DBConnectionUtil;

public class StudentService {

    public static void DBcheck( ){
        try(Connection con = DBConnectionUtil.getConnection()){
            System.out.println("Databse Connected Successfully ...");
        }catch(SQLException e){
            System.out.println("Databse Connected Failed");
        }
    }

    public static void addStudent(Student s){

         try(Connection con = DBConnectionUtil.getConnection()){
            
            String query = "Insert into student values (?,?,?,?,?,?)";

            PreparedStatement sp = con.prepareStatement(query);

            sp.setInt(1, s.getId());
            sp.setString(2, s.getName());
            sp.setLong(3, s.getNumber());
            sp.setString(4, ""+s.getGrade());
            sp.setString(5, s.getEmail());
            sp.setInt(6, s.getMark());

            int row = sp.executeUpdate();

            System.out.println("Data Updated . "+row+" rows changed !");

        }catch(SQLException e){
            System.out.println("Data didnt get added . Some problem Occurred");
            //e.printStackTrace();
        }
    }

      public static void showStudents(){

         try(Connection con = DBConnectionUtil.getConnection()){
            
            String query = "Select * from student";

            PreparedStatement sp = con.prepareStatement(query);

            ResultSet rs  = sp.executeQuery();

            while (rs.next()) {
                 System.out.println( 
                    rs.getInt("id")+" | "+
                    rs.getString("name")+" | "+
                    rs.getLong("number")+" | "+
                    rs.getString("grade")+" | "+
                    rs.getString("email")+" | "+
                    rs.getInt("mark")
                );
            }
           

        }catch(SQLException e){
            System.out.println("Data didnt get Retrieved. Some problem Occurred");
            //e.printStackTrace();
        }
    }


}