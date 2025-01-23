using labs.Classes;

namespace labs.Numbers;

[DeveloperInfo("Arina Gomza", "2025-01-25")]
public class Rational
{
        private int numerator; 
        private int denominator; 
        
        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменатель не может быть равен 0.");
            
            this.numerator = numerator;
            this.denominator = denominator;
            Simplify(); 
        }

        private void Simplify()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;
            
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        
        public static bool operator ==(Rational r1, Rational r2)
        {
            return r1.Equals(r2);
        }
        
        public static bool operator !=(Rational r1, Rational r2)
        {
            return !r1.Equals(r2);
        }
        
        public override bool Equals(object obj)
        {
            if (obj is Rational other)
            {
                return numerator == other.numerator && denominator == other.denominator;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return numerator.GetHashCode() ^ denominator.GetHashCode();
        }

        public static bool operator <(Rational r1, Rational r2)
        {
            return (double)r1 < (double)r2;
        }

        public static bool operator >(Rational r1, Rational r2)
        {
            return (double)r1 > (double)r2;
        }

        public static bool operator <=(Rational r1, Rational r2)
        {
            return (double)r1 <= (double)r2;
        }

        public static bool operator >=(Rational r1, Rational r2)
        {
            return (double)r1 >= (double)r2;
        }

        public static Rational operator +(Rational r1, Rational r2)
        {
            return new Rational(
                r1.numerator * r2.denominator + r2.numerator * r1.denominator,
                r1.denominator * r2.denominator);
        }

        public static Rational operator -(Rational r1, Rational r2)
        {
            return new Rational(
                r1.numerator * r2.denominator - r2.numerator * r1.denominator,
                r1.denominator * r2.denominator);
        }

        public static Rational operator *(Rational r1, Rational r2)
        {
            return new Rational(r1.numerator * r2.numerator, r1.denominator * r2.denominator);
        }

        public static Rational operator /(Rational r1, Rational r2)
        {
            if (r2.numerator == 0)
                throw new DivideByZeroException("Деление на 0 недопустимо.");
            return new Rational(r1.numerator * r2.denominator, r1.denominator * r2.numerator);
        }

        public static Rational operator %(Rational r1, Rational r2)
        {
            return new Rational(
                (r1.numerator * r2.denominator) % (r2.numerator * r1.denominator),
                r1.denominator * r2.denominator);
        }

        public static Rational operator ++(Rational r)
        {
            return r + new Rational(1, 1);
        }

        public static Rational operator --(Rational r)
        {
            return r - new Rational(1, 1);
        }

        public static explicit operator float(Rational r)
        {
            return (float)r.numerator / r.denominator;
        }

        public static explicit operator int(Rational r)
        {
            return r.numerator / r.denominator;
        }

        public override string ToString()
        {
            return denominator == 1 ? $"{numerator}" : $"{numerator}/{denominator}";
        }
}