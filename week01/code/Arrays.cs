using System;
using System.Collections.Generic;

public static class Arrays
{
    public static double[] MultiplesOf(double startingNumber, int numberOfMultiples)
    {
        // Step 1: Create an array with the requested number of multiples.
        double[] multiples = new double[numberOfMultiples];

        // Step 2: Use a loop to go through each position in the array.
        for (int i = 0; i < numberOfMultiples; i++)
        {
            // Step 3: Calculate each multiple by multiplying the starting number
            // by the current position plus one.
            multiples[i] = startingNumber * (i + 1);
        }

        // Step 4: Return the array containing all the multiples.
        return multiples;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Calculate the index where the list should be divided.
        // The last "amount" elements will move to the beginning.
        int splitIndex = data.Count - amount;

        // Step 2: Copy the elements that will move to the beginning.
        List<int> rightPart = data.GetRange(splitIndex, amount);

        // Step 3: Copy the elements that will remain at the end.
        List<int> leftPart = data.GetRange(0, splitIndex);

        // Step 4: Remove all elements from the original list.
        data.Clear();

        // Step 5: Add the right part to the beginning of the original list.
        data.AddRange(rightPart);

        // Step 6: Add the left part after the right part.
        data.AddRange(leftPart);

        // Step 7: The original list is now rotated to the right.
    }
}
