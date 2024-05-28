namespace Week4
{
    /// <summary>
    /// This object includes methods that handle requirements for puzzle 2, which requires adding cards to the following indices in the card list based on the number of matches in a line.
    /// </summary>
    public class CardNumberProcessor
    {
        /// <summary>
        /// This method builds an integer list that accounts for all of the initial cards.
        /// It uses the input String Array to write a value of one to each line in the myCardList parameter.
        /// </summary>
        /// 
        /// <param name="input">
        /// String Array. Includes a number of winning numbers and card numbers separated by a '|' character in each element.
        /// </param>
        /// 
        /// <param name="myCardList">
        /// Integer List. This method adds an element with a value of one for each card in the input Array to this list.
        /// </param>
        /// 
        /// <remarks>
        /// This method accounts for the cards in the initial list. Because this puzzle requires adding additional cards, the following methods will increment values in myCardList and process them respectively.
        /// While this method does not return a value, it does write values to the myCardList parameter. When you call this method, myCardList should be an empty list.
        /// </remarks>
        /// 
        /// <returns>
        /// This method does not return a value.
        /// </returns>
        public static void FillListWithCards(string[] input, List<int> myCardList)
        {
            foreach (var line in input)
            {
                myCardList.Add(1);
            }
        }

        /// <summary>
        /// This method gets the amount of card numbers that match a winning number in a line.
        /// </summary>
        /// 
        /// <param name="line">
        /// String. Includes the winning numbers and card numbers separated by a '|' character.
        /// </param>
        /// 
        /// <remarks>
        /// This method determines if a card number is a winning number by seeing if the winning number list includes an element with the same value.
        /// If a number matches, it increments the return value by one and proceeds to the next card number.
        /// </remarks>
        /// 
        /// <returns>
        /// This method returns the number of matches in a line.
        /// </returns>

        public static int GetNumberOfMatches(string line)
        {
            int lineMatches = 0;
            var myNumbers = new CardReader(line);
            foreach (var number in myNumbers.WinningNumbers)
            {
                if (myNumbers.CardNumbers.Contains(number))
                {
                    lineMatches++;
                }
            }
            return lineMatches;
        }

        /// <summary>
        /// This method adds cards to the following indices in the card list based on the number of matches in a line.
        /// </summary>
        /// <param name="cardsToAdd">
        /// Integer. Determines the number of cards to add to the following lines. Set this to the number of matches in a line returned by .GetNumberOfMatches.
        /// </param>
        /// 
        /// <param name="lineIndex">
        /// Integer. Sets the current line index. This is used to ensure that no cards are added beyond the end of the List.
        /// </param>
        /// <param name="cardList">
        /// Integer List. Sets the card list that this method adds cards to.
        /// </param>
        /// 
        /// <remarks>
        /// Use this method to add cards to the following lines in the cardList based on the number of matches in the line. This method does not track the number of cards processed. That is handled by puzzle 2 solver method in the PuzzlerSolver class.
        /// While this method does not return a value, it increments the values of the following lines in the card list.
        /// </remarks>
        /// 
        /// <returns>
        /// This method does not return a value.
        /// </returns>
        public static void AddCards(int cardsToAdd, int lineIndex, List<int> cardList)
        {
            while (cardsToAdd > 0)
            {
                if (lineIndex + 1 < cardList.Count)
                {
                    cardList[lineIndex + 1]++;
                    lineIndex++;
                    cardsToAdd--;
                }
            }
        }
    }
}