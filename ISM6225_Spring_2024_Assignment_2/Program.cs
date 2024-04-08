/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Reflection;
using System.Text;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3,6,9,1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2,1,2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                // Handling an edge case, when nums is empty
                if (nums.Length == 0)
                    return 0;
                else
                {
                    // Pointer to track unique elements in the array
                    int j = 0;

                    // Looping through the array starting from the second element
                    for (int i = 1; i < nums.Length; i++)
                    {
                        // Checking if the current element is different from the previous unique element
                        if (nums[i] != nums[j])
                        {
                            // Increment the pointer to the next position
                            j++;
                            // Update the next unique element
                            nums[j] = nums[i];
                        }
                    }
                    // Return the length of unique elements
                    return j + 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                // Pointer to track index of zeroes in the array
                int j = 0;

                // Looping through the array
                for (int i = 0; i < nums.Length; i++)
                {
                    // Checking if the current element is non-zero, swap it with the element at index j
                    if (nums[i] != 0)
                    {
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                        j++;
                    }
                }
                // Convert the array to IList<int> and return
                return nums;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                List<IList<int>> result = new List<IList<int>>();

                // Sorting the array to handle duplicates
                Array.Sort(nums);

                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Skip duplicates
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;

                    // Pointer for the element to the right of nums[i]
                    int left = i + 1;
                    // Pointer for the last element
                    int right = nums.Length - 1;

                    while (left < right)
                    {
                        // If found a triplet that sums up to zero, add it to the result
                        int sum = nums[i] + nums[left] + nums[right];
                        if (sum == 0)
                        {
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });

                            // Skip duplicates of left and right pointers
                            while (left < right && nums[left] == nums[left + 1])
                                left++;
                            while (left < right && nums[right] == nums[right - 1])
                                right--;

                            // Moving both pointers towards the center
                            left++;
                            right--;
                        }
                        else if (sum < 0)
                        {
                            // If sum is less than zero, move the left pointer to the right
                            left++;
                        }
                        else
                        {
                            // If sum is greater than zero, move the right pointer to the left
                            right--;
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                // Variable to store the maximum consecutive ones count
                int maxCount = 0;
                // Variable to store the current consecutive ones count
                int currCount = 0; 

                foreach (int i in nums)
                {
                    if (i == 1)
                    {
                        // If the current number is 1, increment the current count
                        currCount++;
                    }
                    else
                    {
                        // If the current number is 0, update the maxCount if necessary and reset current count
                        maxCount = Math.Max(maxCount, currCount);
                        currCount = 0;
                    }
                }

                // Update the maxCount if the current count extends till the end of the array
                maxCount = Math.Max(maxCount, currCount);
                return maxCount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                if (binary < 0)
                    throw new ArgumentException("Input binary number cannot be negative.", nameof(binary));

                int copy = binary;
                while (copy > 0)
                {
                    int digit = copy % 10;
                    if (digit != 0 && digit != 1)
                        throw new ArgumentException("Input is not a valid binary number.", nameof(binary));
                    copy /= 10;
                }

                int decimalVal = 0;
                // Base value for binary place value calculation
                int baseValue = 1; 

                while (binary > 0)
                {
                    // Extract the last digit
                    int rem = binary % 10;
                    decimalVal += rem * baseValue;
                    // Remove the last digit
                    binary /= 10;
                    // Increment the base value for next place value
                    baseValue *= 2; 
                }

                return decimalVal;
            }
            catch (ArgumentException)
            {
                throw; 
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while converting binary to decimal.", ex);
            }
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                if (nums.Length < 2)
                    return 0;

                // Find the minimum and maximum values in the array
                int minVal = int.MaxValue;
                int maxVal = int.MinValue;
                foreach (int n in nums)
                {
                    minVal = Math.Min(minVal, n);
                    maxVal = Math.Max(maxVal, n);
                }

                // Calculate the bucket size and the number of buckets
                int bucketSize = Math.Max(1, (maxVal - minVal) / (nums.Length - 1));
                int bucketCount = (maxVal - minVal) / bucketSize + 1;

                // Create arrays to store the minimum and maximum values in each bucket
                int[] bucketMin = new int[bucketCount];
                int[] bucketMax = new int[bucketCount];

                for (int i = 0; i < bucketCount; i++)
                {
                    bucketMin[i] = int.MaxValue;
                    bucketMax[i] = int.MinValue;
                }

                // Put elements into buckets
                foreach (int num in nums)
                {
                    int bucketIndex = (num - minVal) / bucketSize;
                    bucketMin[bucketIndex] = Math.Min(bucketMin[bucketIndex], num);
                    bucketMax[bucketIndex] = Math.Max(bucketMax[bucketIndex], num);
                }

                // Calculate the maximum gap between buckets
                int maxGap = 0;
                int prevMax = minVal; // Initialize the previous maximum value
                for (int i = 0; i < bucketCount; i++)
                {
                    if (bucketMin[i] != int.MaxValue && bucketMax[i] != int.MinValue)
                    {
                        maxGap = Math.Max(maxGap, bucketMin[i] - prevMax);
                        prevMax = bucketMax[i];
                    }
                }
                return maxGap;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                // Sorting the array in ascending order
                Array.Sort(nums);

                // Traverse the array from the end to find the largest perimeter
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    // Check if the current three lengths can form a triangle
                    if (nums[i] < nums[i - 1] + nums[i - 2])
                    {
                        // If yes, return the perimeter of the triangle
                        return nums[i] + nums[i - 1] + nums[i - 2];
                    }
                }

                // If no triangle can be formed, return 0
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                // Find the index of the leftmost occurrence of part
                int index = s.IndexOf(part); 

                // Looping and removing occurrences of part until it's no longer found in s
                while (index != -1)
                {
                    // Remove part from s
                    s = s.Remove(index, part.Length);
                    // Find the next occurrence of part in the updated s
                    index = s.IndexOf(part);
                }

                return s;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Either s or part is null.");
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Part is larger than the string.");
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}