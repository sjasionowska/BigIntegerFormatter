# BigIntegerFormatter

A few classes - Program.cs and BigIntegerFormatter.cs actually - that allows for formatting BigInteger numbers using scientific and engineering notations. 

Requires System.Runtime.Numerics NuGet package. 

Some of the concepts were taken from https://stackoverflow.com/questions/37907411/c-sharp-format-arbitrarily-large-biginteger-for-endless-game question from Thijs Riezebeek StackOverflow user.

# What is this

BigIntegerClass is a static class placed in this project. It allows for formatting BigInteger values to easy-to-read format: using scientific and engineering notations. 

It also trims zeros from the end of the number when using engineering notation. It doesn't trim zeros when using scientific notation - I just didn't feel like doing it since I didn't need that. 

When it comes to the engineering notation, this project uses a few pre-typed-in suffixes, such as: 
- empty string for the numbers smaller than 1000, 
- k for thousands, 
- M for millions, 
- B and Q ^likewise. 

For bigger numbers, it generates the suffixes, in order:

- a, b, ..., z - excluding k because of the thousands
- aa, bb, ..., zz

and so on.

# Examples

12345 can be returned as a string, formatted: 1.234e4 or 12.345k.  
10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000 can be returned as a string, formatted: 1.000e424 or 10hhhhhh.

# Where should I use this

It can be very useful when creating idle-clicker games or in other C# projects where you have to format big numbers.

# How to use

There are a few ways to use this thing.

## Use in BigIntegerFormatter project

Clone it, open, and create some BigIntegers in the **Main** method. There are already three of them so you can see how it works. There is a small method under the **Main** method called **DoStuff(BigInteger bigInteger)**. Use it to see your numbers formatted using scientific and engineering notations in the Console. 

Use **BigIntegerFormatter.FormatScientific(BigInteger bigInteger)** to get a string with the number formatted using scientific notation (e.g. 1.000e3).

Use **BigIntegerFormatter.FormatWithSuffix(BigInteger bigInteger)** to get the string with the number formatted using engineering notation (e.g. 1k).

## Use in other projects

Copy the **BigIntegerFormatter** class to your project. Create the BigInteger wherever you need to. (Note that you might need **BigInteger.Parse** method if the int value will be too big. You can see the example in the **Main** method.) 

Create a string using **BigIntegerFormatter.FormatWithSuffix(BigInteger bigInteger)** or **BigIntegerFormatter.FormatScientific(BigInteger bigInteger)** method, depending on which notation you want to get. 

