using Week4;

// This is the main program flow. The following line reads the input lines from a text file.
var myInput = File.ReadAllLines(@"..\..\..\PuzzleInput.txt");

// Ths following methods solve the puzzles based on the input and return results to the console window.
PuzzleSolver.SolvePuzzle1(myInput);
PuzzleSolver.SolvePuzzle2(myInput);