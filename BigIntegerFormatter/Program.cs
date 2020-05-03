namespace BigIntegerFormatter
{
	using System;
	using System.Numerics;

	// ReSharper disable once ClassNeverInstantiated.Global
	internal class Program
	{
		public static void Main()
		{
			var b0 = new BigInteger(0);
			DoStuff(b0);

			var b1 = new BigInteger(1234);
			DoStuff(b1);

			var b2 = BigInteger.Parse(
				"10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
			DoStuff(b2);
		}

		private static void DoStuff(BigInteger bigInteger)
		{
			var str = BigIntegerFormatter.FormatScientific(bigInteger);
			var str2 = BigIntegerFormatter.FormatWithSuffix(bigInteger);

			Console.WriteLine("Number: " + bigInteger);
			Console.WriteLine("FormatScientific: " + str);
			Console.WriteLine("FormatWithSuffix: " + str2);
			Console.WriteLine();
		}
	}
}
