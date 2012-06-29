namespace DateTimeParser
{
    using System;

    internal static class StringHelpers
    {
        public static string GetWord(this string sentance, int wordCount)
        {
            string split = sentance.Split()[wordCount - 1];
            return String.IsNullOrEmpty(split) ? sentance : split;
        }

        public static string GetStringAfterWord(this string sentance, int wordCount)
        {
            string returnString = String.Empty;
            string[] words = sentance.Split();
            for (int i = wordCount; i < words.Length; i++)
            {
                returnString += words[i] + " ";
            }
            return returnString.TrimEnd();
        }
    }
}