// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to place N queens in a NxN board so that no queen can attack any other .
// ------------------------------------------------------------------------------------------------
using System.Text;
using static System.Console;

OutputEncoding = new UnicodeEncoding ();
int N = 8;
// Only 1 queen is placed per row, so this 1D array fully describes a board
int[] queens = new int[N];
HashSet<string> canonicalSolns = [];
int count = 0;
Solver (0);

// Backtracking: try all safe columns in this row and recurse to build full solutions.
void Solver (int row) {
   for (int col = 0; col < N; col++) {
      if (IsSafe (row, col)) {
         queens[row] = col;
         Solver (row + 1); // move to the next row, if recursion returns, backtrack and try next col
      }
   }
   if (row == N) {
      if (IsUniqueSoln (queens)) {
         WriteLine (count);
         PrintBoard (queens);
         WriteLine ();
      }
      // A full soln is processed, go back to prev row and so its loop can try the next col,
      // to find another valid soln
      return;
   }
}

// Checks whether placing a queen at (newRow, newCol) conflicts with any earlier queen.
bool IsSafe (int newRow, int newCol) {
   for (int prevRow = 0; prevRow < newRow; prevRow++) {
      int prevCol = queens[prevRow];
      if (prevCol == newCol) return false;
      if (Math.Abs (prevRow - newRow) == Math.Abs (prevCol - newCol)) return false; // diagonal
   }
   return true;
}

// Checks all rotations and mirrors to determine whether this board is a new unique solution.
bool IsUniqueSoln (int[] q) {
   int[] variant = (int[])q.Clone ();
   // 0 -> identity, 1 -> 90, 2 -> 180, 3 -> 270
   for (int i = 0; i < 4; i++) {
      if (IsRecorded (variant)) return false;
      if (IsRecorded (Mirror (variant))) return false;
      variant = Rotated (variant);
   }
   // unique → store
   canonicalSolns.Add (string.Concat (q));
   count++;
   return true;
}

// Checks whether this board configuration has been stored before.
bool IsRecorded (int[] q) => canonicalSolns.Contains (string.Concat (q));

// 90° clockwise rotation
int[] Rotated (int[] q) {
   int[] rotated = new int[N];
   // (row, col) → (col, N - 1 - row)
   for (int row = 0; row < N; row++) rotated[q[row]] = N - 1 - row;
   return rotated;
}

// Vertical mirror (left <-> right)
int[] Mirror (int[] q) {
   int[] mirror = new int[N];
   // row stays the same , (col) → (N - 1 - col)
   for (int i = 0; i < N; i++) mirror[i] = N - 1 - q[i];
   return mirror;
}

// Prints the NxN board with the queen pieces
void PrintBoard (int[] q) {
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
