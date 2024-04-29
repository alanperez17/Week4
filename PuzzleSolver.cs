//var myInput = File.ReadAllLines(@"../../../PuzzleInput.txt");
namespace AoC2023_Week5
{
    public class PuzzleSolver
    {
        public static void Solve(string[] input, List<long> seedLocations)
        {
            var convertedSeedLocation = new List<long> { };
            foreach (var seedLocation in seedLocations)
            {
                var seedNumber = seedLocation;
                for (int i = 1; i < input.Length; i++)
                {
                    if (input[i] == "") { continue; }
                    if (input[i][0] < 48 || input[i][0] > 57) { continue; }

                    var ConverterNumbers = SeedHandler.RetrieveNumbers(input, i);
                    seedNumber = SeedHandler.Converter(seedNumber, ConverterNumbers, out bool isConverted);

                    if (isConverted)
                    {
                        while (input[i] != "" && i < input.Length - 1)  // Move on to the next mapping lines if a conversion occurs.
                        {
                            i++;
                        }
                    }
                }
                convertedSeedLocation.Add(seedNumber);
                Console.WriteLine($"{seedLocation} converts to {seedNumber}");
            }
            Console.WriteLine($"The minimum converted value is {convertedSeedLocation.Min()}");
        }
    }
}