using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Backend;

/// <summary>
/// A generic doubly linked list implementation with sorted insertion,
/// traversal in both directions, in-place descending sorting, mode calculation,
/// asterisk frequency charting, and occurrence deletion.
/// </summary>
/// <typeparam name="T">The type of elements in the list, constrained to <see cref="IComparable{T}"/>.</typeparam>
public class DoublyLinkedList<T> : IEnumerable<T> where T : IComparable<T>
{
    private readonly IComparer<T> _comparer;

    /// <summary>
    /// Gets the first node of the list.
    /// </summary>
    public DoubleNode<T>? Head { get; private set; }

    /// <summary>
    /// Gets the last node of the list.
    /// </summary>
    public DoubleNode<T>? Tail { get; private set; }

    /// <summary>
    /// Gets the total number of elements currently stored in the list.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the list is currently ordered in descending order.
    /// </summary>
    public bool IsDescending { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the list is empty.
    /// </summary>
    public bool IsEmpty => Head == null;

    /// <summary>
    /// Initializes a new instance of the <see cref="DoublyLinkedList{T}"/> class.
    /// </summary>
    /// <param name="comparer">An optional custom comparer. If null, <see cref="Comparer{T}.Default"/> is used.</param>
    public DoublyLinkedList(IComparer<T>? comparer = null)
    {
        _comparer = comparer ?? Comparer<T>.Default;
    }

    /// <summary>
    /// Inserts an item into the list maintaining sorted order.
    /// If the list is in ascending mode (default), items are placed in ascending order.
    /// If the list is in descending mode, items are placed in descending order.
    /// Duplicates are permitted.
    /// </summary>
    /// <param name="value">The element to insert.</param>
    public void Add(T value)
    {
        var newNode = new DoubleNode<T>(value);

        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            Count = 1;
            return;
        }

        if (!IsDescending)
        {
            // Ascending insertion: find the first node strictly greater than the new value
            var current = Head;
            while (current != null && _comparer.Compare(current.Value, value) <= 0)
            {
                current = current.Next;
            }

            if (current == null)
            {
                // Insert at the end (Tail)
                Tail!.Next = newNode;
                newNode.Previous = Tail;
                Tail = newNode;
            }
            else if (current == Head)
            {
                // Insert before Head
                newNode.Next = Head;
                Head.Previous = newNode;
                Head = newNode;
            }
            else
            {
                // Insert before current in the middle
                newNode.Previous = current.Previous;
                newNode.Next = current;
                current.Previous!.Next = newNode;
                current.Previous = newNode;
            }
        }
        else
        {
            // Descending insertion: find the first node strictly less than the new value
            var current = Head;
            while (current != null && _comparer.Compare(current.Value, value) >= 0)
            {
                current = current.Next;
            }

            if (current == null)
            {
                // Insert at the end (Tail)
                Tail!.Next = newNode;
                newNode.Previous = Tail;
                Tail = newNode;
            }
            else if (current == Head)
            {
                // Insert before Head
                newNode.Next = Head;
                Head.Previous = newNode;
                Head = newNode;
            }
            else
            {
                // Insert before current in the middle
                newNode.Previous = current.Previous;
                newNode.Next = current;
                current.Previous!.Next = newNode;
                current.Previous = newNode;
            }
        }

        Count++;
    }

    /// <summary>
    /// Returns a list of elements traversed forward from Head to Tail.
    /// </summary>
    /// <returns>A list containing the elements in forward order.</returns>
    public List<T> ToForwardList()
    {
        var list = new List<T>(Count);
        var current = Head;
        while (current != null)
        {
            list.Add(current.Value);
            current = current.Next;
        }
        return list;
    }

    /// <summary>
    /// Returns a list of elements traversed backward from Tail to Head.
    /// </summary>
    /// <returns>A list containing the elements in backward order.</returns>
    public List<T> ToBackwardList()
    {
        var list = new List<T>(Count);
        var current = Tail;
        while (current != null)
        {
            list.Add(current.Value);
            current = current.Previous;
        }
        return list;
    }

    /// <summary>
    /// Changes the internal links of the list to reverse its current order,
    /// sorting it in descending order if it was previously ascending.
    /// This method is idempotent: calling it multiple times leaves the list in descending order.
    /// </summary>
    public void SortDescending()
    {
        // Prevent reversing multiple times if already descending
        if (IsDescending)
        {
            return;
        }

        if (Head == null || Head.Next == null)
        {
            IsDescending = true;
            return;
        }

        var current = Head;
        DoubleNode<T>? temp = null;

        while (current != null)
        {
            temp = current.Previous;
            current.Previous = current.Next;
            current.Next = temp;
            current = current.Previous;
        }

        temp = Head;
        Head = Tail;
        Tail = temp;
        IsDescending = true;
    }

    /// <summary>
    /// Restores the internal links of the list to ascending order if it was sorted descending.
    /// This method is idempotent: calling it multiple times leaves the list in ascending order.
    /// </summary>
    public void SortAscending()
    {
        // Prevent reversing multiple times if already ascending
        if (!IsDescending)
        {
            return;
        }

        if (Head == null || Head.Next == null)
        {
            IsDescending = false;
            return;
        }

        var current = Head;
        DoubleNode<T>? temp = null;

        while (current != null)
        {
            temp = current.Previous;
            current.Previous = current.Next;
            current.Next = temp;
            current = current.Previous;
        }

        temp = Head;
        Head = Tail;
        Tail = temp;
        IsDescending = false;
    }

