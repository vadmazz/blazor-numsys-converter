using System;

namespace NotationCalculator.Data
{
    public enum Letters
    {
        A = 10,
        B = 11,
        C = 12,
        D = 13,
        E = 14,
        F = 15,
        G = 16,
        H = 17,
        I = 18,
        J = 19
    }
    public class NotationConvertService
    {
        public ResultWithResponse Convert(string val1, string ns1, string ns2)
        {
            int alphabet1;
            int alphabet2;
            if (val1 == null || ns1 == null || ns2 == null)
                return new ResultWithResponse("Неверные значения", ConverterResponse.Error);
            
            if (!int.TryParse(ns1, out alphabet1))
                return new ResultWithResponse("Неверные значения", ConverterResponse.Error);
            
            if(!int.TryParse(ns2, out alphabet2))
                return new ResultWithResponse("Неверные значения", ConverterResponse.Error);
            
            try
            {
                var quaternarySystem = new NumeralSystem(CreateAlphabet(alphabet1), val1);
                var aimSystem = new NumeralSystem(CreateAlphabet(alphabet2));

                if (ns2 == "10")
                {
                    return new ResultWithResponse(quaternarySystem.ConvertToDecimal(), ConverterResponse.Ok);
                }
                return new ResultWithResponse(quaternarySystem.ConvertToAny(aimSystem), ConverterResponse.Ok);
            }
            catch (WrongNumberException)
            {
                return new ResultWithResponse("Число не принадлежит системе счисления", ConverterResponse.Error);
            }
            catch (FormatException)
            {
                return new ResultWithResponse("Неверные значения", ConverterResponse.Error);
            }
        }

        private string CreateAlphabet(int count)
        {
            var res = "";
            for (int i = 0; i < count; i++)
            {
                if (i >= 10)
                    res += $"{(Letters) i}";
                else
                    res += $"{i}";
            }

            return res;
        }
    }
}