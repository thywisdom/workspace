package com.examly.entity;

public class Student {
    
    private int id ;
    private String name;
    private long number;
    private char grade;
    private String email;
    private int mark;

    Student(){}

    public Student( int id,String name,long number,char grade,String email,int mark){
        this.id = id;
        this.name = name;
        this.number = number;
        this.grade = grade;
        this.email = email;
        this.mark = mark;
    }

    public int getId() { return id; }
    public String getName() { return name; }
    public long getNumber() { return number;}
    public char getGrade() { return grade;}
    public String getEmail() { return email;}
    public int getMark() { return mark;}

    public void setId(int id) { this.id = id; }
    public void setName(String name) { this.name = name; }
    public void setNumber(long number) { this.number = number;}
    public void setGrade(char grade) { this.grade =  grade;}
    public void setEmail(String email) { this.email = email;}
    public void setMark(int mark) { this.mark = mark;}
}
