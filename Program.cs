using System;

namespace StringManipulation
{
    public static class MyStringExtensions
    {
        //  Should return a reversed character string of the
        //  character string value.
        public static string Reverse(this string str)
        {
            string res = "";
            for (int i = str.Length; i != 0; --i)
            {
                res += str[i - 1];
            }
            return res;
        }

        //  Should return true if a character is contained
        //  in the character string, false if it is not.
        public static bool Contains(this string str, char c)
        {
            for (int i = 0, len = str.Length; i != len; ++i)
            {
                if (str[i] == c)
                {
                    return true;
                }
            }
            return false;
        }

        //  Should return true if a character string is
        //  contained in the passed characrter string,
        //  false if it is not.
        public static bool Contains(this string str, string sub)
        {
            int l = sub.Length;
            for (int i = 0, lim1 = str.Length; i != lim1; ++i)
            {
                int j = i;  //  Pass i to j because it will be manipulated.
                int k = 0;  //  Reset k for every i iteration.
                while (k != l && str[j] == sub[k])
                {
                    ++j;
                    ++k;
                }
                //  Check if k matches the sub's length.
                if (k == l)
                {
                    return true;
                }
            }
            return false;
        }

        //  Should return a integer of the position of the
        //  matching character literal in the character string,
        //  return -1 if the character does not exist in the
        //  string.
        public static int PositionOf(this string str, char c)
        {
            for (int i = 0, len = str.Length; i != len; ++i)
            {
                if (str[i] == c)
                {
                    return i + 1; //  Add one to i to get it's position.
                }
            }
            return -1;
        }

        //  Should return an interger of the position of the
        //  matching character literal in the character string,
        //  checking at the given position integer, returns -1 if the
        //  character does not exist in the character string.
        public static int PositionOf(this string str, char c, int pos)
        {
            if (pos < 0)
            {
                //  If pos is negative, count backwards.
                for (int i = str.Length + pos; i != 0; --i)
                {
                    if (str[i - 1] == c)
                    {
                        return i;
                    }
                }
            }
            else
            {
                for (int i = pos - 1, len = str.Length; i != len; ++i)
                {
                    if (str[i] == c)
                    {
                        return i + 1;
                    }
                }
            }
            return -1;
        }

        //  Should return a character string of all the duplicate
        //  characters in the string.
        public static string Duplicates(this string str)
        {
            string res = "";
            for (int i = 0, len = str.Length; i != len; ++i)
            {
                string s = "";
                for (int j = 0; j != len; ++j)
                {
                    if (i != j && str[i] == str[j] && !res.Contains(str[i]))
                    {
                        s = Convert.ToString(str[j]);
                    }
                }
                res += s;
            }
            return res;
        }

        //  Should return true if the character string is a
        //  palindrome, false if it is not.
        public static bool Palindrome(this string str)
        {
            int j = str.Length - 1;
            bool isPalindrome = true;
            for (int i = 0, len = str.Length / 2; i != len; ++i)
            {
                if (str[i] != str[j])
                {
                    isPalindrome = false;
                }
                j--;
            }
            return isPalindrome;
        }

        //  Should return true if the character string is a
        //  anagram of the passed character string, false if
        //  it is not.
        public static bool Anagram(this string str1, string str2)
        {
            bool isAnagram = true;
            //  Make sure the character strings are all lower case.
            str1 = str1.ToLower();
            str2 = str2.ToLower();
            //  First check if they are the same length!
            if (str1.Length == str2.Length)
            {
                for (int i = 0, len = str1.Length; i != len; ++i)
                {
                    bool match = false;
                    for (int j = 0; j != len; ++j)
                    {
                        if (str1[i] == str2[j])
                        {
                            match = true;
                            break;
                        }
                    }
                    if (!match)
                    {
                        isAnagram = false;
                        break;
                    }
                }
            }
            return isAnagram;
        }

        //  Should return a character string that replaces
        //  a passed pattern with another character string.
        public static string Replace(this string str, string pat, string sub)
        {
            int last = 0;  //  The last index.
            string res = "";
            int patternLength = pat.Length;
            for (int i = 0, len1 = str.Length; i != len1; ++i)
            {
                int j = i;
                int k = 0;
                while (k != patternLength && str[j] == pat[k])
                {
                    ++j;
                    ++k;
                }
                if (k == patternLength)
                {
                    for (int l= last, len2 = j - patternLength; l != len2; ++l)
                    {
                        res += str[l];
                    }
                    last = j;
                    res += sub;
                }
                else if (i == len1 - patternLength)
                {
                    for (int l = last; l != len1; ++l)
                    {
                        res += str[l];
                    }
                }
            }
            return res;
        }

        //  Should remove a character from a character string for
        //  every n position.
        public static string RemoveEvery(this string str, int n)
        {
            string res = "";
            for (int i = 0, len = str.Length; i != len; ++i)
            {
                if (i % n == 0)
                {
                    res += str[i];
                }
            }
            return res;
        }

        //  Should remove a character from a character string.
        public static string RemoveEvery(this string str, char c)
        {
            string res = "";
            for (int i = 0, len = str.Length; i != len; ++i)
            {
                if (str[i] != c)
                {
                    res += str[i];
                }
            }
            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mississippi".RemoveEvery('i'));
        }
    }
}
