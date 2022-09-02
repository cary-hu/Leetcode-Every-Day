using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hammingDistance​​
{
    internal class CanBeTypedWords​​
    {
        public int CanBeTypedWords(string text, string brokenLetters)
        {
            var words = text.Split(" ");
            var res = words.Length;
            foreach (var word in words)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    var charector = word[j];
                    if (brokenLetters.Contains(charector))
                    {
                        res--;
                        break;
                    }
                }
            }
            return res;
        }​​
    }
}
