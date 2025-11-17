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

// Finds the number using remainder based questions
static int FindNum () {
   int num = 0;
   for (int bitIndex = 0; bitIndex <= 6; bitIndex++) {
      int bitMask = 1 << bitIndex;
      while (true) {
         Write ($"Is your number % {1 << (bitIndex + 1)} equal to {num + bitMask}? (y/n): ");
         ConsoleKey key = ReadKey ().Key;
         WriteLine ();
         if (key == ConsoleKey.Y) { num += bitMask; break; }
         if (key == ConsoleKey.N) break;
         WriteLine ("Enter y or n only.\n");
      }
   }
   return num;
}
