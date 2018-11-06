using System;

namespace RedgateAssessment
{
    public class WordFrequency: IComparable
    {
        private string _word;
        private int _frequency;

        public string Word => _word;
        public int Frequency => _frequency;

        public WordFrequency(string word, int frequency)
        {
            _word = word;
            _frequency = frequency;
        }

        public override string ToString()
        {
            return $"{_word} - {_frequency}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            if (obj is WordFrequency wf)
            {
                return Equals(wf);
            }

            return false;
        }

        public bool Equals(WordFrequency obj)
        {
            if (obj == null)
            {
                return false;
            }

            return _word == obj.Word && _frequency == obj.Frequency;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + _word.GetHashCode();

            return hash;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("The provided value cannot be null");
            }

            if (obj is WordFrequency wf)
            {
                return CompareTo(wf);
            }

            throw new ArgumentException("The provided value must be of type WordFrequency");
        }

        public int CompareTo(WordFrequency obj)
        {
            if (Equals(obj))
            {
                return 0;
            }

            int byFrequencyCompare = _frequency.CompareTo(obj.Frequency) * -1;

            if (byFrequencyCompare != 0)
            {
                return byFrequencyCompare;
            }

            return _word.ToLowerInvariant().CompareTo(obj.Word.ToLowerInvariant());
        }
    }
}
