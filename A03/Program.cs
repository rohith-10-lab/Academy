// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to solve the NYT spelling bee by validating the words and computing score.
// ------------------------------------------------------------------------------------------------
using static System.Console;

string[] words = File.ReadAllLines ("C:/etc/words.txt");
char[] letters = ['U', 'X', 'A', 'L', 'T', 'N', 'E'];
List<(string word, int score, bool pangram)> result = [];
foreach (var word in GetValidWords (words)) {
   result.Add (ComputeScore (word));
}
int total = 0;
foreach (var (word, score, pangram) in result.OrderByDescending (x => x.score)
                                             .ThenBy (x => x.word)) {
   if (pangram) ForegroundColor = ConsoleColor.Green;
   WriteLine ($"{score,3}. {word}");
   ResetColor ();
   total += score;
}
WriteLine ($"----\n{total,3} total");

// Adds the valid words to a list
string[] GetValidWords (string[] words) => [.. words.Where (IsValid)];

// Validates the spelling bee conditions
bool IsValid (string word) =>
   word.Length >= 4 &&
   word.Contains (letters[0]) &&
   word.All (letters.Contains);

// Calculates the base score and applies the pangram bonus
(string Word, int Score, bool IsPangram) ComputeScore (string word) {
   var len = word.Length; var score = 1; var isPangram = false;
   if (len > 4) {
      score = len;
      if (len >= 7 && letters.All (word.Contains)) {
         score += 7; isPangram = true;
      }
   }
   return (word, score, isPangram);
}
