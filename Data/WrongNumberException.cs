using System;

namespace NotationCalculator.Data
{
    public class WrongNumberException : Exception
    {
        public WrongNumberException()
            : base("Number does not exist in the number system")
        {
            
        }
    }
}