public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: Enqueue five names of famous scientists and dequeue: Nikola Tesla (1), Charles Darwin (2), Isaac Newton (3), Marie Curie (4), Albert Einstein (5)
        // Expected Result: Run the code and the dequeue should return the name sequence according to the priority
        Console.WriteLine("\nTest 1");
        priorityQueue.Enqueue("Albert Einstein", 5); //High priority
        priorityQueue.Enqueue("Marie Curie", 4);
        priorityQueue.Enqueue("Isaac Newton", 3);
        priorityQueue.Enqueue("Charles Darwin", 2);
        priorityQueue.Enqueue("Nikola Tesla", 1); //Low priority
        Console.WriteLine(priorityQueue);
        Console.WriteLine(priorityQueue.Dequeue()); // Should print "Albert Einstein"
        Console.WriteLine(priorityQueue.Dequeue()); // Should print "Marie Curie"
        Console.WriteLine(priorityQueue.Dequeue()); // Should print "Isaac Newton"
        Console.WriteLine(priorityQueue.Dequeue()); // Should print "Charles Darwin"
        Console.WriteLine(priorityQueue.Dequeue()); // Should print "Nikola Tesla"
        // Defect(s) Found: It is only displaying the high priority name, in this case, Albert Einstein

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Enqueue five names of famous brazilian teachers: Paulo Coelho (1), Pasquale Cipro Neto (2), Darcy Ribeiro (3), Anisio Teixeira (4), Débora Seabra (5)
        // Expected Result: Run the code and the dequeue should return the name sequence according to the priority
        Console.WriteLine("\nTest 2");

        priorityQueue.Enqueue("Débora Seabra", 5); //High priority
        priorityQueue.Enqueue("Anisio Teixeira", 4);
        priorityQueue.Enqueue("Darcy Ribeiro", 3);
        priorityQueue.Enqueue("Pasquale Cipro Neto", 2);
        priorityQueue.Enqueue("Paulo Coelho", 1); //Low priority
        Console.WriteLine(priorityQueue);
        Console.WriteLine(priorityQueue.Dequeue()); // Should print "Débora Seabra"
        Console.WriteLine(priorityQueue.Dequeue()); // Should print "Anisio Teixeira"
        Console.WriteLine(priorityQueue.Dequeue()); // Should print "Darcy Ribeiro"
        Console.WriteLine(priorityQueue.Dequeue()); // Should print "Pasquale Cipro Neto"
        Console.WriteLine(priorityQueue.Dequeue()); // Should print "Paulo Coelho"

        // Defect(s) Found: It is only displaying the high priority name, in this case, Débora Seabra

        Console.WriteLine("---------");

        // Add more Test Cases As Needed Below
    }
}
