class stringbufferc {
    public static void main(String[] args){

        StringBuffer a =new StringBuffer("suman");
         StringBuffer b =new StringBuffer();


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
