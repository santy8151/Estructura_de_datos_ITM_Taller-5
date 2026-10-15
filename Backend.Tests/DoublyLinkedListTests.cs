using System.Collections.Generic;
using Backend;
using Xunit;

namespace Backend.Tests;

public class DoublyLinkedListTests
{
    [Fact]
    public void Add_MaintainsAscendingOrder_WithStringColors()
    {
        // Arrange
        var list = new DoublyLinkedList<string>();

        // Act - inserting colors in arbitrary order as stated in assignment
        list.Add("Blanco");
        list.Add("Azul");
        list.Add("Amarillo");
        list.Add("Verde");
        list.Add("Negro");

        // Assert - internal order must be strictly ascending
        var expected = new List<string> { "Amarillo", "Azul", "Blanco", "Negro", "Verde" };
        Assert.Equal(expected, list.ToForwardList());
        Assert.Equal(5, list.Count);
    }

    [Fact]
    public void Add_NumericGenerics_Orders10And2And3Numerically()
    {
        // Arrange: testing generic DoublyLinkedList<int> with 10, 2, 3
        var list = new DoublyLinkedList<int>();

        // Act
        list.Add(10);
        list.Add(2);
        list.Add(3);

        // Assert: must be [2, 3, 10] NOT lexicographical [10, 2, 3]
        var expected = new List<int> { 2, 3, 10 };
        Assert.Equal(expected, list.ToForwardList());
    }

    [Fact]
    public void Add_NaturalStringComparer_OrdersStringNumbersNumerically()
    {
        // Arrange: testing string list with NaturalStringComparer
        var list = new DoublyLinkedList<string>(NaturalStringComparer.Default);

        // Act
        list.Add("10");
        list.Add("2");
        list.Add("3");

        // Assert: numeric strings are sorted naturally as 2, 3, 10
        var expected = new List<string> { "2", "3", "10" };
        Assert.Equal(expected, list.ToForwardList());
    }

    [Fact]
    public void Traversal_ForwardAndBackward_MatchExpectedSequences()
    {
        // Arrange
        var list = new DoublyLinkedList<string>();
        list.Add("Blanco");
        list.Add("Azul");
        list.Add("Amarillo");
        list.Add("Verde");
        list.Add("Negro");

        // Act
        var forward = list.ToForwardList();
        var backward = list.ToBackwardList();

        // Assert
        Assert.Equal(new List<string> { "Amarillo", "Azul", "Blanco", "Negro", "Verde" }, forward);
        Assert.Equal(new List<string> { "Verde", "Negro", "Blanco", "Azul", "Amarillo" }, backward);
    }

    [Fact]
    public void SortDescending_InvertsInternalOrderProperly()
    {
        // Arrange
        var list = new DoublyLinkedList<string>();
        list.Add("Blanco");
        list.Add("Azul");
        list.Add("Amarillo");
        list.Add("Verde");
        list.Add("Negro");

        // Act
        list.SortDescending();

        // Assert - forward traversal must now yield descending order
        var expected = new List<string> { "Verde", "Negro", "Blanco", "Azul", "Amarillo" };
        Assert.Equal(expected, list.ToForwardList());
        Assert.True(list.IsDescending);
        Assert.Equal("Verde", list.Head?.Value);
        Assert.Equal("Amarillo", list.Tail?.Value);
    }

    [Fact]
    public void SortDescending_CalledMultipleTimes_RemainsDescending()
    {
        // Arrange
        var list = new DoublyLinkedList<string>();
        list.Add("Blanco");
        list.Add("Azul");
        list.Add("Amarillo");
        list.Add("Verde");
        list.Add("Negro");

        // Act - call SortDescending three times consecutively
        list.SortDescending();
        list.SortDescending();
        list.SortDescending();

        // Assert - must still be descending, not flipped back to ascending
        var expected = new List<string> { "Verde", "Negro", "Blanco", "Azul", "Amarillo" };
        Assert.Equal(expected, list.ToForwardList());
        Assert.True(list.IsDescending);
    }

