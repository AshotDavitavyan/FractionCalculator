using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculator
{
	internal class Fraction
	{
		private int _numerator;
		private int _denominator;

		public Fraction(int numerator, int denominator)
		{
			try
			{
				Numerator = numerator;
				Denominator = denominator;
			}
			catch (ArgumentException ex)
			{
				throw;
			}
		}

		public int Numerator
		{
			get { return _numerator; }
			set { _numerator = value; }
		}
		public int Denominator
		{
			get { return _denominator; }
			set
			{
				if (value == 0)
					throw new ArgumentException("Denominator Cannot be equal to 0");

				_denominator = value;
			}
		}

		public static int LCM(int num1, int num2)
		{
			int biggerOne = num1 > num2 ? num1 : num2;
			Console.WriteLine(num1 + " " + num2);
            while (biggerOne % num1 != 0 || biggerOne % num2 != 0)
			{
				biggerOne++;
			}
			return biggerOne;
		}

		public static Fraction operator +(Fraction first, Fraction second)
		{
			int commonDenominator = LCM(first.Denominator, second.Denominator);

			int newNumerator1 = first.Numerator * (commonDenominator / second.Denominator);
			int newNumerator2 = second.Numerator * (commonDenominator / first.Denominator);

			int resultNumerator = (newNumerator1 + newNumerator2);
			return new Fraction(resultNumerator, commonDenominator);
		}

		public static Fraction operator -(Fraction first, Fraction second)
		{
			int commonDenominator = LCM(first.Denominator, second.Denominator);

			int newNumerator1 = first.Numerator * (commonDenominator / second.Denominator);
			int newNumerator2 = second.Numerator * (commonDenominator / first.Denominator);

			int resultNumerator = (newNumerator1 - newNumerator2);
			return new Fraction(resultNumerator, commonDenominator);
		}

		public static Fraction operator *(Fraction first, Fraction second)
		{
			int newNumerator = first.Numerator * second.Numerator;
			int newDenominator = first.Denominator * second.Denominator;

			return new Fraction(newNumerator, newDenominator);
		}

		public static Fraction operator /(Fraction first, Fraction second)
		{
			int tmp = second.Numerator;
			second.Numerator = second.Denominator;
			second.Denominator = tmp;
			return first * second;
		}

	}
}
