using RedGateTests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RedgateAssessment
{
    public class WordFrequencyAnalizer
    {
        private readonly ICharacterReader _reader;
        public WordFrequencyAnalizer(ICharacterReader reader)
        {
            _reader = reader;
        }

        public List<WordFrequency> Analize()
        {
            try
            {
                var wordDict = new Dictionary<string, int>();
                using (var reader = new SimpleCharacterReader())
                {
                    string word;
                    while (!string.IsNullOrEmpty(word = ConsumeWord()))
                    {
                        var lowercaseWord = word.ToLowerInvariant();
                        if (!wordDict.ContainsKey(lowercaseWord))
                        {
                            wordDict.Add(lowercaseWord, 1);
                        }
                        else
                        {
                            wordDict[lowercaseWord]++;
                        }
                    }
                } // dispose is implicitly called when exiting the using block

                var wordFrequencyList = wordDict.Select(pair => new WordFrequency(pair.Key, pair.Value)).ToList();
                wordFrequencyList.Sort();

                return wordFrequencyList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        
        public string ConsumeWord()
        {
            var sb = new StringBuilder();
            try
            {
                char nextCharacter;
                while (!char.IsLetter(nextCharacter = _reader.GetNextChar()))
                {
                    // drop non-letter characters
                }

                sb.Append(nextCharacter);
                while (char.IsLetter(nextCharacter = _reader.GetNextChar()))
                {
                    sb.Append(nextCharacter);
                }
            }

            catch (EndOfStreamException)
            {
                // end of stream
                return sb.ToString();
            }

            catch (Exception e)
            {
                throw e;
            }

            return sb.ToString().ToLowerInvariant();
        }
    }
}
