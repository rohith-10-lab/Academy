// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to display character frequency from a word list
// ------------------------------------------------------------------------------------------------
using static System.Console;

string words = File.ReadAllText ("C:/etc/words.txt");
GetFreq2 ();
Console.WriteLine ("--------");
GetFreq1 ();

// Computes letter frequencies using LINQ
void GetFreq1 () {
   var freq1 = words.Where (char.IsLetter)
                    .GroupBy (c => c)
                    .OrderByDescending (g => g.Count ())
                    .Take (7);
   foreach (var g in freq1) WriteLine ($"{g.Key} -> {g.Count ()}");
}

// Computes letter frequencies using Dictionary
void GetFreq2 () {
   Dictionary<char, int> freq2 = [];
   foreach (var c in words.Where (char.IsLetter))
      freq2[c] = freq2.TryGetValue (c, out int value) ? ++value : 1;
   foreach (var g in freq2.OrderByDescending (x => x.Value).Take (7))
      WriteLine ($"{g.Key} -> {g.Value}");
}
