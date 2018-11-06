using RedGateTests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var wordDict = new Dictionary<string, int>();
            using (var reader = new SimpleCharacterReader())
            {
                string word;
                while ((word = _consumeWord(reader, out var endOfStream)) != null) {
                    if (!wordDict.ContainsKey(word))
                    {
                        wordDict.Add(word, 1);
                    }
                    else
                    {
                        wordDict[word]++;
                    }

                    if (endOfStream)
                    {
                        break;
                    }
                }
            } // dispose is implicitly called

            var wordFrequencyList = wordDict.Select(pair => new WordFrequency(pair.Key, pair.Value)).ToList();
            wordFrequencyList.Sort();

            return wordFrequencyList;
        }

        private string _consumeWord(ICharacterReader reader, out bool endOfStream)
        {
            var sb = new StringBuilder();
            endOfStream = false;
            try
            {
                char nextCharacter;
                while (!char.IsLetter(nextCharacter = reader.GetNextChar()))
                {
                    // drop non-letter characters
                }

                sb.Append(nextCharacter);
                while (char.IsLetter(nextCharacter = reader.GetNextChar()))
                {
                    sb.Append(nextCharacter);
                }
            }

            catch (EndOfStreamException)
            {
                // end of stream
                endOfStream = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

            return sb.ToString().ToLowerInvariant();
        }
    }
}
