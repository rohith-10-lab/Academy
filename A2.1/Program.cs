// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to find a number by identifying its bits using remainder based questions.
// ------------------------------------------------------------------------------------------------
using static System.Console;

WriteLine ("Please think of a number, and I will find it.\n");
WriteLine ($"\nYour number is: {FindNum ()}");

// Finds the number using remainder based questions
static int FindNum () {
   int num = 0;
   for (int bitIndex = 0; bitIndex <= 6; bitIndex++) {
      int bitMask = 1 << bitIndex;
      ConsoleKey key;
      while (true) {
         Write ($"Is your number % {1 << (bitIndex + 1)} equal to {num + bitMask}? (y/n): ");
         key = ReadKey ().Key;
         if (key == ConsoleKey.Y || key == ConsoleKey.N) break;
         WriteLine ("\nEnter y or n only.\n");
      }
      if (key == ConsoleKey.Y) num += bitMask;
      WriteLine ();
   }
   return num;
}
