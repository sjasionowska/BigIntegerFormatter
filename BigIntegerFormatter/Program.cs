namespace BigIntegerFormatter
{
	using System;
	using System.Numerics;

	// ReSharper disable once ClassNeverInstantiated.Global
	internal class Program
	{
		public static void Main()
		{
			var b0 = new BigInteger(1000000000000);
			DoStuff(b0);

			var b1 = new BigInteger(10000000000000);
			DoStuff(b1);

			var b2 = new BigInteger(10000000000000000);
			DoStuff(b2);

			var b3 = BigInteger.Parse(
				"10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");

			DoStuff(b3);

			var b4 = BigInteger.Parse(
				"10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");

			DoStuff(b4);

			// Console.ReadLine();
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
