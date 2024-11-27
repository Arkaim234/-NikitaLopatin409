using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.String
{
    internal class LongSubstring
    {
        public static string LongestSubstring(string s)
        {
            int maxLength = 0;
            int start = 0;
            string longestSubstring = "";
            Dictionary<char, int> charIndexMap = new Dictionary<char, int>();

            for (int end = 0; end < s.Length; end++)
            {
                char currentChar = s[end];

                if (charIndexMap.ContainsKey(currentChar))
                {
                    start = Math.Max(charIndexMap[currentChar] + 1, start);
                }

                charIndexMap[currentChar] = end;

                int currentLength = end - start + 1;
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    longestSubstring = s.Substring(start, currentLength);
                }
            }

            return longestSubstring;
        }
    }
}
