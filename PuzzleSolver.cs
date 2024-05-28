namespace Week4
{
    /// <summary>
    /// This object contains methods that solve puzzle 1 and puzzle 2 for the 2023 week four Advent of Code challenge.
    /// </summary>
    public class PuzzleSolver
    {
        /// <summary>
        /// This method returns the result for the first puzzle of week four to the console window.
        /// </summary>
        /// 
        /// <param name="input">
        /// String Array. Includes a number of winning numbers and card numbers separated by a '|' character in each element.
        /// </param>
        /// 
        /// <remarks>
        /// This method processes the number of matches in each line in the input Array. A match occurs when a winning number in the line is equal to a card number in the same line.
        /// It tracks the total number of points scored, where:
        /// <list type="bullet"
        ///     <item><description>A line with one matching number adds one to the total.</description></item>
        ///     <item><description>A line with two matching numbers adds two to the total.</description></item>
        ///     <item><description>A line with three matching numbers adds four to the total.</description></item>
        ///     <item><description>And continuing to the next power of two for each additional matching number.</description></item>
        /// </list>
        /// </remarks>
        /// <returns>
        /// This method dose not return a value.
        /// </returns>
        public static void SolvePuzzle1(string[] input)
        {
            int total = 0;
            foreach (var line in input)
            {
                int lineMatches = 0;
                var myNumbers = new CardReader(line);
                myNumbers.StoreWinningNumbers();
                myNumbers.StoreCardNumbers();

                foreach (var number in myNumbers.WinningNumbers)
                {
                    if (myNumbers.CardNumbers.Contains(number))
                    {
                        lineMatches++;
                    }
                }

                if (lineMatches == 0) { continue; }
                else if (lineMatches == 1) { total += 1; }
                else { total += (int)Math.Pow(2, lineMatches - 1); }
            }
            Console.WriteLine($"The first puzzle total is: {total}");
        }
        /// <summary>
        /// This method returns the result for the second puzzle of week four to the console window.
        /// </summary>
        /// 
        /// <param name="input">
        /// String Array. Includes a number of winning numbers and card numbers separated by a '|' character in each element.
        /// </param>
        /// 
        /// <remarks>
        /// This method processes the number of matches in each line in the input Array. A match occurs when a winning number in the line is equal to a card number in the same line.
        /// For each match in a line, the following line is incremented by 1. If a line includes two matches, the following two lines are incremented by one. This continues on for the number of matches in the line. 
        /// The cards added to a line are also counted and processed. These additional cards also add cards to the following lines.
        /// 
        /// After processing all the cards, this method writes the total number of cards to the console window.
        /// </remarks>
        /// 
        /// <returns>
        /// This method does not return a value.
        /// </returns>
        public static void SolvePuzzle2(string[] input)
        {
            int total = 0;
            var myCards = new List<int> { };
            CardNumberProcessor.FillListWithCards(input, myCards);

            for (int i = 0; i < myCards.Count; i++)
            {
                int numberOfMatches = CardNumberProcessor.GetNumberOfMatches(input[i]);
                for (int j = myCards[i]; j > 0; j--)
                {
                    CardNumberProcessor.AddCards(numberOfMatches, i, myCards);
                    total++;
                }
            }
            Console.WriteLine($"The second puzzle total is: {total}");
        }
    }
}