namespace Backend;

/// <summary>
/// Represents a node in a doubly linked list.
/// </summary>
/// <typeparam name="T">The data type stored inside the node.</typeparam>
public class DoubleNode<T>
{
    /// <summary>
    /// Gets or sets the data value stored in this node.
    /// </summary>
    public T Value { get; set; }

    /// <summary>
    /// Gets or sets the link to the next node in the list.
    /// </summary>
    public DoubleNode<T>? Next { get; set; }

    /// <summary>
    /// Gets or sets the link to the previous node in the list.
    /// </summary>
    public DoubleNode<T>? Previous { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DoubleNode{T}"/> class.
    /// </summary>
    /// <param name="value">The data value for the node.</param>
    public DoubleNode(T value)
    {
        Value = value;
    }
}
