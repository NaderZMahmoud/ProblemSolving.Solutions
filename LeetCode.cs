using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving.Solutions
{
    public static class LeetCode
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MajorityElement(int[] nums)
        {
            return 0;
        }
        /// <summary>
        /// https://leetcode.com/problems/word-pattern/?envType=study-plan-v2&id=top-interview-150
        /// Bad Performance because of the search dictionary by value
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool WordPattern(string pattern, string s)
        {
            string[] words = s.Split(' ');
            if (words.Length != pattern.Length)
            {
                return false;
            }
            // use 2 dictionaries to increase search performance 
            var map = new Dictionary<char, string>();
            var mapRev = new Dictionary<string, char>();
            for (int idx = 0; idx < words.Length; idx++)
            {
                if (map.ContainsKey(pattern[idx]))
                {
                    if (map[pattern[idx]] != words[idx])
                    {
                        return false;
                    }
                }
                else
                {
                    if (mapRev.ContainsKey(words[idx])) return false;
                    map.Add(pattern[idx], words[idx]);
                    mapRev.Add(words[idx], pattern[idx]);
                }
            }
            return true;

        }
        /// <summary>
        /// https://leetcode.com/problems/isomorphic-strings/?envType=study-plan-v2&id=top-interview-150
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            Dictionary<char, char> map = new Dictionary<char, char>();
            for (int idx = 0; idx < s.Length; idx++)
            {
                if (map.ContainsKey(s[idx]))
                {
                    if (map[s[idx]] != t[idx])
                        return false;
                }
                else
                {
                    if (map.ContainsValue(t[idx]))
                        return false;
                    map.Add(s[idx], t[idx]);
                }
            }
            return true;
        }
        /// <summary>
        /// https://leetcode.com/problems/is-subsequence/?envType=study-plan-v2&id=top-interview-150
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>

        public static bool IsSubsequence(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
                return true;
            Queue<char> chars = new Queue<char>();
            foreach (var item in s)
            {
                chars.Enqueue(item);
            }
            foreach (var item in t)
            {
                if (item == chars.FirstOrDefault())
                {
                    chars.Dequeue();
                }
            }
            return chars.Count == 0 ? true : false;
        }
        /// <summary>
        /// https://leetcode.com/problems/is-subsequence/submissions/956711753/?envType=study-plan-v2&id=top-interview-150
        /// Beats 100% :) 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsSubsequence_2(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            int first = 0; int second = 0;
            for (int idx = 0; idx < t.Length; idx++)
            {
                if (s[first] == t[second])
                {
                    first++;
                    second++;
                }
                else
                {
                    second++;
                }

                if (first == s.Length)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// https://leetcode.com/problems/merge-sorted-array/?envType=study-plan-v2&id=top-interview-150
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {

            if (m == 0 && n == 1)
            {
                nums1[0] = nums2[0];
            }
            int first = m - 1;
            int second = n - 1;
            int i = m + n - 1;
            if (n != 0)
            {
                while (second >= 0)
                {
                    if (first >= 0 && nums1[first] > nums2[second])
                    {
                        nums1[i] = nums1[first];
                        first--;
                    }
                    else
                    {
                        nums1[i] = nums2[second];
                        second--;
                    }
                    i--;
                }
            }
        }



        /// <summary>
        /// https://leetcode.com/problems/longest-palindromic-substring/solutions/?languageTags=csharp
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string LongestPalindrome(string s)
        {
            int maxLength = 0;
            string MaxStr = "";
            for (int idx = 0; idx < s.Length; idx++)
            {
                int right = idx;
                int Left = idx;
                while (Left >= 0 && right < s.Length && s[Left] == s[right])
                {
                    if ((right - Left) + 1 > maxLength)
                    {
                        maxLength = (right - Left) + 1;
                        MaxStr = s.Substring(Left, (right - Left) + 1);
                    }
                    Left--;
                    right++;
                }

                Left = idx; right = idx + 1;
                while (Left >= 0 && right < s.Length && s[Left] == s[right])
                {
                    if ((right - Left) + 1 > maxLength)
                    {
                        maxLength = (right - Left) + 1;
                        MaxStr = s.Substring(Left, (right - Left) + 1);
                    }
                    Left--;
                    right++;
                }
            }
            return MaxStr;
        }
    }
}
