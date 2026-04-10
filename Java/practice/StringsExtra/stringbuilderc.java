class stringbuilderc {
    public static void main(String[] args){

        StringBuilder a =new StringBuilder("suman");
         StringBuilder b =new StringBuilder();


            System.out.println(a.capacity());
        System.out.println(b.capacity());

           System.out.println(a);
             System.out.println(b);

        b.append("  students");
         System.out.println(b);

        a.append(" Ezhumalai");
        System.out.println(a);


        a.append(b);
        System.out. println(a);

        System.out.println(a.capacity());
        System.out.println(a.length());

        a.trimToSize();
        System.out.println(a.capacity());

        System.out.println(a.delete(0,6));
    }
}
