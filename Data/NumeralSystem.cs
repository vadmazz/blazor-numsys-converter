using System;
using System.Collections.Generic;
using System.Linq;

namespace NotationCalculator.Data
{
    public class NumeralSystem
    {
        private readonly List<char> _alphabet;
        private Dictionary<char, int> _alphabetDictionary = new Dictionary<char, int>();
        private string _value;

        public NumeralSystem(string alphabet)
        {
            if (alphabet != null)
                _alphabet = new List<char>(alphabet);
            else
                throw new ArgumentNullException();
            for (var i = 0; i < _alphabet.Count; i++)
            {
                _alphabetDictionary.Add(_alphabet[i], i);
            }
        }
        
        public NumeralSystem(string alphabet, string number)
            : this(alphabet)
        {
            if (number != null)
            {
                if (!Contains(number))
                    throw new WrongNumberException();
                _value = number;
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
            
            for (var i = 0; i < _value.Length; ++i)
            {
                var val = _alphabetDictionary[_value[_value.Length - i - 1]];
                //var val = (int)Char.GetNumericValue(Value[Value.Length - i - 1]);
                
                result += val * (int) Math.Pow(power, i);
            }

            return result.ToString();
        }
        /// <summary>
        /// Convert Numeral System value into new Numeral System
        /// </summary>
        /// <param name="aimSystem">Target Numeral System instance</param>
        /// <returns></returns>
        public virtual string ConvertToAny(NumeralSystem aimSystem)
        {
            var dec = int.Parse(ConvertToDecimal());//переводим число в десятичную
            var intnum = 0;
            var targetPower = aimSystem._alphabet.Count;
            var remainder = 0;
            var result = "";// остаток
            
            intnum = Math.DivRem(dec, targetPower,out remainder);
            result = $"{FindByValue(remainder, aimSystem)}";
            
            while (intnum >= targetPower)
            {
                //получаем целое число от деления
                intnum = Math.DivRem(intnum, targetPower,out remainder);
                result = $"{FindByValue(remainder, aimSystem)}" + result;
            }
            Math.DivRem(intnum, targetPower,out remainder);
            if (remainder != 0)
            {
                result = $"{FindByValue(intnum, aimSystem)}" + result;
            }
            
            return result;
        }

        private string FindByValue(int value, NumeralSystem sys) =>
            sys._alphabetDictionary
                .First(pair => pair.Value == value).Key.ToString();
    }
}