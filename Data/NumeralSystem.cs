using System;
using System.Collections.Generic;
using System.Linq;

namespace NotationCalculator.Data
{
    public class NumeralSystem
    {
        private readonly List<char> _alphabet;
        protected string Value;
        public NumeralSystem(string alphabet, string number)
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

        public virtual string ConvertToDecimal()
        {
            var result = 0;
            var power = _alphabet.Count;
            
            for (var i = 0; i < Value.Length; ++i)   
            {
                var val = (int)Char.GetNumericValue(Value[Value.Length - i - 1]);
                result += val * (int) Math.Pow(power, i);
            }

            return result.ToString();
        }
    }
}