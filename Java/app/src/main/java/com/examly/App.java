package com.examly;

import com.examly.service.StudentService;
import com.examly.entity.Student;
/**
 * Hello world!
 *
 */
public class App 
{
    public static void main(String[] args) {
        
        StudentService.DBcheck();

        Student s1 = new Student(7,"Suman",915946880,'B',"witnesstowidom@gmail.com",75);
        Student s2 = new Student(8,"Sakthi",915544880,'A',"sakthisuman10@gmail.com",80);

       //StudentService.addStudent(s2);

       StudentService.showStudents();
       
    }
}
