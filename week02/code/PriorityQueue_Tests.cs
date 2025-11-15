using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        //test that priority person comes first in queue
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("jim", 1);
        priorityQueue.Enqueue("joe", 3);
        priorityQueue.Enqueue("jake", 4);
        priorityQueue.Enqueue("joe", 2);
        Assert.AreEqual(priorityQueue.Dequeue(), "jake");
    }

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        //test order of queue is correct based on priority
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("jim", 1);
        priorityQueue.Enqueue("joe", 3);
        priorityQueue.Enqueue("jake", 4);
        priorityQueue.Enqueue("jared", 2);
        string[] order = {"jake", "joe", "jared", "jim"};
        foreach (var item in order)
        {
            Assert.AreEqual(item, priorityQueue.Dequeue());
        }

    }

    // Add more test cases as needed below.
}