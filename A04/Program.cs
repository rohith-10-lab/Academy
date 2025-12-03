// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to display character frequency from a word list
// ------------------------------------------------------------------------------------------------
string[] words = File.ReadAllLines ("C:/Work/Academy/A04/bin/Debug/net9.0/words.txt");
var freq = words.SelectMany (w => w)
                .GroupBy (c => c)
                .OrderByDescending (g => g.Count ())
                .Take (7);
foreach (var g in freq) Console.WriteLine ($"{g.Key} -> {g.Count ()}");
