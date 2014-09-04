using System;
using System.Collections.Generic;
using System.Linq;

namespace WrapLib
{
    public class Wrapper
    {
        public static string Wrap(string theText, int maximumColumnWidth)
        {
            // Check for the easy case!
            if (theText.Length <= maximumColumnWidth)
            {
                return theText;
            }
            else
            {
                List<string> lines = new List<string>();

                string currentLine = string.Empty;
                string seperator = string.Empty;

                // Split into seperate words
                var words = theText.Split(' ');

                foreach (string word in words)
                {
                    // Can we add the word to the current line?
                    if (currentLine.Length + seperator.Length + word.Length < maximumColumnWidth)
                    {
                        currentLine += seperator + word;
                        seperator = " ";
                    }
                    else
                    {
                        // Save away the current line
                        if (!string.IsNullOrEmpty(currentLine))
                            lines.Add(currentLine + (currentLine.Length != maximumColumnWidth ? " " : string.Empty));

                        seperator = "";

                        // Will the word fit on a single line?
                        if (word.Length <= maximumColumnWidth)
                            currentLine = word;
                        else
                        {
                            var splittedText = SplitIntoChunks(word, maximumColumnWidth);
                            currentLine = string.Join("-\r\n", splittedText);
                        }
                    }
                }

                //Make sure we save away the final line
                lines.Add(currentLine + (currentLine.Length != maximumColumnWidth ? " " : string.Empty));

                // Merge all our lines into one
                return string.Join("\r\n", lines).Trim();
            }

        }

        static List<string> SplitIntoChunks(string str, int chunkSize)
        {
            List<string> result = new List<string>();

            while (str.Length > chunkSize)
            {
                result.Add(str.Substring(0, chunkSize - 1));
                str = str.Substring(chunkSize - 1);
            }

            if (!string.IsNullOrEmpty(str))
                result.Add(str);

            return result;
        }

    }
}
