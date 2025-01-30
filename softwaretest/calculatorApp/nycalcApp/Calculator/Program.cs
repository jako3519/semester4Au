using System;

namespace CalculatorApp{
    public class Calc{


        public double add(double a, double b ){
            return a+b;
        }
        public double subtract(double a, double b){
            return a-b;
        }

        public double multiply(double a, double b){
            return a*b;
        }

        public double power(double x, double exp){
            return Math.Pow(x, exp);
        }
    }

}
