// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to solve the NYT spelling bee by validating the words and computing score.
// ------------------------------------------------------------------------------------------------
using static System.Console;

string[] words = File.ReadAllLines ("words.txt");
char[] letters = ['U', 'X', 'A', 'L', 'T', 'N', 'E'];
char mandatory = letters[0];
List<(int score, string word)> result = [];
foreach (string word in GetValidWords (words, letters, mandatory))
   result.Add ((ComputeScore (word, letters), word));
result = [.. result.OrderByDescending (x => x.score).ThenBy (x => x.word)];
int total = 0;
foreach (var (Score, Word) in result) {
   if (IsPangram (Word, letters)) ForegroundColor = ConsoleColor.Green;
   WriteLine ($"{Score,3}. {Word}");
   ResetColor ();
   total += Score;
}
WriteLine ($"----\n{total,3} total");

// ------------------------------------------------------

// Adds the valid words to a list
List<string> GetValidWords (string[] words, char[] letters, char mandatory) {
   List<string> validWords = [];
   foreach (string word in words) if (IsValid (word, letters, mandatory)) validWords.Add (word);
   return validWords;
}

// Validates the spelling bee conditions
bool IsValid (string word, char[] letters, char mandatory) {
   if (word.Length < 4) return false;
   if (!word.Contains (mandatory)) return false;
   // Every character in word must be only from letters
   foreach (char c in word) {
      bool isOk = false;
      foreach (char l in letters) { if (c == l) { isOk = true; break; } }
      if (!isOk) return false;
   }
   return true;
}

// Calculates the base score and applies the pangram bonus
int ComputeScore (string word, char[] letters) {
   int len = word.Length;
   int score = (len == 4) ? 1 : len;
   if (IsPangram (word, letters)) score += 7;
   return score;
}

// Checks whether the word uses every character from letters
bool IsPangram (string word, char[] letters) {
   // Every character in letters must be in word
   foreach (char l in letters) if (!word.Contains (l)) return false;
   return true;
}
