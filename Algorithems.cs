using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving.Solutions
{
    public static class Algorithems
    {
      

        public static double Average(double a, double b)
        {
            double result = (a + b) / 2 ;
            return result;
        }
      
        //public static string AddBinary(string a, string b)
        //{
        //    long firstInt = 0;
        //    long secondInt = 0;
        //    firstInt = Convert.ToDouble(a,);
        //    secondInt = Convert.ToInt64(b, 2);
        //    return Convert.ToString((firstInt + secondInt), 2);

        //}

        //public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        //{
        //    ListNode result;
        //    ListNode CurrentNode;
        //    ListNode FirstList = l1;
        //    ListNode SecondList = l2;

        //    if (l1.val == 0 && l2.val == 0)
        //    {
        //        result = new ListNode();
        //        result.val = 0;
        //        return result;
        //    }
        //   int FirstNum = GetNUmberFromList(l1);
        //    int SecondNum = GetNUmberFromList(l2);  
        //    string resultNum = (FirstNum+ SecondNum).ToString();
        //    result = new ListNode();
        //    result.val = int.Parse(resultNum[resultNum.Length - 1].ToString());
        //    CurrentNode = new ListNode();
        //    result.next = CurrentNode;
        //    for (int idx=resultNum.Length-2; idx>=0; idx--)
        //    {
        //        CurrentNode.val= int.Parse(resultNum[idx].ToString());
        //    }



        //}
        private static int GetNUmberFromList(ListNode list)
        {
            Stack<int> tempStack = new Stack<int>();
            StringBuilder tempStr = new StringBuilder();
            while (list != null)
            {
                tempStack.Push(list.val);
                list = list.next;
            }
            while (tempStack.Count > 0)
            {
                tempStr.Append(tempStack.Pop());
            }
            return int.Parse(tempStr.ToString());
        }
        public static int PermCheck(int[] A)
        {
            // Implement your solution here
            if (A.Length == 1 && A[0] != 1)
                return 0;
            var map = new HashSet<int>();

            foreach (var item in A)
            {
                map.Add(item);
            }
            for (int i = 1; i <= A.Length; i++)
            {
                if (!map.Contains(i))
                    return 0;
            }
            return 1;
        }

        /// <summary>
        /// Given an integer num, repeatedly add all its digits until the result has only one digit, and return it.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int AddDigits(int num)
        {
            if (num == 0) return 0;
            int rem = num % 9;
            if (rem > 0)
                return rem;
            else
                return 9;
        }
        /// <summary>
        /// Given an integer array nums, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements that appear only once. You can return the answer in any order.
        ///You must write an algorithm that runs in linear runtime complexity and uses only constant extra space.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] SingleNumber_III(int[] nums)
        {
            if (nums.Length == 2) { return nums; }
            HashSet<int> map = new HashSet<int>();
            int[] result = new int[2];
            foreach (var item in nums)
            {
                if (map.Contains(item))
                    map.Remove(item);
                else map.Add(item);
            }
            result[0] = map.First();
            result[1] = map.Last();
            return result;

        }
        /// <summary>
        /// Given an integer array nums where every element appears three times except for one, which appears exactly once. Find the single element and return it.
        /// You must implement a solution with a linear runtime complexity and use only constant extra space.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int SingleNumber_II(int[] nums)
        {
            if (nums.Length == 1) { return nums[0]; }
            Dictionary<int,int> map = new Dictionary<int,int>();
            int result = 0;
            foreach (var item in nums)
            {
                if (map.ContainsKey(item))
                    map[item] += 1;
                else map.Add(item, 1);
            }
            foreach (var item in map)
            {
                if (item.Value == 1)
                {
                    result = item.Key;
                    break;
                }
            }
            return result;

        }
        public static int SingleNumber_1(int[] nums)
        {
            if(nums.Length == 1) { return nums[0]; }    
            HashSet<int> result = new HashSet<int>();
            foreach(int num in nums)
            {
                if(result.Contains(num))
                    result.Remove(num);
                else
                    result.Add(num);
            }
            return result.First();  

        }
        public static bool IsPalindrome(string s)
        {
            string newStr = s.Trim().ToLower();
            if (newStr == string.Empty)
                return true;

            StringBuilder sb = new StringBuilder(); 
            foreach (char c in newStr) {
            if(Char.IsLetterOrDigit(c))
                {
                    sb.Append(c);
                }
            }
            newStr = sb.ToString();
            if (string.IsNullOrEmpty(newStr))
            {
                return true;
            }
                int startIndex = 0;
            int endIndex = newStr.Length;
            while (startIndex <= endIndex)
            {
                if (newStr[startIndex] != newStr[endIndex])
                    return false;

                startIndex++;
                endIndex--;
            }
            return true;
        }
        public static int LengthOfLastWord_2(string s)
        {
            bool startCount = false;
            int counter = 0;
            for (int i = s.Length-1;i>=0 ;i--)
            {
                if (s[i] != ' ' && startCount==false )
                {
                    startCount = true;
                    counter++;
                }
                else if (s[i] != ' ' && startCount == true )
                {
                    counter++;
                }
                else if (s[i] == ' ' && startCount == true)
                {
                    return counter;
                }

            }
            return counter;
        }
        public static int LengthOfLastWord(string s)
        {
            string newString = s.Trim();
            string[] words = newString.Split(' ');
            return words[words.Length - 1].Length;
        }
        public static ListNode MiddleNode_SecondApproach(ListNode head)
        {
            // every 2 steps for end pointer = 1 step for middle pointer
            ListNode middle = head;
            ListNode end = head;
            while (end != null && end.next != null)
            {
                middle = middle.next;
                end = end.next.next;
            }
            return middle;

        }
        public static ListNode MiddleNode(ListNode head)
        {
            if (head.next == null)
                return head;
            int ListCount = 0;
            ListNode current = head;
            while (current != null)
            {
                ListCount++;
                current = current.next;
            }
            int med = 0;
            if (ListCount % 2 == 0)
                med = (ListCount / 2) + 1;
            else
                med = (ListCount + 1) / 2;
            current = head;
            while (med > 1)
            {
                current = current.next;
                med--;
            }

            return current;

        }
        public static int ClimbStairs_NoRecurion_NoArray(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            int first = 1;
            int second = 2;
            int output = second;
            for (int i = 3; i <= n; i++)
            {
                output = first + second;
                first = second;
                second = output;
            }
            return output;
        }
        public static int ClimbStairs(int num)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            if (num <= 2)
                return num;


            return ClimbStairs_rec(num - 1, map) + ClimbStairs_rec(num - 2, map);


        }
        public static int ClimbStairs_rec(int num, Dictionary<int, int> map)
        {
            if (num <= 2)
                return num;
            if (map.ContainsKey(num))
                return map[num];
            int counter = ClimbStairs_rec(num - 1, map) + ClimbStairs_rec(num - 2, map);
            map.Add(num, counter);
            return counter;

        }
        public static int NumberOfSteps(int num)
        {
            int counter = 0;
            while (num > 0)
            {

                if ((num % 2) == 0)
                {
                    num = num / 2;
                }
                else
                {
                    num = num - 1;
                }
                counter++;
            }
            return counter;
        }
        public static IList<string> FizzBuzz(int n)
        {
            string[] results = new string[n];
            for (int i = 0; i < n; i++)
            {
                int j = i + 1;
                if ((j % 3 == 0) && (j % 5 == 0))
                    results[i] = "FizzBuzz";
                else if (j % 3 == 0)
                    results[i] = "Fizz";
                else if (j % 5 == 0)
                    results[i] = "Buzz";
                else
                    results[i] = j.ToString();
            }
            return results;
        }

        public static int MaximumWealth(int[][] accounts)
        {
            int maxSum = 0;

            if (accounts.Length == 1)
                return accounts[0].Sum();

            for (int i = 0; i < accounts.Length; i++)
            {
                int sum = 0;
                sum = accounts[i].Sum();
                //for (int j = 0; j < accounts[i].Length; j++)
                //{
                //    sum += accounts[i][j];
                //}
                if (maxSum < sum)
                    maxSum = sum;

            }
            return maxSum;

        }

        public static int[] RunningSum(int[] nums)
        {
            if (nums.Length <= 1)
                return nums;

            int[] result = new int[nums.Length];
            result[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                result[i] = nums[i] + result[i - 1];
            }
            return result;
        }

        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            //remove nigative values

            A = A.Where(x => x > 0).ToArray();
            int min = A.Min();
            if (min > 1)
                return 1;

            A = A.OrderBy(x => x).ToArray();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] + 1 != A[i + 1])
                    return A[i] + 1;
            }
            return 0;
        }
        public static int firstPostiveNumber(int[] A)
        {
            // Implement your solution here
            var dic = new HashSet<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > 0)
                    dic.Add(A[i]);

            }
            for (int i = 1; i < A.Length; i++)
            {
                if (!dic.Contains(i))
                    return i;
            }
            return A.Length;
        }
        public static int ArrListLen(int[] A)
        {
            // Implement your solution here
            if (A[0] == -1)
                return 1;

            if (A.Length <= 2)
                return A.Length;

            int nextIndex = 0;
            int NodesCount = 1;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[nextIndex] == -1)
                    return NodesCount;
                else
                {
                    nextIndex = A[nextIndex];
                    NodesCount++;
                }
            }
            return A.Length;
        }

        public static int BinaryGap(int input)
        {
            string binaryNumberString = Convert.ToString(input, 2);
            Console.WriteLine("binary value " + binaryNumberString);
            string[] strArray = binaryNumberString.Split('1');
            int gapLength = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                Console.WriteLine(strArray[i]);
                if (strArray[i].Length == 0)
                    continue;
                if (i == (strArray.Length - 1))
                    continue;

                if (strArray[i].Length > gapLength)
                    gapLength = strArray[i].Length;

                Console.WriteLine("gap length " + gapLength.ToString());

            }
            Console.ReadKey();
            return gapLength;

        }

        public static int[] ArrayRotation(int[] inputArray, int inputInt)
        {
            //A = [3, 8, 9, 7, 6]
            //K = 3
            int[] tempArray = new int[inputArray.Length];
            for (int idx = 0; idx < inputInt; idx++)
            {
                for (int i = 0; i < inputArray.Length; i++)
                {
                    if (i == inputArray.Length - 1)
                    {
                        tempArray[0] = inputArray[i];
                        break;
                    }
                    tempArray[i + 1] = inputArray[i];
                }
                tempArray.CopyTo(inputArray, 0);
            }
            return inputArray;

        }

        public static int OddOccuranceINArray(int[] inputArray)
        {
            if (inputArray.Length == 1)
                return inputArray[0];

            if (inputArray.Length == 2)
                throw new InvalidOperationException();

            List<int> tempArray = new List<int>();
            int FirstInt = inputArray[0];
            bool matchFound = false;
            // int tempArrayIndex = 0;
            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] == FirstInt)
                {
                    matchFound = true;
                    continue;
                }


                //if (tempArrayIndex == tempArray.Length - 1) //match not found, don't proceed and return the first int in this case 
                //    return FirstInt;

                tempArray.Add(inputArray[i]);

            }
            if (matchFound)
                //if not found call self again
                return OddOccuranceINArray(tempArray.ToArray());
            else return FirstInt;
        }

        public static int FrogJumb(int X, int Y, int D)
        {
            //X=10,Y=90,D=30
            if (X >= Y || D == 0)
                return 0;
            //int jumb = 1;
            Y = Y - X;
            //get multiple rest
            var rest = Y % D;
            if (rest > 0)
            {
                Y = Y - rest;
                //return Y / X;
                return (Y / D) + 1;
            }

            return (Y / D);

            //int temp = X + D;
            //if (temp > Y)
            //    return jumb;
            //while(temp < Y)
            //{
            //    temp = temp + D;
            //    jumb++;
            //}
            //return jumb;
        }

        public static int MissingElement(int[] A)
        {

            if (A.Length == 0)
                return 1;
            if (A.Length == 1)
            {
                if (A[0] > 1)
                    return 1;
                else
                    return 2;
            }
            A = A.OrderBy(x => x).ToArray();
            if (A[0] != 1) return 1;
            for (int i = 0; i < A.Length; i++)
            {
                if (i == A.Length - 1)
                    continue;
                if (A[i] + 1 != A[i + 1])
                    return A[i] + 1;
            }
            return A[A.Length - 1] + 1;
        }

        public static int TapeEquilibrium(int[] A)
        {
            int minDef = int.MaxValue;
            //int sumAll = A.Sum();
            for (int i = 0; i < A.Length; i++)
            {
                // int firstPart = 0;
                // int secondPart = 0;
                if (i == A.Length - 1)
                    continue;
                int[] firstArr = new int[i + 1];
                firstArr = A.Take(i + 1).ToArray();
                int[] secondArray = new int[A.Length - 1 - i];
                secondArray = A.Skip(i + 1).ToArray();
                int firstPart = firstArr.Sum();
                int secondPart = secondArray.Sum();
                if (minDef > Math.Abs(firstPart - secondPart)) minDef = Math.Abs(firstPart - secondPart);
                if (minDef <= 1) break;
            }
            return minDef;
        }

        public static int Summ(int[] myArray)
        {
            if (myArray.Length < 2 || myArray.Length > 100000)
                return 0;

            int[] another = new int[myArray.Length - 1];

            int currentNum = 0;
            for (int x = 0; x < myArray.Length; x++)
            {
                if (myArray[x] >= -1000 && myArray[x] <= 1000)
                {

                    if (x == myArray.Length - 1)
                        break;

                    currentNum += myArray[x];

                    int otherNumSum = 0;


                    for (int i = x + 1; i < myArray.Length; i++)
                    {
                        otherNumSum += myArray[i];
                    }

                    another[x] = Math.Abs(otherNumSum - currentNum);
                }
            }

            return another.Min();
        }


        public static int Sum(int[] A)
        {
            int sumRight = 0;
            for (int i = 0; i < A.Length; i++)
            {
                sumRight += A[i];
            }

            int sumLeft = 0;
            int min = int.MaxValue;
            for (int P = 1; P < A.Length; P++)
            {
                int currentP = A[P - 1];
                sumLeft += currentP;
                sumRight -= currentP;

                int diff = Math.Abs(sumLeft - sumRight);
                if (diff < min)
                {
                    min = diff;
                }
            }
            return min;
        }

        public static int[] GenerateRandomArray()
        {
            int Min = -1;
            int Max = 1;

            // this declares an integer array with 5 elements
            // and initializes all of them to their default value
            // which is zero
            int[] test2 = new int[100000];

            Random randNum = new Random();
            for (int i = 0; i < test2.Length; i++)
            {
                test2[i] = randNum.Next(Min, Max);
            }
            return test2;
        }

        public static long PassingCars(int[] A)
        {
            long passingCarsCount = 0;

            int zeros = 0;
            //int ones = 0;
            bool limitExceed = false;
            for (int i = 0; i < A.Length; i++)
            {
                if (passingCarsCount > 1000000000)
                {
                    limitExceed = true;
                    break;
                }
                if (A[i] == 0)
                {
                    zeros++;
                    // if(ones > 0)ones--;
                }
                else
                {
                    //ones++;
                    passingCarsCount += zeros;

                }

            }
            if (limitExceed)
                return -1;
            else
                return passingCarsCount;
        }

        public static String repeatingChar(String S)
        {
            int[] occurrences = new int[26];
            foreach (char ch in S)
            {
                occurrences[(int)ch - 'a']++;
            }

            char best_char = 'a';
            int best_res = 0;

            for (int i = 0; i < 26; i++)
            {
                if (occurrences[i] > best_res)
                {
                    best_char = (char)('a' + i);
                    best_res = occurrences[i];
                }
            }

            return best_char.ToString();
        }

        public static int MaximumWordCount(String S)
        {
            //Three spliters ./?/!
            string[] strArray = S.Split(new char[] { '.', '?', '!' });
            int maxWordCount = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string[] words = strArray[i].Split(' ');
                int wordsCount = words.Length;
                for (int idx = 0; idx < words.Length; idx++)
                {
                    if (words[idx].Length == 0)
                        wordsCount--;
                }
                if (wordsCount > maxWordCount)
                {
                    maxWordCount = words.Length;
                }
            }
            return maxWordCount;
        }

        public static string FindElement(int[] arr, int k)
        {
            for (int i = 0; i < arr.Count(); i++)
            {
                if (arr[i] == k)
                    return "YES";
            }

            return "No";
        }

        public static int PascalTriangle(int input)
        {
            if (input == 0)
                return 1;
            int total = 1;

            for (int i = 1; i <= input; i++)
            {
                total = total * 2;
                if (total > (int.MaxValue / 2) & (i < input - 1)) // if the current round is not the final and the next value will be more that int max value
                    return -1;
            }
            return total;
        }

        public static int ParseRomanNumerals(string input)
        {
            int[] numbers = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'M')
                    numbers[i] = 1000;
                if (input[i] == 'D')
                    numbers[i] = 500;
                if (input[i] == 'C')
                    numbers[i] = 100;
                if (input[i] == 'L')
                    numbers[i] = 50;
                if (input[i] == 'X')
                    numbers[i] = 10;
                if (input[i] == 'V')
                    numbers[i] = 5;
                if (input[i] == 'I')
                    numbers[i] = 1;

            }
            int total = 0;

            for (int idx = 0; idx < numbers.Length; idx++)
            {
                total += numbers[idx];
                if (idx > 0)
                {
                    if (numbers[idx - 1] < numbers[idx])
                    {
                        total = total - numbers[idx] - numbers[idx - 1];
                        total += numbers[idx] - numbers[idx - 1];
                    }
                }
            }
            return total;
        }
        public static int MaxDepth(TreeNode root)
        {
            int depthLeft = 0;
            int depthRight = 0;
            if (root.left != null)
                depthLeft = getLeft(root, depthLeft);

            if (root.right != null)
                depthRight = getRight(root, depthRight);

            if (depthRight > depthLeft)
                return depthRight;
            else return depthLeft;
        }
        private static int getLeft(TreeNode Node, int count)
        {
            count++;
            if (Node.left != null)
                return count + getLeft(Node.left, count);
            else
                return count;
        }
        private static int getRight(TreeNode Node, int count)
        {
            count++;
            if (Node.right != null)
                return count + getRight(Node.right, count);
            else
                return count;

        }

        public static int sockMerchant(int n, int[] ar)
        {
            Hashtable ht = new Hashtable();
            for (int i = 0; i < ar.Length; i++)
            {
                if (ht.ContainsKey(ar[i]))
                {
                    int temp = (int)ht[ar[i]];
                    temp++;
                    ht[ar[i]] = temp;
                }
                else
                {
                    ht.Add(ar[i], 1);
                }
            }
            int socksCount = 0;
            foreach (int item in ht.Keys)
            {
                if ((int)ht[item] == 1)
                    continue;
                int def = (int)ht[item] % 2;
                if (def == 0)
                {
                    socksCount += (int)ht[item] / 2;
                }
                else
                {
                    socksCount += ((int)ht[item] - def) / 2;
                }
            }
            return socksCount;
        }
        public static int countingValleys(int n, string s)
        {
            int valliesCount = 0;
            int seaLevel = 0;
            int prevStep = 0;
            foreach (char step in s)
            {
                prevStep = seaLevel;
                if (step == 'D')
                    seaLevel--;
                else if (step == 'U')
                    seaLevel++;

                if (prevStep == 0 && seaLevel < 0)
                {
                    valliesCount++;
                }

            }
            return valliesCount;

        }

        public static int jumpingOnClouds(int[] c)
        {

            int jumbsCount = 0;
            for (int i = 0; i < c.Length; i++)
            {
                if (i == c.Length - 1)
                {
                    // jumbsCount++;
                    continue;
                }
                if (i == c.Length - 2)
                {
                    jumbsCount++;
                    continue;
                }
                if (c[i + 2] == 0)
                {

                    i++;
                }
                jumbsCount++;

            }
            return jumbsCount;
        }

        public static long repeatedString(string s, long n)
        {
            if (s.Length == 1 && s == "a")
                return n;
            StringBuilder str = new StringBuilder();
            str.Append(s);
            while (str.ToString().Length <= n)
            {
                str.Append(s);
            }
            s = s.Substring(0, (int)n);

            char[] chars = s.ToCharArray().Where(x => x == 'a').ToArray();
            return chars.Length;
        }

        public static int removeDuplicates(int[] nums)  // remove duplicates from sorted array "In Place"
        {
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {

            ListNode current = head;

            int currentIndex = 0;
            while (current.next != null)
            {
                currentIndex++;
                if (n == currentIndex - 2)
                {
                    current.val = current.next.val;
                    current.next = current.next.next;
                }
                else
                {
                    current = current.next;
                }
            }
            return head;
        }

        public static int MaxProfit(int[] prices)
        {
            int profit = 0;
            for (int i = 0; i < prices.Length; i++)
            {

                if (i < prices.Length - 1 && prices[i + 1] > prices[i])
                {
                    //int currentprofit = prices[i + 1] - prices[i];
                    //if (currentprofit > profit)
                    profit = prices[i + 1] - prices[i];
                    // i++;
                }
            }
            return profit;
        }

        public static void Rotate(int[] nums, int k)
        {
            if (nums.Length < 2)
                return;
            if (k > nums.Length)
                k = k - nums.Length;

            int[] tempArr = new int[nums.Length];
            int def = nums.Length - k;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < def)
                {
                    tempArr[i + k] = nums[i];

                }
                else
                {
                    tempArr[i - def] = nums[i];
                }
            }

            tempArr.CopyTo(nums, 0);

        }

        public static bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> values = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (values.Contains(nums[i]))
                    return true;
                else
                    values.Add(nums[i]);
            }

            return false;
        }

        public static int SingleNumber(int[] nums)
        {

            Dictionary<int, int> hashtable = new Dictionary<int, int>();
            foreach (var item in nums)
            {
                if (hashtable.ContainsKey(item))
                    hashtable[item] = hashtable[item] + 1;
                else
                    hashtable.Add(item, 1);
            }
            return hashtable.Where(x => x.Value == 1).Select(x => x.Key).First();
            //foreach (var item in hashtable)
            //{
            //    if (item.Value == 1)
            //        return item.Key;
            //}
            //return 0;
        }
        //        Approach 4: Bit Manipulation
        //Concept

        //If we take XOR of zero and some bit, it will return that bit
        //a \oplus 0 = aa⊕0=a
        //If we take XOR of two same bits, it will return 0
        //a \oplus a = 0a⊕a=0
        //a \oplus b \oplus a = (a \oplus a) \oplus b = 0 \oplus b = ba⊕b⊕a=(a⊕a)⊕b=0⊕b=b
        //So we can XOR all bits together to find the unique number.
        public static int singleNumber_(int[] nums)
        {
            int a = 0;
            foreach (int i in nums)
            {
                a ^= i;
            }
            return a;
        }

        public static int[] Intersect_MySolution(int[] nums1, int[] nums2)
        {
            int[] smallerArr;
            int[] LargerArr;
            List<int> result = new List<int>();
            // HashSet<int> smallerIndexs = new HashSet<int>();
            HashSet<int> largerIndexes = new HashSet<int>();
            if (nums1.Length > nums2.Length)
            {
                LargerArr = nums1;
                smallerArr = nums2;
            }
            else
            {
                LargerArr = nums2;
                smallerArr = nums1;
            }

            for (int i = 0; i < smallerArr.Length; i++)
            {

                for (int j = 0; j < LargerArr.Length; j++)
                {
                    if (largerIndexes.Contains(j))
                        continue;
                    if (smallerArr[i] == LargerArr[j])
                    {
                        // smallerIndexs.Add(i);
                        largerIndexes.Add(j);
                        result.Add(smallerArr[i]);
                        break;
                    }
                }
            }
            return result.ToArray();
        }

        public static int[] Intersect_optimalSolution(int[] nums1, int[] nums2)
        {
            var dict = new Dictionary<int, int>();

            foreach (var i in nums1)
            {
                if (dict.ContainsKey(i))
                {
                    dict[i]++;
                }
                else
                {
                    dict[i] = 1;
                }
            }

            var answer = new List<int>();
            foreach (var i in nums2)
            {
                if (dict.ContainsKey(i))
                {
                    if (dict[i] > 0)
                    {
                        answer.Add(i);
                        dict[i]--;
                    }
                }
            }

            return answer.ToArray();
        }

        public static int[] PlusOne_MySolution(int[] digits)
        {
            // This solution is not working for large numbers
            StringBuilder strBuilder = new StringBuilder();
            foreach (var item in digits)
            {
                strBuilder.Append(item.ToString());


            }
            var val = Convert.ToDecimal(strBuilder.ToString());
            val++;
            string valstr = val.ToString();
            int[] result = new int[valstr.Length];
            int idx = 0;
            foreach (var ch in valstr)
            {
                result[idx] = Convert.ToInt32(ch.ToString());
                idx++;
            }

            return result;

        }

        public static int[] PlusOne_Optimal(int[] digits)
        {
            for (var i = digits.Length - 1; i >= 0; i--)
            {
                var newSum = digits[i] + 1;
                if (newSum < 10)
                {
                    digits[i] = newSum;
                    return digits;
                }

                digits[i] = 0;
            }

            var newDigits = new int[digits.Length + 1];
            newDigits[0] = 1;

            return newDigits;
        }

        // Can add a number and pass the carry along
        // If you have a carry you'll need to increase the array space by one and shift them all
        // Cases:
        //   - If the number at the end of the array is not 9, just add one and you're done
        //   - If the number is 9, propagate the carry and add extra space
        // Extra space requires O(n)

        public static int[] PlusOne_optimal_Better(int[] digits)
        {
            if (digits == null || digits.Length == 0)
            {
                return digits;
            }

            if (digits[digits.Length - 1] != 9)
            {
                digits[digits.Length - 1] = digits[digits.Length - 1] + 1;

                return digits;
            }

            var index = digits.Length - 1;

            while (index >= 0 && digits[index] == 9)
            {
                digits[index] = 0;
                index--;
            }

            if (index < 0)
            { // We need more room
                var newDigits = new int[digits.Length + 1];
                Array.Copy(digits, 0, newDigits, 1, digits.Length);
                newDigits[0] = 1;

                return newDigits;
            }
            else
            {
                digits[index] = digits[index] + 1;
                return digits;
            }
        }

        public static void MoveZeroes(int[] nums)
        {
            int j = 0;

            for (int i = 0; i < nums.Length; i++)
            {

                if (nums[i] != 0)
                {
                    //int temp = nums[i];
                    if (j != i && nums[j] == 0)
                    {
                        nums[j] = nums[i];
                        nums[i] = 0;

                        //j = i;
                    }
                    while (nums[j] != 0 && j < i)
                        j++;
                }
                else if (nums[j] != 0)
                    j = i;
            }


        }
        public static void MoveZeroes_Optimal(int[] nums)
        {

            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != 0)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }

            while (i < nums.Length)
            {
                nums[i] = 0;
                i++;
            }
        }

        public static bool CanJump(int[] nums)
        {
            if (nums.Length == 1)
                return true;
            int lastSteps = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                lastSteps--;
                lastSteps = Math.Max(nums[i], lastSteps);
                if (lastSteps <= 0 && i != nums.Length - 1)
                {
                    return false;
                }

            }
            return true;
        }
        public static int LengthOfLongestSubstring(string s)
        {
            if (s.Length <= 1) return s.Length;
            int count = 0;
            int maxSize = 0;
            Dictionary<char, int> chars = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {

                if (!chars.ContainsKey(s[i]))
                {
                    chars.Add(s[i], i);
                    count++;
                }
                else
                {
                    i = chars[s[i]] + 1;
                    if (chars.Count > maxSize)
                        maxSize = chars.Count;

                    chars.Clear();
                    count = 0;
                    chars.Add(s[i], i);
                    count++;
                }

            }
            return maxSize > count ? maxSize : count;
        }
        public static int DistributeCandies(int[] candyType)
        {
            Dictionary<int, int> candTypesDic = new Dictionary<int, int>();
            int halfLen = candyType.Length / 2;
            for (int i = 0; i < candyType.Length; i++)
            {
                if (candTypesDic.ContainsKey(candyType[i]))
                {
                    candTypesDic[candyType[i]] += 1;
                }
                else
                {
                    candTypesDic.Add(candyType[i], 1);
                }
            }
            if (halfLen < candTypesDic.Count)
            {
                return halfLen;
            }
            else
            {
                return candTypesDic.Count;
            }


        }

        //public static string LargestTimeFromDigits(int[] arr)
        //{
        //    Dictionary<int, int> digits = new Dictionary<int, int>();
        //    int[] times = new int[arr.Length];
        //    foreach (var item in arr)
        //    {
        //        digits.Add(item, 0);

        //    }
        //    //get first digit
        //    foreach (var item in digits)
        //    {
        //        if (item.Key <= 2)
        //            digits[item.Key] = 1;
        //    }
        //    if (digits.ContainsValue(1)) // choose max
        //    {
        //        int max = 0;
        //        foreach(var item in digits)
        //        {
        //            if(item.Value == 1)
        //            {
        //                if(item.Key> max)
        //                {
        //                    max = item.Key;
        //                }
        //            }
        //        }
        //        times[0] = max;
        //        foreach (var item in digits)
        //        {
        //            //if(item.Key == max)
        //            //    digits[item.Key]=
        //        }
        //    }
        //    else
        //        return "";


        //}

        //================= HourGlass ===========================//
        /*
         * Complete the 'hourglassSum' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY arr as parameter.
         */

        public static int hourglassSum(List<List<int>> arr)
        {
            int maxSum = 0;
            int tempVal = 0;
            for (int i = 0; i < arr.Count - 2; i++)
            {
                for (int j = 0; j < arr[i].Count - 2; j++)
                {
                    tempVal = calculateHourglassValue(arr, i, j);
                    if (tempVal > maxSum)
                        maxSum = tempVal;
                }
            }
            return maxSum;
        }
        private static int calculateHourglassValue(List<List<int>> arr, int x, int y)
        {
            int hourGlassSum = 0;
            hourGlassSum = arr[x][y];
            hourGlassSum += arr[x][y + 1];
            hourGlassSum += arr[x][y + 2];
            hourGlassSum += arr[x + 1][y + 1];
            hourGlassSum += arr[x + 2][y];
            hourGlassSum += arr[x + 2][y + 1];
            hourGlassSum += arr[x + 2][y + 2];

            return hourGlassSum;
        }
        //=====================================================//

        //===================Rotation Left ========================//
        /* Complete the 'rotLeft' function below.
        *
        * The function is expected to return an INTEGER_ARRAY.
        * The function accepts following parameters:
        *  1. INTEGER_ARRAY a
        *  2. INTEGER d
        */

        public static List<int> rotLeft(List<int> a, int d)
        {
            int[] ints = new int[a.Count];
            int newIndex = 0;
            for (int i = 0; i < a.Count; i++)
            {
                newIndex = (a.Count + i) - d;
                if (newIndex >= a.Count)
                    newIndex = newIndex - a.Count;
                ints[newIndex] = a[i];
            }
            return ints.ToList<int>();
        }
        //=========================================================//
        //=================MInimum Bribes=============================//
        /*
         * Complete the 'minimumBribes' function below.
         *
         * The function accepts INTEGER_ARRAY q as parameter.
         */

        public static void minimumBribes(List<int> q)
        {
            int bribesCount = 0;
            for (int i = q.Count - 1; i > 0; i--)
            {
                if (q[i] < q[i - 1])
                {
                    bribesCount += q[i - 1] - q[i];
                }
                if (bribesCount >= 3)
                {
                    Console.WriteLine(bribesCount);
                    Console.WriteLine("Too chaotic");
                    return;
                }
            }
            Console.WriteLine(bribesCount);
        }
        //============================================================//
        //==================Binary Search=============================//

        //===========================================================//

        public static int[] TwoSum(int[] nums, int target)
        {

            if (nums == null || nums.Length < 2)
                return new int[2];

            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(target - nums[i]))
                    return new int[] { i, dic[target - nums[i]] };
                else if (!dic.ContainsKey(nums[i]))
                    dic.Add(nums[i], i);
            }

            return new int[2];
        }

        /*
     * Complete the 'checkMagazine' function below.
     *
     * The function accepts following parameters:
     *  1. STRING_ARRAY magazine
     *  2. STRING_ARRAY note
     */

        public static void checkMagazine(List<string> magazine, List<string> note)
        {
            HashSet<string> temp = new HashSet<string>();
            foreach (string str in magazine)
            {
                temp.Add(str);
            }
            foreach (string str in note)
            {
                if (temp.Contains(str))
                    temp.Remove(str);
                else
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            Console.WriteLine("Yes");
        }
        public static void checkMagazine_2(List<string> magazine, List<string> note)
        {

            foreach (string str in note)
            {
                if (!magazine.Remove(str))
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            Console.WriteLine("Yes");
        }
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> temp = new Dictionary<char, int>();
            foreach (char str in magazine)
            {
                if (temp.ContainsKey(str))
                    temp[str] += 1;
                else
                    temp.Add(str, 1);
            }
            foreach (char str in ransomNote)
            {
                if (temp.ContainsKey(str) && temp[str] > 0)
                    temp[str]--;
                else
                {

                    return false;
                }
            }
            return true;
        }
    }
    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class ShuffleArray
    {
        int[] original;
        int[] input;
        public ShuffleArray(int[] nums)
        {
            original = new int[nums.Length];
            input = new int[nums.Length];
            Array.Copy(nums,original,nums.Length);
            Array.Copy(nums, input, nums.Length);
        }

        public int[] Reset()
        {
            Array.Copy(original, input, input.Length);
            return input;
        }

        public int[] Shuffle()
        {
            int temp ,tempIndex= 0;
            Random rand = new Random();
            for (int i = 0; i < input.Length; i++)
            {
                tempIndex = rand.Next(i, input.Length);
                 temp =input[tempIndex];
                input[tempIndex] = input[i];
                input[i]= temp;

            }
            return input;
        }
    }
}
