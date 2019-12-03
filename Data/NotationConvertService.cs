using System;

namespace NotationCalculator.Data
{
    

    public class NotationConvertService
    {
        public ResultWithResponse Convert(string val1, string ns1, string ns2)
        {
            int alphabet1;
            int alphabet2;
            if (val1 == null || ns1 == null || ns2 == null)
                return new ResultWithResponse("Неверные значения"!, ConverterResponse.Error);
            if (!int.TryParse(ns1, out alphabet1) && !int.TryParse(ns2, out alphabet2))
                return new ResultWithResponse("Не инт"!, ConverterResponse.Error);//TODO:Вызывать метод CreateAlphabet и стринг передавать в конвертер
            try
            {
                var quaternarySystem = new NumeralSystem(alphabet1.ToString(), val1);
                return new ResultWithResponse(quaternarySystem.ConvertToDecimal(), ConverterResponse.Ok);
                quaternarySystem.ConvertToDecimal();
            }
            catch (WrongNumberException e)
            {
                return new ResultWithResponse("Число не принадлежит системе счисления!", ConverterResponse.Error);
            }
        }

        private string CreateAlphabet(int count)
        {
            string res = "";
            for (int i = 0; i < count; i++)
            {
                res += $"{i}";
            }

            return res;
        }
    }
}