    /// <summary>
    /// Finds the mode(s) of the elements currently in the list and the maximum frequency.
    /// Supports multi-modal distributions.
    /// </summary>
    /// <returns>A tuple containing the list of modes and their occurrence count.</returns>
    public (List<T> Modes, int MaxFrequency) GetModes()
    {
        if (IsEmpty)
        {
            return (new List<T>(), 0);
        }

        var frequencyMap = new Dictionary<T, int>();
        var current = Head;
        while (current != null)
        {
            if (frequencyMap.TryGetValue(current.Value, out int count))
            {
                frequencyMap[current.Value] = count + 1;
            }
            else
            {
                frequencyMap[current.Value] = 1;
            }
            current = current.Next;
        }

        int maxFreq = 0;
        foreach (var pair in frequencyMap)
        {
            if (pair.Value > maxFreq)
            {
                maxFreq = pair.Value;
            }
        }

        var modes = new List<T>();
        foreach (var pair in frequencyMap)
        {
            if (pair.Value == maxFreq)
            {
                modes.Add(pair.Key);
            }
        }

        // Sort modes to provide consistent deterministic display
        modes.Sort(_comparer);

        return (modes, maxFreq);
    }

    /// <summary>
    /// Returns the distinct elements and their occurrence counts in list appearance order.
    /// </summary>
    /// <returns>List of key-value pairs of element and frequency count.</returns>
    public List<(T Value, int Count)> GetFrequencies()
    {
        var frequencyMap = new Dictionary<T, int>();
        var orderedKeys = new List<T>();

        var current = Head;
        while (current != null)
        {
            if (frequencyMap.TryGetValue(current.Value, out int count))
            {
                frequencyMap[current.Value] = count + 1;
            }
            else
            {
                frequencyMap[current.Value] = 1;
                orderedKeys.Add(current.Value);
            }
            current = current.Next;
        }

        var result = new List<(T Value, int Count)>(orderedKeys.Count);
        foreach (var key in orderedKeys)
        {
            result.Add((key, frequencyMap[key]));
        }

        return result;
    }

    /// <summary>
    /// Generates the asterisk frequency chart matching the format required by the specification.
    /// Example:
    /// 1 *
    /// 2 *
    /// 3 ***
    /// 5 *
    /// 6 ***
    /// </summary>
    /// <returns>Formatted chart string.</returns>
    public string GetAsteriskChart()
    {
        var freqs = GetFrequencies();
        if (freqs.Count == 0)
        {
            return string.Empty;
        }

        var sb = new StringBuilder();
        for (int i = 0; i < freqs.Count; i++)
        {
            var item = freqs[i];
            sb.Append($"{item.Value} {new string('*', item.Count)}");
            if (i < freqs.Count - 1)
            {
                sb.AppendLine();
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// Checks whether an element exists at least once in the list.
    /// </summary>
    /// <param name="value">The element to search for.</param>
    /// <returns><c>true</c> if the element exists; otherwise, <c>false</c>.</returns>
    public bool Exists(T value)
    {
        var current = Head;
        while (current != null)
        {
            if (_comparer.Compare(current.Value, value) == 0)
            {
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    /// <summary>
    /// Removes the first occurrence of the specified element from the list.
    /// </summary>
    /// <param name="value">The element to delete.</param>
    /// <returns><c>true</c> if an element was found and removed; otherwise, <c>false</c>.</returns>
    public bool RemoveOne(T value)
    {
        var current = Head;
        while (current != null)
        {
            if (_comparer.Compare(current.Value, value) == 0)
            {
                UnlinkNode(current);
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    /// <summary>
    /// Removes all occurrences of the specified element from the list.
    /// </summary>
    /// <param name="value">The element to delete.</param>
    /// <returns>The total number of occurrences removed.</returns>
    public int RemoveAll(T value)
    {
        int removedCount = 0;
        var current = Head;
        while (current != null)
        {
            var next = current.Next;
            if (_comparer.Compare(current.Value, value) == 0)
            {
                UnlinkNode(current);
                removedCount++;
            }
            current = next;
        }

        return removedCount;
    }

    /// <summary>
    /// Clears all elements from the doubly linked list.
    /// </summary>
    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
        IsDescending = false;
    }

    /// <summary>
    /// Unlinks a specific node from the doubly linked chain and updates Head, Tail, and Count.
    /// </summary>
    /// <param name="node">The node to detach.</param>
    private void UnlinkNode(DoubleNode<T> node)
    {
        if (node.Previous != null)
        {
            node.Previous.Next = node.Next;
        }
        else
        {
            Head = node.Next;
        }

        if (node.Next != null)
        {
            node.Next.Previous = node.Previous;
        }
        else
        {
            Tail = node.Previous;
        }

        node.Next = null;
        node.Previous = null;
        Count--;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the doubly linked list from Head to Tail.
    /// </summary>
    public IEnumerator<T> GetEnumerator()
    {
        var current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
