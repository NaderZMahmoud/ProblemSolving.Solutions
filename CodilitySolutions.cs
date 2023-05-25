using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving.Solutions
{
    public static class CodilitySolutions
    {
        /// <summary>
        /// https://app.codility.com/c/run/trainingH6XKEA-XPD/
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public static int solution(string S)
        {
            // Implement your solution here
            //If the string Length is 1 return 0
            if (S.Length == 1)
                return 0;
            //If the string length is Even, then there is no sym. point
            if ((S.Length % 2) == 0)
                return -1;
            // check if the first and second part of the string is mirrored 
            int Start = 0;
            int End = S.Length - 1;
            while (Start != End)
            {
                if (S[Start] != S[End])
                {
                    // it's not mirrored so return -1
                    return -1;
                }
                Start++;
                End--;
            }
            
            // the loop will exit when start = End which means that's the Sym. point
            return Start;
        }
        /// <summary>
        /// https://app.codility.com/c/run/trainingFJP8Y3-6P9/
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int FirstUnique(int[] A)
        {
            // Implement your solution here
            var hashtable = new Dictionary<int, int>();
           // var IntSequence = new List<int>();
           // var UniqueQueue = new SortedDictionary<int,int>();
            //int FirstInt = int.MaxValue;
            for (int idx=0;idx<A.Length;idx++)
            {
                if (hashtable.ContainsKey(A[idx]))
                {
                    hashtable[A[idx]] = hashtable[A[idx]] + 1;
                    //if(IntSequence.Contains(item))
                    //    IntSequence.Remove(item);


                }
                else
                {
                    hashtable.Add(A[idx], 1);
                    //IntSequence.Add(item);
                    
                }
            }
            for (int idx = 0; idx < A.Length; idx++)
            {
                if (hashtable[A[idx]] == 1)
                    return A[idx];
            }
                //FirstInt = IntSequence.Count> 0? IntSequence[0]:-1;
                //return hashtable.Where(x => x.Value == 1).Select(x => x.Key).FirstOrDefault(-1);
                //foreach (var item in hashtable)
                //{
                //    if (item.Value == 1)
                //    {
                //        //First get the lowest Index
                //        if (IntSequence.IndexOf(item.Key) < FirstInt)
                //        {
                //            FirstInt = IntSequence.IndexOf(item.Key);
                //        }
                //    }
                //}
                ////If no unique item found return -1
                //if (FirstInt > IntSequence.Count)
                //    return -1;
                ////Second get the number itself by Index
                //FirstInt = IntSequence[FirstInt];
                return -1;
        }
        /// <summary>
        /// https://app.codility.com/c/run/trainingRT7Y8G-B3D/
        /// </summary>
        /// <param name="S"></param>
        /// <param name="P"></param>
        /// <param name="Q"></param>
        /// <returns></returns>
        public static int[] DNA(string S, int[] P, int[] Q)
        {
            var result = new int[P.Length];
            int minValue = 0;
            // Implement your solution here
            Dictionary<char, int> map = new Dictionary<char, int>();
            map.Add('A', 1);
            map.Add('C', 2);
            map.Add('G', 3);
            map.Add('T', 4);
            for (int i = 0; i < P.Length; i++)
            {
                if (P[i] == Q[i])
                {
                    result[i] = map[S[P[i]]];
                }
                else
                {
                    minValue = map[S[P[i]]];
                    for (int idx = P[i]; idx <= Q[i]; idx++)
                    {
                        if (minValue > map[S[idx]])
                        {
                            minValue = map[S[idx]];
                        }
                    }
                    result[i] = minValue;

                }

            }

            return result;
        }

        /// <summary>
        /// https://app.codility.com/c/run/training37X7QY-GTV/
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public static int CountDiv(int A, int B, int K)
        {
            // Implement your solution here
            int start = A;
            int end = B;
            int counter = 0;
            if (A == B)
                return (A % K) == 0 ? 1 : 0;

            if (K > A && K > B)
            {
                return 0;
            }
            if (K > A)
            {
                start = K;
                //because 0 is dividable by every number
                if (A == 0)
                    counter++;
            }

            for (int i = start; i <= end; i++)
            {
                if ((i % K) == 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public static int CountDiv_Optimum(int A, int B, int K)
        {
            // get last dividor - first dividor + ( if first number dividable by k + 1 or not +0 )
            int inclusive = ((A % K) == 0) ? 1 : 0;
            return (B / K) - (A / K) + inclusive;
        }
        /// <summary>
        /// https://app.codility.com/c/run/trainingZ3DS88-2R3/
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int passingCars(int[] A)
        {
            // Implement your solution here
            int result = 0;
            int ZerosCounter = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 0)
                {
                    ZerosCounter++;
                }
                else
                {
                    result += ZerosCounter;
                    if (result >= 1000000000)
                        return -1;
                }
            }

            return result;
        }



        /// <summary>
        /// https://app.codility.com/c/run/trainingFW7R8H-353/
        /// </summary>
        /// <param name="N"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int[] MaxCounters(int N, int[] A)
        {
            // Implement your solution here
            int[] counters = new int[N];
            int max = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > N && max > 0)
                {
                    // updatecounters
                    for (var item = 0; item < counters.Length; item++)
                    {
                        counters[item] = max;
                    }
                }
                if (A[i] <= N)
                {
                    int index = A[i] - 1;
                    counters[index]++;
                    if (max < counters[index])
                    {
                        max = counters[index];
                    }

                }
            }
            return counters;
        }
        public static int[] MaxCounters_optimum(int N, int[] A)
        {
            // Implement your solution here
            int[] counters = new int[N];
            int max = 0;
            int Increment = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > N && max > 0)
                {
                    // updatecounters
                    Increment = max;

                }
                if (A[i] <= N)
                {
                    int index = A[i] - 1;

                    if (counters[index] < Increment)
                    {
                        counters[index] = Increment + 1;
                    }
                    else
                    {
                        counters[index]++;
                    }


                    if (max < counters[index])
                    {
                        max = counters[index];
                    }

                }
            }
            for (int i = 0; i < counters.Length; i++)
            {
                if (counters[i] < Increment)
                    counters[i] = Increment;
            }
            return counters;
        }

        /// <summary>
        /// https://app.codility.com/c/run/trainingEH6B4F-JYH/
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int smallest_Positive_Num(int[] A)
        {
            // Implement your solution here
            if (A.Length == 1 && A[0] <= 0)
                return 1;

            var map = new HashSet<int>();

            int max = 0;
            foreach (int item in A)
            {
                if (item > 0)
                {
                    map.Add(item);
                    if (item > max)
                        max = item;
                }

            }
            for (int i = 1; i < max; i++)
            {
                if (!map.Contains(i))
                {
                    return i;
                }
            }
            return max + 1;
        }
        /// <summary>
        /// https://app.codility.com/programmers/lessons/4-counting_elements/perm_check/
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
    }
}
