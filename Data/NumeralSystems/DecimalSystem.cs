namespace NotationCalculator.Data.NumeralSystems
{
    public class DecimalSystem : NumeralSystem
    {
        public DecimalSystem(string value)
            : base("1234567890", value)
        {
            
        }
        
        public override string ConvertToDecimal() =>
            Value;
    }
}