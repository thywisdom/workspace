
public class Linkedlst{
    static Node head = null;

    static void insertBeg( int data){
        Node nn = new Node(data);
        if(head == null)
            head = nn;
        else{
            nn.next= head;
            head = nn;
        }
    }   
    static void deleteBeg(){
        Node x = head;
        head = head.next;
        x.next = null;
    } 
    
    static void insertLast( int data){
        if(head == null)
            insertBeg(data);
        else{
            Node x = head;
        Node nn = new Node(data);
        while(x.next!=null){
            x=x.next;
        }
        x.next=nn;
    }
    }
     static void deleteLast(){
        if(head.next == null){
            head=null;
            return;
        }
        else{
            Node x = head;
            while(x.next.next!=null){
                x=x.next;
            }
            x.next=null;
        }
    } 
    static void insertMid(int data , int pos){
        Node x = head;
        Node nn = new Node(data);
        if(head == null)
            insertBeg(data);
        else if(x.next == null){          
            x.next=nn;
        }
        else{
        x = head;
        int c = 0 ;
        while(c<pos-1){
                x=x.next;
                c++;
            }
          x.next=nn;
        }
    }
    static void deleteMid( int pos){
        if(head == null)
            return;
        Node x = head;
        int c =0;
        if(pos==0)
        {
            deleteBeg();
            return;
        }
         while(c<pos-1){
                x=x.next;
                c++;
                if(x==null){
                    return;
                }
        }
    if(x.next.next==null)
        x.next=null;
    else{
        Node y = x.next;
        x.next=x.next.next;
        y.next=null;
        return;
        }   
    }
    static void display(){
        Node x = head;
        while(x != null){
            System.out.print(x.data+" ");
            x=x.next;
        }

        System.out.println("over");
    }

    static void midElement(){   
        if(head == null)
            return;
        Node i = head;
        Node j = head;
        while(i.next == null || i.next !=null){
            if(j.next == null || j.next.next == null){
                System.out.println("Mid element is: "+i.data);
                return;
            }
            i=i.next;
            j=j.next.next;
        }
    }

    static void maxValue(){
        if(head == null)
            return;
        int  max = head.data;
        Node i = head;

        while(i.next != null){
            if(i.data>max)
                max = i.data;
            if(i.next.data > max)
                max = i.next.data;
            i=i.next;
        }

        System.out.println("the Max value "+max);
    }

    static void reverseList(){
        if(head == null)
            return;
        Node pre = null;
        Node fr = head, c = head;
        while(fr != null){
            fr = fr.next;
            c.next = pre;
            pre = c; 
            c = fr;          
        }      
        head = pre;
        display();
    }   

    static void isCyclic(){
        if(head == null)
                return;
        Node i = head;
        Node j = head;
        while(j.next !=null && j.next.next != null){
            i=i.next;
            j=j.next.next;
             if(j == i){
                System.out.println("It is a Cyclic List");

    static void insertBeg( int data){
        Node nn = new Node(data);
        if(head == null)
            head = nn;
        else{
            nn.next= head;
            head = nn;
        }
    }   
    static void deleteBeg(){
        Node x = head;
        head = head.next;
        x.next = null;
    } 
    
    static void insertLast( int data){
        if(head == null)
            insertBeg(data);
        else{
            Node x = head;
        Node nn = new Node(data);
        while(x.next!=null){
            x=x.next;
        }
        x.next=nn;
    }
    }
     static void deleteLast(){
        if(head.next == null){
            head=null;
            return;
        }
        else{
            Node x = head;
            while(x.next.next!=null){
                x=x.next;
            }
            x.next=null;
        }
