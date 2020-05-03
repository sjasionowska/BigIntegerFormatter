namespace BigIntegerFormatter
{
	using System.Collections.Generic;
	using System.Numerics;

	/// <summary>
	/// Static class used to format the BigIntegers.
	/// </summary>
	public static class BigIntegerFormatter
	{
		// TODO: List of suffixes. Needs to be improved.
		private static List<string> suffixes = new List<string>
		{
			"", "k", "M", "B", "Q", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "l", "m"
		};

		/// <summary>
		/// Formats BigInteger using scientific notation. Returns a number without the exponent if the length
		/// of the number is smaller than 4.
		/// </summary>
		/// <param name="number">Number to format.</param>
		/// <returns>Returns string that contains BigInteger formatted using scientific notation.</returns>
		public static string FormatScientific(BigInteger number)
		{
			return FormatNumberScientificString(number.ToString());
		}

		/// <summary>
		/// Formats BigInteger using engineering notation - with a suffix. Returns a number without the
		/// suffix if the length of the number is smaller than 4.
		/// </summary>
		/// <param name="number">Number to format.</param>
		/// <returns>Returns string that contains BigInteger formatted using engineering notation.</returns>
		public static string FormatWithSuffix(BigInteger number)
		{
			return FormatNumberWithSuffixString(number.ToString());
		}

		private static string FormatNumberScientificString(string numberString)
		{
			// if number length is smaller than 4, just returns the number
			if (numberString.Length < 4) return numberString;

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

		private static string FormatNumberWithSuffixString(string numberAsString)
		{
			// if number length is smaller than 4, just returns the number
			if (numberAsString.Length < 4) return numberAsString;

			// Counts scientific exponent. This will be used to determine which suffix from the 
			// suffixes List should be used. 
			var exponentIndex = numberAsString.Length - 1;

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
					leadingDigit = numberAsString.Substring(0, 1);
					decimals = numberAsString.Substring(1, 3);
					break;

				case 1:
					leadingDigit = numberAsString.Substring(0, 2);
					decimals = numberAsString.Substring(2, 3);
					break;

				case 2:
					leadingDigit = numberAsString.Substring(0, 3);
					decimals = numberAsString.Substring(3, 3);
					break;
			}

			// Trims zeros from the number's end.
			var numberWithoutSuffix = $"{leadingDigit}.{decimals}";
			numberWithoutSuffix = numberWithoutSuffix.TrimEnd('0').TrimEnd('.');

			var suffix = GetSuffixForNumber(exponentIndex / 3);

			// Returns number in engineering format.
			// return $"{numberWithoutSuffix}{suffixes[exponentIndex / 3]}";

			return $"{numberWithoutSuffix}{suffix}";
		}

		/// <summary>
		/// Gets suffix under a given index which is actually a number of thousands.
		/// </summary>
		/// <param name="suffixIndex">Suffix index. Number of thousands.</param>
		/// <returns>Suffix under a given index - suffix for a given number of thousands.</returns>
		private static string GetSuffixForNumber(int suffixIndex)
		{
			string suffix;

			return suffixes[suffixIndex];

			// switch (suffixIndex)
			// {
			// 	case 0:
			// 		suffix = "";
			// 		break;
			// 	case 1:
			// 		suffix = "k";
			// 		break;
			// 	case 2:
			// 		suffix = "M";
			// 		break;
			// 	case 3:
			// 		suffix = "B";
			// 		break;
			// 	case 4:
			// 		suffix = "Q";
			// 		break;
			//
			// 	default: return GetProceduralSuffix(suffixIndex);
			// }
			//
			//
			//
			// return suffix;
		}

		private static string GetProceduralSuffix(int suffixIndex)
		{
			return "";
		}
	}
}
