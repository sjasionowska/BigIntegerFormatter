namespace BigIntegerFormatter
{
	using System.Collections.Generic;
	using System.Numerics;

	/// <summary>
	/// Static class used to format the BigIntegers.
	/// </summary>
	public static class BigIntegerFormatter
	{
		/// <summary>
		/// Formats BigInteger using scientific notation.
		/// </summary>
		/// <param name="number">Number to format.</param>
		/// <returns>Returns string that contains BigInteger formatted using scientific notation.</returns>
		public static string FormatScientific(BigInteger number)
		{
			return FormatNumberScientificString(number.ToString());
		}

		/// <summary>
		/// Formats BigInteger using engineering notation - with suffix.
		/// </summary>
		/// <param name="number">Number to format.</param>
		/// <returns>Returns string that contains BigInteger formatted using engineering notation.</returns>
		public static string FormatWithSuffix(BigInteger number)
		{
			return FormatNumberWithSuffixString(number.ToString());
		}

		private static string FormatNumberScientificString(string numberString)
		{
			// if number length is smaller than 3, just returns the number
			if (numberString.Length < 3) return numberString;

			// Exponent counter. E.g. for 1000 it will be 3 and the number will
			// be presented as 1.000e3 because 1000.Length = 4
			var exponent = numberString.Length - 1;

			// Digit before a comma. Always only one.
			var leadingDigit = numberString.Substring(0, 1);

			// Digits after a comma. Always three of them.
			var decimals = numberString.Substring(1, 3);

			// Returns the number in scientific format. 
			// Example: 12345 -> 1.234e4
			return $"{leadingDigit}.{decimals}e{exponent}";
		}

		private static string FormatNumberWithSuffixString(string numberString)
		{
			// if number length is smaller than 3, just returns the number
			if (numberString.Length < 3) return numberString;

			// Counts scientific exponent. This will be used to determine which suffix from the 
			// suffixes List should be used. 
			var exponentIndex = numberString.Length - 1;

			// TODO: List of suffixes. Needs to be improved.
			var suffixes = new List<string>
			{
				"", "k", "M", "B", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m"
			};

			// Digits before a comma. Can be one, two or three of them - that depends on the exponentsIndex.
			var leadingDigit = "";

			// Digits after a comma. Always three of them or less, if the formatted number will have zero 
			// on its end.
			var decimals = "";

			// Example: if the number the methods is formatting is 12345, exponentsIndex is 4, 4 % 3 = 1. 
			// There will be two leading digits. There will be three decimals. Formatted number will look like:
			// 12.345k
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

			// Trims zeros from number's end.
			var numberWithoutSuffix = $"{leadingDigit}.{decimals}";
			numberWithoutSuffix = numberWithoutSuffix.TrimEnd('0').TrimEnd('.');

			// Returns number in engineering format.
			return $"{numberWithoutSuffix}{suffixes[exponentIndex / 3]}";
		}
	}
}
