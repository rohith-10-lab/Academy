// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to place N queens in a NxN board so that no queen can attack any other .
// ------------------------------------------------------------------------------------------------
using System.Text;
using static System.Console;

const int N = 8;
// Only 1 queen is placed per row, so this 1D array fully describes a board
int[] queens = new int[N];
List<int[]> canonicalSolns = [];
int count = 1;
Solver (0);
foreach (var board in canonicalSolns) {
   WriteLine (count++);
   PrintBoard (board);
   WriteLine ();
}

// Backtracking: try all safe columns in this row and recurse to build full solutions.
void Solver (int row) {
   if (row == N) {
      if (IsUniqueSoln (queens)) canonicalSolns.Add ([.. queens]);
      // A full solution is processed, go back to prev row and so its loop can try the next col,
      // to find another valid solution
      return;
   }
   for (int col = 0; col < N; col++) {
      queens[row] = col;
      // move to the next row, if recursion returns, backtrack and try next col
      if (IsSafe (row)) Solver (row + 1);
   }
}

// Checks whether placing a queen at row r conflicts with any earlier queen.
bool IsSafe (int r) {
   for (int prevRow = 0; prevRow < r; prevRow++) {
      int dy = r - prevRow; int dx = Math.Abs (queens[r] - queens[prevRow]);
      if (dx == 0 || dx == dy) return false;
   }
   return true;
}

// Checks all rotations and mirrors to determine whether this board is a new unique solution.
bool IsUniqueSoln (int[] q) {
   int[] variant = [.. q];
   // 0 -> identity, 1 -> 90, 2 -> 180, 3 -> 270
   for (int i = 0; i < 4; i++) {
      if (IsRecorded (variant)) return false;
      if (IsRecorded (Mirror (variant))) return false;
      variant = Rotated (variant);
   }
   return true;

   // Helper methods
   // 90 degree clockwise rotation
   int[] Rotated (int[] q) {
      int[] rotated = new int[N];
      // (row, col) -> (col, N - 1 - row)
      for (int row = 0; row < N; row++) rotated[q[row]] = N - 1 - row;
      return rotated;
   }

   // Produces horizontal mirror by reversing the row order
   int[] Mirror (int[] q) {
      int[] mirror = [.. q];
      Array.Reverse (mirror);
      return mirror;
   }

   // Checks whether this board configuration has been stored before.
   bool IsRecorded (int[] q) => canonicalSolns.Any (board => board.SequenceEqual (q));
}

// Prints the NxN board with the queen pieces
void PrintBoard (int[] q) {
   OutputEncoding = new UnicodeEncoding ();
   string top = "┌" + string.Join ("┬", Enumerable.Repeat ("───", N)) + "┐";
   string mid = "├" + string.Join ("┼", Enumerable.Repeat ("───", N)) + "┤";
   string bot = "└" + string.Join ("┴", Enumerable.Repeat ("───", N)) + "┘";
   WriteLine (top);
   for (int row = 0; row < N; row++) {
      Write ("│");
      for (int col = 0; col < N; col++) Write ((q[row] == col) ? " ♕ │" : "   │");
      WriteLine ();
      if (row < N - 1) WriteLine (mid);
   }
   WriteLine (bot);
}
