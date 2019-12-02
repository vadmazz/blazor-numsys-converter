using System;
using System.Collections.Generic;
using System.Linq;

namespace NotationCalculator.Data
{
    public abstract class NumeralSystem
    {
        private readonly List<char> _alphabet;
        protected string Value;
        protected NumeralSystem(string alphabet, string number)
        {
            if (alphabet != null && number != null)
            {
                _alphabet = new List<char>();
                foreach (var symbol in alphabet)
                    _alphabet.Add(symbol);
                if (!Contains(number))
                    throw new WrongNumberException();
                Value = number;
            }
            else
                throw new ArgumentNullException();
        }
        private bool Contains(string number) =>
            number.All(x => _alphabet.Contains(x));
        public abstract string ConvertToDecimal();
    }
}