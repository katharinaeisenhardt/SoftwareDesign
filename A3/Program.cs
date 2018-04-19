using System;
using System.Collections.Generic;

namespace A3
{
    class Program
    {
        static int input;
        static int f_base;
        static int t_base;
        static int systemnumber;
        static int sum;
        
        static void Main(string[] args)
        { 
           /* Console.WriteLine(ConvertDecimalToHexal(15));
           Console.WriteLine(ConvertHexalToDecimal(23));
           Console.WriteLine(ConvertToBaseFromDecimal(6,231));
           Console.WriteLine(ConvertToDecimalFromBase(6,1023)); */
           int result = ConvertNumberToBaseFromBase(231, 6,10);
           Console.WriteLine("Die Zahl "+ input +" aus dem "+ f_base +"er System wurde zur Zahl " + result + " aus dem "+ t_base +"er System konvertiert." );
        }
        
        public static int ConvertDecimalToHexal(int dec){
            ConvertToBaseFromDecimal(6,dec);
            return systemnumber;
        }

        public static int ConvertHexalToDecimal(int hexal){
            ConvertToDecimalFromBase(6,hexal);
            return sum;
        }

        public static int ConvertToBaseFromDecimal(int toBase, int dec){
            int divider;
            systemnumber = 0;
            List<int> residuals = new List<int>();
            if(0 <= dec && dec <= 1023){
                do{
                    int modulo = dec % toBase;
                    residuals.Add(modulo);
                    int dec_minus_modulo = dec - modulo;
                    divider = dec_minus_modulo/toBase;
                    dec = divider;
                }while(divider != 0);
            }
            residuals.Reverse();
            for(int i = 0; i<=residuals.Count-1; i++){
                systemnumber += residuals[i] * Convert.ToInt32(Math.Pow(10,residuals.Count-i-1));
            }
            return systemnumber;
        
        }
        public static int ConvertToDecimalFromBase(int fromBase, int number){
            sum = 0;
            int[] digits = new int[1 + (int)Math.Log10(number)];
                for(int i = digits.Length-1; i >= 0; i--){
                    int digit;
                    number = Math.DivRem(number, 10, out digit);
                    digits[i]=digit;
                }
                List<int> outputs = new List<int>();
                Array.Reverse(digits);
                for(int i= 0; i <= digits.Length-1; i++){
                    int multiplication = digits[i] * (int)Math.Pow(fromBase,i);
                    outputs.Add(multiplication);
                }
                for(int i= 0; i <= outputs.Count-1; i++){
                    sum = sum + outputs[i];
                }
                return sum;
        }

        static int ConvertNumberToBaseFromBase(int number, int toBase, int fromBase){
            systemnumber=0;
            input = number;
            t_base = toBase;
            f_base = fromBase;

            if(2 <= toBase && 10 >= toBase && fromBase <= 10 && fromBase >=2){
                int dec=0;
                dec = (ConvertToDecimalFromBase(fromBase,number));
                systemnumber = ConvertToBaseFromDecimal(toBase,dec);
                
            }
            return systemnumber;
        }
    }
}