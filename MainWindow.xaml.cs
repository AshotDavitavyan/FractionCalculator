using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FractionCalculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			firstNM.Text = string.Empty;
			firstDN.Text = string.Empty;
			firstWH.Text = string.Empty;

			secondNM.Text = string.Empty;
			secondDN.Text = string.Empty;
			secondWH.Text = string.Empty;
			
			resultNM.Text = string.Empty;
			resultDN.Text = string.Empty;
			resultWH.Text = string.Empty;
			
			action.SelectedIndex = -1;
		}

		public int ConvertValue(string? value)
		{
			if (int.TryParse(value, out int valueInt))
			{
				return valueInt;
			}
			else
			{
				throw new ArgumentException("Invalid value");
			}
		}


		private Fraction CalculateValue(Fraction fraction1, Fraction fraction2)
		{
			fraction1.ConvertToImproperFraction();
			fraction2.ConvertToImproperFraction();
			Fraction? resultFraction = null;

			switch (action.Text)
			{
				case "+":
					resultFraction = fraction1 + fraction2;
					break;
				case "-":
					resultFraction = fraction1 - fraction2;
					break;
				case "*":
					resultFraction = fraction1 * fraction2;
					break;
				case "/":
					resultFraction = fraction1 / fraction2;
					break;
				default:
					throw new ArgumentException("Invalid action");
			}
			resultFraction.ConvertToProperFraction();
			return resultFraction;
		}

		private Fraction ConvertToFraction(string numeratorStr, string denominatorStr, string wholePartStr)
		{
			int numerator = ConvertValue(numeratorStr);
			int denominator = ConvertValue(denominatorStr);
			if (wholePartStr.Length == 0)
				return new Fraction(numerator, denominator);
			int wholePart = ConvertValue(wholePartStr);
			return new Fraction(numerator, denominator, wholePart);
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			try
			{
				Fraction fraction1 = ConvertToFraction(firstNM.Text, firstDN.Text, firstWH.Text);
				Fraction fraction2 = ConvertToFraction(secondNM.Text, secondDN.Text, secondWH.Text);
				Fraction answerFraction = CalculateValue(fraction1, fraction2);
				Console.WriteLine(answerFraction.Numerator + "/" + answerFraction.Denominator);
				resultNM.Text = answerFraction.Numerator.ToString();
				resultDN.Text = answerFraction.Denominator.ToString();
				resultWH.Text = (answerFraction.GetSign() + answerFraction.WholePart.ToString());
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}