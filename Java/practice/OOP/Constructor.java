class User{
    private String name;
    private int ID;
    private long phone;

    public User(String name , int ID , long phone){
        this.name=name; //this holds the refernceof the object that initialized fot the repective class
        this.ID=ID;
        this.phone=phone;
    }

    String getName(){
        return name;
    }
    int getID() {
        return ID;
    }
    long getPhone(){
        return phone;
    }

}

class Constructor{
    public static void main(String[] args){

        User a = new User("Suman",02,123456789);


        System.out.println(a.getName()+" "+a.getID()+" "+a.getPhone());


    }
}
