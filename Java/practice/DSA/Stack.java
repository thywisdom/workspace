public class Stack{
    static Node top = null;
    static void push(int data){
        Node nn = new Node(data);
        if(top == null)
            top = nn;
        else{
            nn.next = top;
            top = nn;
        }
        
    }

    static void pop(){
        Node x = top;
        top = x.next;
        x.next = null;
    }


    static void display(){
        Node x = top;
        while(x != null){
            System.out.print(x.data+" ");
            x=x.next;
        }
         System.out.println("Over");
    }

    public static void main (String args[]){

            push(10);
            push(11);
            push(12);
            push(13);
            display();
            pop();
            display();
        
    }
}
class Node{
    int data;
    Node next;
    Node(int data){
        this.data = data;
        this.next = null;
    }
}