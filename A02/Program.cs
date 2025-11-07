// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to guess a randomly generated number and provide feedback.
// ------------------------------------------------------------------------------------------------
using static System.Console;
using static System.ConsoleColor;

do {
   Clear ();
   int targetNum = new Random ().Next (1, 101);
   for (int tries = 1; tries <= 7; tries++) {
      int guess = GetInput (tries);
      var (msg, color) = CheckGuess (guess, targetNum, tries);
      PrintMsg (msg, color);
      if (guess == targetNum) break;
   }
   PrintMsg ("GAME OVER!\n", Red);
   Write ("Press Y to play again: ");
} while (ReadKey ().Key == ConsoleKey.Y);

// Compares the input with the target number and returns a feedback message with a color
(string, ConsoleColor) CheckGuess (int guess, int targetNum, int cnt) =>
   guess < targetNum ? ("Your guess is too low\n", Yellow) :
   guess > targetNum ? ("Your guess is too high\n", Yellow) :
   ($"You guessed correctly in {cnt} attempts\n", Green);

// Gets only integer as input from the user
int GetInput (int cnt) {
   for (; ; ) {
      Write ($"Attempt {cnt}! Guess a number between 1 and 100: ");
      if (int.TryParse (ReadLine (), out int guess) && guess is not < 1 or > 100) return guess;
      PrintMsg ("Enter a valid input.\n", Yellow);
   }
}

// Prints the message in given color
void PrintMsg (string msg, ConsoleColor color) {
   ForegroundColor = color;
   WriteLine (msg);
   ResetColor ();
}
