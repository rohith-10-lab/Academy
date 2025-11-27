// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to display character frequency from a word list
// ------------------------------------------------------------------------------------------------
string[] words = File.ReadAllLines ("words.txt");
Dictionary<char, int> freq = [];
foreach (var word in words) {
   foreach (var c in word) {
      if (freq.ContainsKey (c)) freq[c]++;
      else freq[c] = 1;
   }
}
foreach (var l in freq.OrderByDescending (x => x.Value).Take (7))
   Console.WriteLine ($"{l.Key} -> {l.Value}");
