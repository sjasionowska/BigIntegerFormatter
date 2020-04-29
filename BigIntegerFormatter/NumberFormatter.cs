namespace BigIntegerFormatter
{
	using System.Collections.Generic;
	using System.Numerics;

	public class NumberFormatter
	{
		public static string FormatScientific(BigInteger number)
		{
			return FormatNumberScientificString(number.ToString());
		}

		public static string FormatWithSuffix(BigInteger number)
		{
			return FormatNumberWithSuffixString(number.ToString());
		}

		private static string FormatNumberScientificString(string numberString)
		{
			if (numberString.Length < 3)
			{
				return numberString;
			}

			int exponent = numberString.Length - 1;
			string leadingDigit = numberString.Substring(0, 1);
			string decimals = numberString.Substring(1, 3);

			return string.Format("{0}.{1}e{2}", leadingDigit, decimals, exponent);
		}

		private static string FormatNumberWithSuffixString(string numberString)
		{
			if (numberString.Length < 3)
			{
				return numberString;
			}

			var exponentIndex = numberString.Length - 1;
			var suffixes = new List<string>
			{
				"", "k", "M", "B", "a", "b", "c"
			};

			// numbers before a coma
			var leadingDigit = "";

			// numbers after a comma 
			var decimals = "";

			switch (exponentIndex % 3)
			{
				case 0:
					leadingDigit = numberString.Substring(0, 1);
					decimals = numberString.Substring(1, 3);
					break;

				case 1:
					leadingDigit = numberString.Substring(0, 2);
					decimals = numberString.Substring(2, 3);
					break;

				case 2:
					leadingDigit = numberString.Substring(0, 3);
					decimals = numberString.Substring(3, 3);
					break;
			}

			var numberWithoutSuffix = $"{leadingDigit}.{decimals}";
			numberWithoutSuffix = numberWithoutSuffix.TrimEnd('0').TrimEnd('.');

			return $"{numberWithoutSuffix}{suffixes[exponentIndex / 3]}";
		}
	}

}
