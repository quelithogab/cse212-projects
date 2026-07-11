using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities: Low (1), High (5), Medium (3).
    // Expected Result: Dequeue should return items in order of highest priority first: "High", then "Medium", then "Low".
    // Defect(s) Found: The loop termination condition index < _queue.Count - 1 skips checking the last item in the queue entirely. Also, items are never actually removed from the list, causing Dequeue to repeatedly return the same value.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items where some share the same highest priority: ItemA (5), ItemB (5), ItemC (2).
    // Expected Result: Due to the FIFO fallback rule, the item closest to the front of the queue (ItemA) should be removed first.
    // Defect(s) Found: The comparison used >= instead of >. This causes the queue to select the *last* item with the matching high priority (ItemB) rather than the *first* one (ItemA), violating the FIFO fallback rule.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("ItemA", 5);
        priorityQueue.Enqueue("ItemB", 5);
        priorityQueue.Enqueue("ItemC", 2);

        Assert.AreEqual("ItemA", priorityQueue.Dequeue());
        Assert.AreEqual("ItemB", priorityQueue.Dequeue());
        Assert.AreEqual("ItemC", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to Dequeue from a brand new, empty queue.
    // Expected Result: Throws an InvalidOperationException with the exact error message: "The queue is empty."
    // Defect(s) Found: None. The safety check at the top of Dequeue works correctly.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception type caught: {e.GetType()} - {e.Message}");
        }
    }
}