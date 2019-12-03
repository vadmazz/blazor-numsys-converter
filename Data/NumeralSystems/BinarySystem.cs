using System;

namespace NotationCalculator.Data.NumeralSystems
{
    public class BinarySystem : NumeralSystem
    {
        public BinarySystem(string value) 
            : base("10", value)
        {
            
        }
        
        public override string ConvertToDecimal()
        {           
            var result = 0;
            for (int i = 0; i < Value.Length; ++i)   
            {
                if (Value[Value.Length - i - 1] == '1')
                {
                    result += (int) Math.Pow(2, i);
                }
            }
            
            return result.ToString();
        }
    }
}