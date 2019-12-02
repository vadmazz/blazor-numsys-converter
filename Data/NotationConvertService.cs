using System;
using System.Threading.Tasks;
using NotationCalculator.Data.NumeralSystems;

namespace NotationCalculator.Data
{
    public class NotationConvertService
    {
        public string Convert(string par)
        {
            try
            {
                var d = new BinarySystem(par);
                return d.ConvertToDecimal();
            }
            catch (WrongNumberException e)
            {
                return "Число не принадлежит системе счисления!";
            }
        }
        
    }
}