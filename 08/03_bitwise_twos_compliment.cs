namespace TC
{
    public static class BitOperations
    {
        private const int LENGTH = 16;
        public enum Bit { Zero, One };

        /// <summary>
        /// Calculates the And of two inputs
        /// </summary>
        /// <param name="a">Input a</param>
        /// <param name="b">Input b</param>
        /// <returns>a and b</returns>
        //   0  0    0
        //   0  1    0
        //   1  0    0
        //   1  1    1
        public static Bit And(Bit a, Bit b)
        {
            Bit result = Bit.Zero;
            if ((a == Bit.One) && (b == Bit.One))
            {
                result = Bit.One;
            }
            return result;
        }

        /// <summary>
        /// Calculates the And of three inputs
        /// </summary>
        /// <param name="a">Input a</param>
        /// <param name="b">Input b</param>
        /// <param name="c">Input c</param>
        /// <returns>a and b and c</returns>
        //    0  0  0    0
        //    0  0  1    0
        //    0  1  0    0
        //    0  1  1    0
        //    1  0  0    0
        //    1  0  1    0
        //    1  1  0    0
        //    1  1  1    1
        public static Bit And(Bit a, Bit b, Bit c)
        {
            Bit result = Bit.Zero;
            if ((a == Bit.One) && (b == Bit.One) && (c == Bit.One))
            {
                result = Bit.One;
            }
            return result;
        }

        /// <summary>
        /// Calculates the Or of two inputs
        /// </summary>
        /// <param name="a">Input a</param>
        /// <param name="b">Input b</param>
        /// <returns>a or b</returns>
        //   0  0   0
        //   0  1   1
        //   1  0   1
        //   1  1   1
        public static Bit Or(Bit a, Bit b)
        {
            Bit result = Bit.Zero;
            if ((a == Bit.One) || (b == Bit.One))
            {
                result = Bit.One;
            }
            return result;
        }

        /// <summary>
        /// Calcultes the Or of three inputs
        /// </summary>
        /// <param name="a">Input a</param>
        /// <param name="b">Input b</param>
        /// <param name="c">Input c</param>
        /// <returns>a or b or c</returns>
        //  0  0  0     0
        //  0  0  1     1
        //  0  1  0     1
        //  0  1  1     1
        //  1  0  0     1
        //  1  0  1     1
        //  1  1  0     1
        //  1  1  1     1
        public static Bit Or(Bit a, Bit b, Bit c)
        {
            Bit result = Bit.Zero;
            if ((a == Bit.One) || (b == Bit.One) || (c == Bit.One))
            {
                result = Bit.One;
            }
            return result;
        }

        /// <summary>
        /// Calculates the inverse of the input
        /// </summary>
        /// <param name="unit">Input unit</param>
        /// <returns>inverse of input</returns>
        //  0   1
        //  1   0
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

        /// <summary>
        /// Calculates the XOR of 2 bits
        /// </summary>
        /// <param name="a">Input a</param>
        /// <param name="b">Input b</param>
        /// <returns>1 if inputs are different</returns>
        //  0  0    0
        //  0  1    1
        //  1  0    1
        //  1  1    0
        public static Bit Xor(Bit a, Bit b)
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

        /// <summary>
        /// Calculates the number of set bits in input
        /// </summary>
        /// <param name="a">Input a</param>
        /// <param name="b">Input b</param>
        /// <returns>1 if there is exactly on set bit in the inputs</returns>
        //   0  0    0
        //   0  1    1
        //   1  0    1
        //   1  1    0

        public static Bit ExactlyOne(Bit a, Bit b)
        {
            Bit result = Bit.Zero;
            if (((a == Bit.One) && (b == Bit.Zero)) || ((a == Bit.Zero) && (b == Bit.One)))
            {
                result = Bit.One;
            }
            return result;
        }

        /// <summary>
        /// Calculates the number of set bits in input
        /// </summary>
        /// <param name="a">Input a</param>
        /// <param name="b">Input b</param>
        /// <param name="c">Input c</param>
        /// <returns>1 if there is exactly on set bit in the inputs</returns>
        //   0 0 0   0
        //   0 0 1   1
        //   0 1 0   1
        //   0 1 1   0
        //   1 0 0   1
        //   1 0 1   0
        //   1 1 0   0
        //   1 1 1   0
        public static Bit ExactlyOne(Bit a, Bit b, Bit c)
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

        /// <summary>
        /// Calculates the Sum part of a Full Carry adder
        /// </summary>
        /// <param name="a">Input a</param>
        /// <param name="b">Input b</param>
        /// <param name="c">Input c AKA carry in</param>
        /// <returns></returns>
        //   0 0 0   0
        //   0 0 1   1
        //   0 1 0   1
        //   0 1 1   0
        //   1 0 0   1
        //   1 0 1   0
        //   1 1 0   0
        //   1 1 1   1
        public static Bit FullAdderSum(Bit a, Bit b, Bit c)
        {
            return Or(ExactlyOne(a, b, c), And(a, b, c));
        }

        /// <summary>
        /// Calculates the Carry part of a Full Carry adder
        /// </summary>
        /// <param name="a">Input a</param>
        /// <param name="b">Input b</param>
        /// <param name="c">Input c AKA carry in</param>
        /// <returns></returns>
        //   0 0 0   0
        //   0 0 1   0
        //   0 1 0   0
        //   0 1 1   1
        //   1 0 0   0
        //   1 0 1   1
        //   1 1 0   1
        //   1 1 1   1
        public static Bit FullAdderCarry(Bit a, Bit b, Bit c)
        {
            return Or(ExactlyOne(Not(a), Not(b), Not(c)), And(a, b, c));
        }

        /// <summary>
        /// Returns the inverse of the input
        /// </summary>
        /// <param name="a">The input</param>
        /// <returns>obnes compliment of the input</returns>
        //  0 0 0    1 1 1
        //  0 0 1    1 1 0
        //  0 1 0    1 0 1
        //  0 1 1    1 0 0
        //  1 0 0    0 1 1
        //  1 0 1    0 1 0
        //  1 1 0    0 0 1
        //  1 1 1    0 0 0
        public static Bit[] OnesCompliment(Bit[] a)
        {
            Bit[] result = new Bit[LENGTH];
            for (int index = 0; index < LENGTH; index++)
            {
                result[index] = Not(a[index]);
            }
            return result;
        }

        /// <summary>
        /// Returns the sum of the input, and 1
        /// </summary>
        /// <param name="a">the input</param>
        /// <param name="OverFlow">Set if we inc from maximum number</param>
        /// <returns>Input incremented by one</returns>
        //  0 0 0     0 0 0 1
        //  0 0 1     0 0 1 0
        //  0 1 0     0 0 1 1
        //  0 1 1     0 1 0 0
        //  1 0 0     0 1 0 1
        //  1 0 1     0 1 1 0
        //  1 1 0     0 1 1 1
        //  1 1 1     1 0 0 0
        public static Bit[] Inc(Bit[] a, ref Bit OverFlow)
        {
            Bit[] result = new Bit[LENGTH];
            Bit CarryIn = Bit.One;
            Bit CarryOut = CarryIn;
            for(int index = 0; index < LENGTH; index++)
            {
                CarryIn = CarryOut;
                result[index] = BitOperations.Xor(a[index], CarryIn);
                CarryOut = BitOperations.And(a[index], CarryIn);
            }
            OverFlow = CarryOut;
            return result;
        }

        /// <summary>
        /// Calulates the two's compliment of a number
        /// </summary>
        /// <param name="a">Input a</param>
        /// <returns>Two's compliment of input</returns>
        //  0 0 0 0     0 0 0 0   +0 => +0
        //  0 0 0 1     1 1 1 1   +1 => -1
        //  0 0 1 0     1 1 1 0   +2 => -2
        //  0 0 1 1     1 1 0 1   +3 => -3
        //  0 1 0 0     1 1 0 0   +4 +> -4
        //  0 1 0 1     1 0 1 1   +5 => -5
        //  0 1 1 0     1 0 1 0   +6 => -6
        //  0 1 1 1     1 0 0 1   +7 => -7
        //  1 0 0 0     1 0 0 0   -0 => -0
        //  1 0 0 1     0 1 1 1   -7 => +7
        //  1 0 1 0     0 1 1 0   -6 => +6
        //  1 0 1 1     0 1 0 1   -5 => +5
        //  1 1 0 0     0 1 0 0   -4 => +4
        //  1 1 0 1     0 0 1 1   -3 => +3
        //  1 1 1 0     0 0 1 0   -2 => +2
        //  1 1 1 1     0 0 0 1   -1 => +1
        public static Bit[] TwosCompliment(Bit[] a)
        {
            Bit OverFlow = Bit.Zero;
            Bit[] onesCompliment = OnesCompliment(a);
            return Inc(onesCompliment, ref OverFlow);
        }

        /// <summary>Performs an Add operation using a Full Adder</summary>
        /// <param name="a">Input a</param>
        /// <param name="b">Input b</param>
        /// <param name="CarryIn">Carry in  from previous stage</param>
        /// <param name="OverFlow">output overflow flag</param>
        /// <returns>Input incremented by one</returns>
        public static Bit[] Add(Bit[] a, Bit[] b, Bit CarryIn, ref Bit OverFlow)
        {
            Bit[] result = new Bit[LENGTH];
            Bit CarryOut = CarryIn;
            for (int index = 0; index < LENGTH; index++)
            {
                CarryIn = CarryOut;
                result[index] = FullAdderSum(a[index], b[index], CarryIn);
                CarryOut = FullAdderCarry(a[index], b[index], CarryIn);
            }
            OverFlow = CarryIn;
            return result;
        }

        /// <summary>
        /// Subtracts b from a without the Inc of conv b to two's compliment
        /// </summary>
        /// <param name="a">Input a</param>
        /// <param name="b">Input b</param>
        /// <returns>difference between a and b</returns>
        public static Bit[] FastSubtract(Bit[] a, Bit[] b, ref Bit UnderFlow)
        {
            Bit[] onesCompliment = OnesCompliment(b);
            return Add(a, onesCompliment, Bit.One, ref UnderFlow);
        }

        /// <summary>
        /// Subtracts a from b my adding a and the two's compliment of b
        /// </summary>
        /// <param name="a">Input a</param>
        /// <param name="b">Input b</param>
        /// <returns>diffence between a and b</returns>
        public static Bit[] Subract(Bit[] a, Bit[] b, ref Bit UnderFlow)
        {
            Bit[] twosCompliment = TwosCompliment(b); // requires additional Inc step
            return Add(a, twosCompliment, Bit.Zero, ref UnderFlow);
        }

        /// <summary>
        /// Converts a Bit array to an integer
        /// </summary>
        /// <param name="a">Input a</param>
        /// <returns>integer view of the bit array</returns>
        public static int ConvertToInt(Bit[] a)
        {
            int result = 0;
            
            bool negative = false;
            Bit OverFlow = Bit.Zero;
            if (a[LENGTH-1] == Bit.One)
            {
                negative = true;
                Bit[] onesCompliment = OnesCompliment(a);
                a = Inc(onesCompliment, ref OverFlow);
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

        /// <summary>
        /// Converts anteger to bit array
        /// </summary>
        /// <param name="value">Input value</param>
        /// <returns>bit array view of input integer</returns>
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
            BitOperations.Bit UnderFlow = BitOperations.Bit.Zero;


            int nNegTwentyTwo = 0;
            int nFourteen = 14;
            int nTwentyTwo = 0;
            int nThirtySix = 36;
            int nFifty = 0;
            
            BitOperations.Bit[] ThirtySix = BitOperations.ConvertToBitArray(nThirtySix);
            BitOperations.Bit[] Fourteen = BitOperations.ConvertToBitArray(nFourteen);
            BitOperations.Bit[] Fifty = BitOperations.Add(ThirtySix, Fourteen, BitOperations.Bit.Zero, ref OverFlow);
            nFifty = BitOperations.ConvertToInt(Fifty);
            System.Console.WriteLine("{0} plus {1} = {2}", nThirtySix, nFourteen, nFifty);

            UnderFlow = BitOperations.Bit.Zero;
            BitOperations.Bit[] TwentyTwo = BitOperations.Subract(ThirtySix, Fourteen, ref UnderFlow);
            nTwentyTwo = BitOperations.ConvertToInt(TwentyTwo);
            System.Console.WriteLine("{0} minus {1} = {2}", nThirtySix, nFourteen, nTwentyTwo);

            UnderFlow = BitOperations.Bit.Zero;
            BitOperations.Bit[] NegTwentyTwo = BitOperations.Subract(Fourteen, ThirtySix, ref UnderFlow);
            nNegTwentyTwo = BitOperations.ConvertToInt(NegTwentyTwo);
            System.Console.WriteLine("{0} minus {1} = {2}", nFourteen, nThirtySix, nNegTwentyTwo);

            UnderFlow = BitOperations.Bit.Zero;
            TwentyTwo = BitOperations.ConvertToBitArray(0); // set to zero, to verify calculation is correct
            nTwentyTwo = 0;
            TwentyTwo = BitOperations.FastSubtract(ThirtySix, Fourteen, ref UnderFlow);
            nTwentyTwo = BitOperations.ConvertToInt(TwentyTwo);
            System.Console.WriteLine("{0} fast minus {1} = {2}", nThirtySix, nFourteen, nTwentyTwo);

            UnderFlow = BitOperations.Bit.Zero;
            NegTwentyTwo = BitOperations.ConvertToBitArray(0); // set to zero, to verify calculation is correct
            nNegTwentyTwo = 0;
            NegTwentyTwo = BitOperations.FastSubtract(Fourteen, ThirtySix, ref UnderFlow);
            nNegTwentyTwo = BitOperations.ConvertToInt(NegTwentyTwo);
            System.Console.WriteLine("{0} fast minus {1} = {2}", nFourteen, nThirtySix, nNegTwentyTwo);
            
        }
    }
}
