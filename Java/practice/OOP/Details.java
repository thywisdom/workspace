class Details{
    String name = "someone";
    int ID = 0000;
    long phone = 000000000;
    
    void setDetails(String s){
        name = s;
    }
     void setDetails(int w){
        ID = w; 
    }
     void setDetails(long v){
        phone = v;
    }

    void display (){
        System.out.println(name);
        System.out.println(ID);
        System.out.println(phone);
    }

    public static void main ( String[]  args){
        
        Details a = new Details();
        a.display();

        a.name = "suman";
        a.ID = 4022;
        a.phone = 915946880;

        
        a.setDetails(a.name);
        a.setDetails(a.ID);
        a.setDetails(a.phone);
        a.display();
    }

}