public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

       // Step 1: Initialize a new double array called 'result' with a fixed size equal to the 'length' parameter.
       double[] result = new double[length];

       // Step 2: Create a loop that iterates 'length' times, using an index variable 'i' starting from 0 up to 'length - 1'.
       for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple for the current position. 
            // Since arrays are 0-indexed, the multiplier for the first element (index 0) should be 1, 
            // for the second element (index 1) it should be 2, and so on. Formula: number * (i + 1)
            result[i] = number * (i + 1);
        }

        // Step 4: Return the populated 'result' array.
        return result; 
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Handle edge cases. If the list is empty or only has 1 element, or if the rotation amount
        // matches the total count exactly (which results in the same list), no rotation is necessary.
        if (data == null || data.Count <= 1 || amount == data.Count)
        {
            return;
        }

        // Step 2: Calculate the starting index of the sublist that needs to move to the front.
        // For example, if data.Count is 9 and amount is 3, the starting index is 9 - 3 = 6.
        int startingIndex = data.Count - amount;

        // Step 3: Extract the elements to be moved using GetRange.
        // The sublist starts from 'startingIndex' and spans 'amount' elements to the end of the list.
        List<int> subListToMove = data.GetRange(startingIndex, amount);

        // Step 4: Remove those extracted elements from their original positions at the back of the list.
        data.RemoveRange(startingIndex, amount);

        // Step 5: Insert the extracted sublist back into the main list at the very beginning (index 0).
        data.InsertRange(0, subListToMove);

    }
}
