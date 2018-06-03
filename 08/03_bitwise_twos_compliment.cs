namespace TC
{
    public static class BitOperations
    {
        private const int LENGTH = 16;
        public enum Bit { Zero, One };
        public static Bit And2(Bit a, Bit b)
        {
            Bit result = Bit.Zero;
            if ((a == Bit.One) && (b == Bit.One))
            {
                result = Bit.One;
            }
            return result;
        }
        public static Bit And3(Bit a, Bit b, Bit c)
        {
            Bit result = Bit.Zero;
            if ((a == Bit.One) && (b == Bit.One) && (c == Bit.One))
            {
                result = Bit.One;
            }
            return result;
        }
        public static Bit Or2(Bit a, Bit b)
        {
            Bit result = Bit.Zero;
            if ((a == Bit.One) || (b == Bit.One))
            {
                result = Bit.One;
            }
            return result;
        }
        public static Bit Or3(Bit a, Bit b, Bit c)
        {
            Bit result = Bit.Zero;
            if ((a == Bit.One) || (b == Bit.One) || (c == Bit.One))
            {
                result = Bit.One;
            }
            return result;
        }
        public static Bit Not(Bit unit)
        {
            Bit result = Bit.Zero;
            if (unit == Bit.One)
            {
                result = Bit.Zero;
            }
            else
            {
                result = Bit.One;
            }
            return result;
        }
        public static Bit Xor2(Bit a, Bit b)
        {
            Bit result = Bit.Zero;
            if (a != b)
            {
                result = Bit.One;
            }
            else
            {
                result = Bit.Zero;
            }
            return result;
        }
        public static Bit OnlyOne2(Bit a, Bit b)
        {
            Bit result = Bit.Zero;
            if (((a == Bit.One) && (b == Bit.Zero)) || ((a == Bit.Zero) && (b == Bit.One)))
            {
                result = Bit.One;
            }
            return result;
        }
        public static Bit OnlyOne3(Bit a, Bit b, Bit c)
        {
            Bit result = Bit.Zero;
            if (((a == Bit.One) && (b == Bit.Zero) && (c == Bit.Zero))
            || ((a == Bit.Zero) && (b == Bit.One) && (c == Bit.Zero))
            || ((a == Bit.Zero) && (b == Bit.Zero) && (c == Bit.One)))
            {
                result = Bit.One;
            }
            return result;
        }

        public static Bit FullAdder(Bit a, Bit b, Bit c)
        {
            return Or2(OnlyOne3(a, b, c), And3(a, b, c));
        }
        public static Bit FullAdderCarry(Bit a, Bit b, Bit c)
        {
            return Or2(OnlyOne3(Not(a), Not(b), Not(c)), And3(a, b, c));
        }
        public static Bit[] OnesCompliment(Bit[] a)
        {
            Bit[] result = new Bit[LENGTH];
            for (int index = 0; index < LENGTH; index++)
            {
                result[index] = Not(a[index]);
            }
            return result;
        }
        public static Bit[] Inc(Bit[] a, Bit CarryIn, ref Bit OverFlow)
        {
            Bit[] result = new Bit[LENGTH];
            Bit CarryOut = CarryIn;
            for(int index = 0; index < LENGTH; index++)
            {
                CarryIn = CarryOut;
                result[index] = BitOperations.Xor2(a[index], CarryIn);
                CarryOut = BitOperations.And2(a[index], CarryIn);
            }
            OverFlow = CarryOut;
            return result;
        }
        public static Bit[] Add(Bit[] a, Bit[] b, Bit CarryIn, ref Bit OverFlow)
        {
            Bit[] result = new Bit[LENGTH];
            Bit CarryOut = CarryIn;
            for (int index = 0; index < LENGTH; index++)
            {
                CarryIn = CarryOut;
                result[index] = FullAdder(a[index], b[index], CarryIn);
                CarryOut = FullAdderCarry(a[index], b[index], CarryIn);
            }
            OverFlow = CarryIn;
            return result;
        }
        public static int ConvertToInt(Bit[] a)
        {
            int result = 0;
            
            bool negative = false;
            Bit OverFlow = Bit.Zero;
            if (a[LENGTH-1] == Bit.One)
            {
                negative = true;
                a = Inc(OnesCompliment(a),Bit.One, ref OverFlow);
            }
            int position = 1;
            for(int index = 0; index < LENGTH; index++)
            {
                if (a[index] == Bit.One)
                {
                    result += position;
                }
                position += position; // doubles
            }
            if (negative) result = 0 - result;
            return result;
        }
        public static Bit[] ConvertToBitArray(int value)
        {
            Bit[] result = new Bit[LENGTH];
            int position = 1;
            for(int index = 0; index < LENGTH; index++)
            {
                if ((value & position) != 0)
                {
                    result[index] = Bit.One;
                } else {
                    result[index] = Bit.Zero;
                }
                position += position;
            }
            return result;
        }
    }
    public class Program
    {
        public static void Main()
        {
            BitOperations.Bit OverFlow = BitOperations.Bit.Zero;
            BitOperations.Bit[] ThirtySix = BitOperations.ConvertToBitArray(36);
            BitOperations.Bit[] Fourteen = BitOperations.ConvertToBitArray(14);
            BitOperations.Bit[] Sum = BitOperations.Add(ThirtySix, Fourteen, BitOperations.Bit.Zero, ref OverFlow);
            OverFlow = BitOperations.Bit.Zero;
            BitOperations.Bit[] Dif2 = BitOperations.Add(ThirtySix, BitOperations.OnesCompliment(Fourteen), BitOperations.Bit.One, ref OverFlow);
            OverFlow = BitOperations.Bit.Zero;
            int result = BitOperations.ConvertToInt(Sum);
            System.Console.WriteLine(System.String.Format("Sum {0}",result));
            result = BitOperations.ConvertToInt(Dif2);
            System.Console.WriteLine(System.String.Format("Dif2 {0}", result));
        }
    }
}