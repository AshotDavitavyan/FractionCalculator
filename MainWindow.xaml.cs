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
			secondNM.Text = string.Empty;
			secondDN.Text = string.Empty;
			resultNM.Text = string.Empty;
			resultDN.Text = string.Empty;
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
			switch (action.Text)
			{
				case "+":
					return fraction1 + fraction2;
				case "-":
					return fraction1 - fraction2;
				case "*":
					return fraction1 * fraction2;
				case "/":
					return fraction1 / fraction2;
				default:
					throw new ArgumentException("Invalid action");
			}
		}

		private Fraction ConvertToFraction(string numeratorStr, string denominatorStr)
		{
			int numerator = ConvertValue(numeratorStr);
			int denominator = ConvertValue(numeratorStr);
			return new Fraction(numerator, denominator);
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			try
			{
				Fraction fraction1 = ConvertToFraction(firstNM.Text, firstDN.Text);
				Fraction fraction2 = ConvertToFraction(firstNM.Text, firstDN.Text);
				Fraction answerFraction = CalculateValue(fraction1, fraction2);
				resultNM.Text = answerFraction.Numerator.ToString();
				resultDN.Text = answerFraction.Denominator.ToString();
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}