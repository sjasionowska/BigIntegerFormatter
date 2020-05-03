namespace BigIntegerFormatter
{
	using System;
	using System.Collections.Generic;
	using System.Numerics;
	using System.Text;

	public class NumericalFormatter
	{
		private const int PRECOMPUTE_FOUR_CHARACTERS = 531441; // 27 ^ 4

		private static List<string> preComputedBase27Values = preComputeBase27Values();

		private static List<string> preComputeBase27Values()
		{
			List<string> preComputedValues = new List<string>();

			for (int i = 0; i < PRECOMPUTE_FOUR_CHARACTERS; i++)
			{
				string text = ToBase27AlphaString(i);

				if (!text.Contains("`"))
				{
					preComputedValues.Add(text);
				}
			}

			return preComputedValues;
		}

		public string Format(BigInteger number)
		{
			return FormatNumberString(number.ToString());
		}

		private static string FormatNumberString(string number)
		{
			if (number.Length < 5)
			{
				return number;
			}

			if (number.Length < 7)
			{
				return FormatThousands(number);
			}

			return FormatGeneral(number);
		}

		private static string FormatThousands(string number)
		{
			string leadingNumbers = number.Substring(0, number.Length - 3);
			string decimals = number.Substring(number.Length - 3);

			return CreateNumericalFormat(leadingNumbers, decimals, "K");
		}

		private static string CreateNumericalFormat(string leadingNumbers, string decimals, string suffix)
		{
			return String.Format("{0}.{1}{2}", leadingNumbers, decimals, suffix);
		}

		private static string FormatGeneral(string number)
		{
			int amountOfLeadingNumbers = (number.Length - 7) % 3 + 1;
			string leadingNumbers = number.Substring(0, amountOfLeadingNumbers);
			string decimals = number.Substring(amountOfLeadingNumbers, 3);

			return CreateNumericalFormat(leadingNumbers, decimals, GetSuffixForNumber(number));
		}

		private static string GetSuffixForNumber(string number)
		{
			int numberOfThousands = (number.Length - 1) / 3;

			switch (numberOfThousands)
			{
				case 1: return "K";
				case 2: return "M";
				case 3: return "B";
				case 4: return "T";
				case 5: return "Q";
				default: return GetProceduralSuffix(numberOfThousands - 5);
			}
		}

		private static string GetProceduralSuffix(int numberOfThousandsAfterQ)
		{
			return preComputedBase27Values[numberOfThousandsAfterQ - 1];
		}

		private static string ToBase27AlphaString(int value)
		{
			return ToBaseNAlphaString(value, '`', 27);
		}

		private static string ToBaseNAlphaString(int value, char baseChar, int numericBase)
		{
			StringBuilder sb = new StringBuilder();

			while (value > 0)
			{
				int digit = value % numericBase;

				sb.Append((char)(baseChar + digit));
				value /= numericBase;
			}

			if (sb.Length == 0)
			{
				sb.Append(baseChar);
			}

			sb.Reverse();
			return sb.ToString();
		}
	}

	internal static class Extensions
	{
		public static void Reverse(this StringBuilder sb)
		{
			for (int i = 0,
			         j = sb.Length - 1;
			     i < sb.Length / 2;
			     i++, j--)
			{
				char chT = sb[i];

				sb[i] = sb[j];
				sb[j] = chT;
			}
		}
	}
}
