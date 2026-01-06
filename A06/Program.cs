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
Solver (0);
PrintBoard (canonicalSolns);

// Backtracking: try all safe columns in this row and recurse to build full solutions.
void Solver (int r) {
   for (queens[r] = 0; queens[r] < N; queens[r]++) {
      // move to the next row, if recursion returns, backtrack and try next col
      if (IsSafe ()) {
         if (r == N - 1) AddSolution (queens);
         else Solver (r + 1);
      }
   }

   // Checks whether placing a queen at row r conflicts with any earlier queen.
   bool IsSafe () {
      for (int prevRow = 0; prevRow < r; prevRow++) {
         int dy = r - prevRow; int dx = Math.Abs (queens[r] - queens[prevRow]);
         if (dx == 0 || dx == dy) return false;
      }
      return true;
   }
}

// Checks all rotations and mirrors to determine whether this board is a new unique solution.
void AddSolution (int[] q) {
   // 0 -> identity, 1 -> 90, 2 -> 180, 3 -> 270
   for (int i = 0; i < 4; i++) {
      q = Rotated ();
      if (IsRecorded (q) || IsRecorded (Mirror ())) return;
   }
   canonicalSolns.Add ([.. q]);

   // Helper methods
   // 90 degree clockwise rotation
   int[] Rotated () {
      int[] rotated = new int[N];
      // (row, col) -> (col, N - 1 - row)
      for (int r = 0; r < N; r++) rotated[q[r]] = N - 1 - r;
      return rotated;
   }

   // Produces vertical mirror by reversing the row order
   int[] Mirror () => [.. q.Reverse ()];

   // Checks whether this board configuration has been stored before.
   bool IsRecorded (int[] q) => canonicalSolns.Any (board => board.SequenceEqual (q));
}

// Prints the NxN board with the queen pieces
void PrintBoard (List<int[]> boards) {
   OutputEncoding = new UnicodeEncoding ();
   int count = 1;
   foreach (var q in boards) {
      WriteLine (count++);
      string top = "┌" + string.Join ("┬", Enumerable.Repeat ("───", N)) + "┐";
      string mid = "├" + string.Join ("┼", Enumerable.Repeat ("───", N)) + "┤";
      string bot = "└" + string.Join ("┴", Enumerable.Repeat ("───", N)) + "┘";
      WriteLine (top);
      for (int r = 0; r < N; r++) {
         Write ("│");
         for (int c = 0; c < N; c++) Write ((q[r] == c) ? " ♕ │" : "   │");
         WriteLine ();
         if (r < N - 1) WriteLine (mid);
      }
      WriteLine (bot);
      WriteLine ();
   }
}
