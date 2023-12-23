using System;

// The Node class representing a node in a binary tree
// T value to be stored in the node
public class Node<T>{
    public T Value{get; set; }
    public Node<T>? Left{get; set; }
    public Node<T>? Right{get; set; }
    // Left and Right are nullable reference types


// Constructor for initialising a new instance of the Node class with a given value
public Node(T Value){
    this.Value = Value;
    Right = null;
    Left = null;
}

}