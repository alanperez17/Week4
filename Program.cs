using AoC2023_Week5;

//var myInput = File.ReadAllLines(@"../../../PuzzleInput.txt");
var myInput = File.ReadAllLines(@"../../../PuzzleInput_Test.txt");

bool solveFirstPuzzle = true;
bool solveSecondPuzzle = true;

var seedLocations = SeedHandler.RetrieveNumbers(myInput, 0);

if (solveFirstPuzzle)
{
    PuzzleSolver.Solve(myInput, seedLocations);
}

if (solveSecondPuzzle)
{
    var puzzle2SeedLocations = SeedHandler.GetSeedsForPuzzleTwo(seedLocations);
    PuzzleSolver.Solve(myInput, puzzle2SeedLocations);
}

Console.ReadKey();