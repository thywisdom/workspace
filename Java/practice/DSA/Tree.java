public class Tree{

  static void insert(Node root , int data){
    if (root == null) {
      Node nn = new Node(data);
      root = nn;
      return root;
    }
    if(data<root.data){
    return  root.left = insert(root.left,data);
    }
    else if (data>root.data) {
    return  root.right=insert(root.right,data);
    }
  }

  static Node delete(Node root, int data){
    
    if(root == node){
      return null;
    }
    if (data<root.data) {
      root.left=delete(root.left,data);
    }
    else if(data>root.data){
      root.right=delete(root.right,data);
    }
    else{
      if (root.left==null) {
        return root.right;
      }
      else if (root.right==null) {
        return root.left;
      }
    else{
      int min=minimum(root.right);
      root.data=min;
      root.right=delete(root.right,min);
     }
    }
  }

  public int minimum(Node node) {
        while (node.left != null) {
            node = node.left;
        }
        return node.val;
    }

  static void inorder (Node root){
        if (root != null) {
          inorder(root.left);
          System.out.println(root.data+" ");
          inorder(root.right);
        }
  } 
  
  static void preorder (Node root){
        if (root != null) {
          System.out.println(root.data+" ");
          preorder(root.left);
          preorder(root.right);
        }
  }
  
  static void postorder (Node root){
        if (root != null) {
          postorder(root.left);
          postorder(root.right);
          System.out.println(root.data+" ");
        }
  }
  

    public static void main(String[] args) {
    
      Node root = null;
      insert(root,75);
   
    }
}

class Node{
      
      int data;
      Node left;
      Node right;
  
      Node(int data){
        this.data=data;
        this.left=null;
        this.right=null;
      }
}  
