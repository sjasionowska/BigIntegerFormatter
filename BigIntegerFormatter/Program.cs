namespace BigIntegerFormatter
{
	using System;
	using System.Numerics;

	// ReSharper disable once ClassNeverInstantiated.Global
	internal class Program
	{
		public static void Main()
		{
			// thousand
			var b1 = new BigInteger(1000);
			DoStuff(b1);

			var b2 = new BigInteger(10000);
			DoStuff(b2);

			var b3 = new BigInteger(100000);
			DoStuff(b3);

			// million
			var b4 = new BigInteger(1000000);
			DoStuff(b4);

			var b5 = new BigInteger(1254766);
			DoStuff(b5);

			// Console.ReadLine();
		}

		private static void DoStuff(BigInteger bigInteger)
		{
			var str = BigIntegerFormatter.FormatScientific(bigInteger);
			var str2 = BigIntegerFormatter.FormatWithSuffix(bigInteger);

			Console.WriteLine("Number: " + bigInteger);
			Console.WriteLine("FormatScientific: " + str);
			Console.WriteLine("FormatNormally: " + str2);
			Console.WriteLine();
		}
	}
}
