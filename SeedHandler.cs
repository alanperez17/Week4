namespace AoC2023_Week5
{
    public class SeedHandler
    {
        public static List<long> RetrieveNumbers(string[] input, int lineIndex)
        {
            string numberString = "";
            List<long> lineNumbers = [];

            for (int i = 0; i < input[lineIndex].Length; i++)
            {
                char character = input[lineIndex][i];
                bool isNumber = int.TryParse(character.ToString(), out _);


                if (i == input[lineIndex].Length - 1)   // checks if the digit is the last character in the line. If so, add it to the list.
                {
                    numberString += character;
                    lineNumbers.Add(long.Parse(numberString));
                    continue;
                }
                if (isNumber)
                {
                    numberString += character;
                    continue;
                }
                if (numberString.Length > 0)    // Adds the constructed number to the list if the current character is not a number.
                {
                    lineNumbers.Add(long.Parse(numberString));
                }
                numberString = "";
            }
            return lineNumbers;
        }

        public static long Converter(long seedNumber, List<long> ConversionNumbers, out bool isConverted)
        {
            long DestinationRangeStart = ConversionNumbers[0];
            long SourceRangeStart = ConversionNumbers[1];
            long RangeLength = ConversionNumbers[2];

            if (seedNumber < SourceRangeStart + RangeLength && seedNumber >= SourceRangeStart)
            {
                seedNumber += DestinationRangeStart - SourceRangeStart;
                isConverted = true;
                return seedNumber;
            }
            isConverted = false;
            return seedNumber;
        }

        public static List<long> GetSeedsForPuzzleTwo(List<long> inputSeeds)
        {
            var PuzzleTwoSeeds = new List<long>();

            for (long i = inputSeeds.Count; i != 0;)
            {
                for (long k = inputSeeds[1]; k > 0; k--)
                {
                    PuzzleTwoSeeds.Add(inputSeeds[0]);
                    inputSeeds[0]++;
                }
                inputSeeds.RemoveRange(0, 2);
                i = inputSeeds.Count;
            }
            return PuzzleTwoSeeds;
        }
    }
}