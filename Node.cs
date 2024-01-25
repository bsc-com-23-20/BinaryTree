using System;

public class Node<T>{
    public T Value{get; set; }
    public Node<T>? Left{get; set; }
    public Node<T>? Right{get; set; }
   
public Node(T Value){
    this.Value = Value;
    Right = null;
    Left = null;
}

}