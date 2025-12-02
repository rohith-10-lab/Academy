// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to find your chosen number using remainder based questions.
// ------------------------------------------------------------------------------------------------
using static System.Console;

WriteLine ("Please think of a number between 0 and 127, and I will find it.\n");
WriteLine ($"\nYour number is: {FindNum ()}");

// Finds the number by determining each bit from LSB to MSB using remainder based questions
static int FindNum () {
   int num = 0;
   for (int bitIndex = 0; bitIndex <= 6; bitIndex++) {
      // Shift the value 1 left by bitIndex (2^bitIndex)
      var bitMask = 1 << bitIndex;
      while (true) {
         // If remainder matches this value, the bit is 1, otherwise the bit is 0
         Write ($"Is your number % {1 << (bitIndex + 1)} equal to {num + bitMask}? (y/n): ");
         var key = ReadKey ().Key;
         WriteLine ();
         // If bit is 1, update num
         if (key == ConsoleKey.Y) { num += bitMask; break; }
         if (key == ConsoleKey.N) break;
         WriteLine ("Enter y or n only.\n");
      }
   }
   return num;
}
