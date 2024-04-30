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
		private int? _wholePart;

		public Fraction(int numerator, int denominator, int wholePart)
		{
			Numerator = numerator;
			Denominator = denominator;
			WholePart = wholePart;
		}

		public Fraction(int numerator, int denominator)
		{
			Numerator = numerator;
			Denominator = denominator;
			WholePart = null;
		}

		public int? WholePart 
		{
			get { return _wholePart; }
			set { _wholePart = value; }
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
            while (true)
			{
				if (biggerOne % num1 == 0 && biggerOne % num2 == 0)
					break;
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

		public string GetSign()
		{
			int numeratorSign = Numerator < 0 ? -1 : 1;
			int denominatorSign = Denominator < 0 ? -1 : 1;
			int wholePartSign = WholePart < 0 ? -1 : 1;
			int generalSign = numeratorSign * denominatorSign * wholePartSign;
			return (generalSign == -1 ? "-" : "");
		}

		public void ConvertToProperFraction()
		{
			if (Numerator < Denominator)
				return;
			if (WholePart == null)
				WholePart = 0;
			
			while (Numerator > Denominator)
			{
				Numerator -= Denominator;
				WholePart++;
			}
		}

		public void ConvertToImproperFraction()
		{
			if (WholePart == null)
				return;
			Numerator = WholePart.Value * Denominator + Numerator;
			WholePart = null;
		}

	}
}