    [Fact]
    public void SortAscending_CalledMultipleTimes_RemainsAscending()
    {
        // Arrange
        var list = new DoublyLinkedList<string>();
        list.Add("Blanco");
        list.Add("Azul");
        list.Add("Amarillo");
        list.Add("Verde");
        list.Add("Negro");

        list.SortDescending();

        // Act - call SortAscending multiple times
        list.SortAscending();
        list.SortAscending();

        // Assert - must remain ascending
        var expected = new List<string> { "Amarillo", "Azul", "Blanco", "Negro", "Verde" };
        Assert.Equal(expected, list.ToForwardList());
        Assert.False(list.IsDescending);
    }

    [Fact]
    public void GetModes_SingleMode_MatchesAssignmentExample()
    {
        // Arrange: 1, 2, 3, 3, 2, 5, 6, 6, 6, 3, 6 (6 appears 4 times)
        var list = new DoublyLinkedList<int>();
        int[] input = [1, 2, 3, 3, 2, 5, 6, 6, 6, 3, 6];
        foreach (var num in input)
        {
            list.Add(num);
        }

        // Act
        var (modes, maxFrequency) = list.GetModes();

        // Assert
        Assert.Equal(4, maxFrequency);
        Assert.Single(modes);
        Assert.Equal(6, modes[0]);
    }

    [Fact]
    public void GetModes_MultipleModes_MatchesAssignmentExample()
    {
        // Arrange: 1, 2, 3, 3, 2, 5, 6, 6, 6, 3 (both 3 and 6 appear 3 times)
        var list = new DoublyLinkedList<int>();
        int[] input = [1, 2, 3, 3, 2, 5, 6, 6, 6, 3];
        foreach (var num in input)
        {
            list.Add(num);
        }

        // Act
        var (modes, maxFrequency) = list.GetModes();

        // Assert
        Assert.Equal(3, maxFrequency);
        Assert.Equal(2, modes.Count);
        Assert.Contains(3, modes);
        Assert.Contains(6, modes);
    }

    [Fact]
    public void Exists_ReturnsTrueIfPresent_AndFalseIfNotPresent()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();
        int[] input = [1, 2, 3, 3, 2, 5, 6, 6, 6, 3, 6];
        foreach (var num in input)
        {
            list.Add(num);
        }

        // Act & Assert
        Assert.True(list.Exists(3));
        Assert.False(list.Exists(8));
    }

    [Fact]
    public void RemoveOne_RemovesOnlyFirstOccurrence()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();
        list.Add(3);
        list.Add(3);
        list.Add(3);

        // Act
        bool removed = list.RemoveOne(3);

        // Assert
        Assert.True(removed);
        Assert.Equal(2, list.Count);
        Assert.Equal(new List<int> { 3, 3 }, list.ToForwardList());
    }

    [Fact]
    public void RemoveAll_RemovesAllOccurrences()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();
        list.Add(1);
        list.Add(3);
        list.Add(3);
        list.Add(5);
        list.Add(3);

        // Act
        int removedCount = list.RemoveAll(3);

        // Assert
        Assert.Equal(3, removedCount);
        Assert.Equal(2, list.Count);
        Assert.Equal(new List<int> { 1, 5 }, list.ToForwardList());
        Assert.False(list.Exists(3));
    }

    [Fact]
    public void GetAsteriskChart_FormatsLinesCorrectly()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();
        int[] input = [1, 2, 3, 3, 2, 5, 6, 6, 6, 3];
        foreach (var num in input)
        {
            list.Add(num);
        }

        // Act
        string chart = list.GetAsteriskChart();

        // Assert
        Assert.Contains("1 *", chart);
        Assert.Contains("2 **", chart);
        Assert.Contains("3 ***", chart);
        Assert.Contains("5 *", chart);
        Assert.Contains("6 ***", chart);
    }
}
