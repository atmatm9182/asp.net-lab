namespace laboratorium2.Models
{
    public class Calculator
    {
        public Operators? Operator { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }

        private Dictionary<Operators, string> _opDic = new()
        {
            { Operators.Add, "+" },
            { Operators.Sub, "-" },
            { Operators.Mul, "&times;" },
            { Operators.Div, "&divide;" },
        };

        public string Op
        {
            get => _opDic[(Operators)Operator];
        }

        public bool IsValid()
        {
            return Operator != null && X != null && Y != null;
        }

        public double Calculate() => Operator switch
        {
            Operators.Add => (double)(X + Y),
            Operators.Sub => (double)(X - Y),
            Operators.Div => (double)(X / Y),
            Operators.Mul => (double)(X * Y),
        };

    }
}
