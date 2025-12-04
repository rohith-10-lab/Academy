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
List<(int score, string word, bool pangram)> result = [];
foreach (var word in GetValidWords (words, letters, letters[0])) {
   bool pangram = IsPangram (word, letters);
   result.Add ((ComputeScore (word, pangram), word, pangram));
}
int total = 0;
foreach (var (score, word, pangram) in result.OrderByDescending (x => x.score)
                                             .ThenBy (x => x.word)) {
   if (pangram) ForegroundColor = ConsoleColor.Green;
   WriteLine ($"{score,3}. {word}");
   ResetColor ();
   total += score;
}
WriteLine ($"----\n{total,3} total");

// Adds the valid words to a list
string[] GetValidWords (string[] words, char[] letters, char mandatory) =>
    [.. words.Where (w => IsValid (w, letters, mandatory))];

// Validates the spelling bee conditions
bool IsValid (string word, char[] letters, char mandatory) =>
   word.Length >= 4 &&
   word.Contains (mandatory) &&
   word.All (letters.Contains);

// Calculates the base score and applies the pangram bonus
int ComputeScore (string word, bool pangram) =>
   (word.Length == 4 ? 1 : word.Length) + (pangram ? 7 : 0);

// Checks whether the word uses every character from letters
bool IsPangram (string word, char[] letters) => letters.All (word.Contains);
