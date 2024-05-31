namespace Week4
{

    /// <summary>
    /// This object retrieves and stores the lottery card numbers and winning numbers.
    /// </summary>
    public class CardReader
    {
        private readonly string _cleanedLine;
        private readonly string _winningNumbersLine;
        private readonly string _cardNumbersLine;
        private List<int> _winningNumbers;
        private List<int> _cardNumbers;

        /// <summary>
        /// Uses the input line to generate a list of winning numbers and a list of card numbers.
        /// </summary>
        ///     
        /// <param name="line">
        /// String. Includes winning numbers and card numbers separated by a '|' character.
        /// </param>
        public CardReader(string line)
        {
            _cleanedLine = line.Remove(0, line.IndexOf(':') + 2);
            _winningNumbersLine = _cleanedLine.Remove(_cleanedLine.IndexOf('|'));
            _cardNumbersLine = _cleanedLine.Remove(0, _cleanedLine.IndexOf('|'));
            _winningNumbers = [];
            _cardNumbers = [];
        }
        /// <summary>
        /// This property gets the winning numbers from the line in an integer list.
        /// </summary>
        ///
        /// <remarks>
        /// The winning numbers correspond to the winning numbers on each card. Per the requirements, a card is counted if one of its numbers matches one of its winning numbers.
        /// </remarks>
        /// 
        /// <returns>
        /// An integer list that includes the winning numbers from the line.
        /// </returns>
        public List<int> WinningNumbers { get => _winningNumbers; }

        /// <summary>
        /// This property gets all the card numbers from the line in an integer list.
        /// </summary>
        /// 
        /// <remarks>
        /// The card numbers correspond to the actual numbers on each card. Per the requirements, a card is counted if one of its numbers matches one of its winning numbers.
        /// </remarks>
        /// 
        /// <returns>
        /// An integer list that includes all the card numbers from the line.
        /// </returns>
        public List<int> CardNumbers { get => _cardNumbers; }

        /// <summary>
        /// This method writes the winning numbers included in the line to the instance of the CardReader object.
        /// </summary>
        ///
        /// <returns>
        /// This method does not return a value.
        /// </returns>
        public void StoreWinningNumbers()
        {
            _winningNumbers = StoreNumbers(_winningNumbersLine);

        }
        ///
        /// <summary>
        /// This method writes all card numbers included in the line to the instance of the CardReader object.
        /// </summary>
        ///     
        /// <returns>
        /// This method does not return a value.
        /// </returns>
        public void StoreCardNumbers()
        {
            _cardNumbers = StoreNumbers(_cardNumbersLine);
        }
        ///
        /// <summary>
        /// This method writes the numbers in the specified string to an integer list.
        /// </summary>
        ///     
        ///<param name="numbersLine">
        /// String. This parameter determines the string to store. Numbers in this string are added to an integer list.
        /// </param>
        ///
        /// <remarks>
        /// This method is not customer-facing. It is used by the store number methods to parse values from a string and pass them to the winning number or card number properties.
        /// </remarks>
        /// 
        /// <returns>
        /// This method returns an integer list that includes all parsed numbers in the specified string.
        /// </returns>
            public static List<int> StoreNumbers(string numbersLine)
            {
                var storedNumbers = new List<int> { };
                for (int i = 0; i < numbersLine.Length; i++)
                {
                    char character = numbersLine[i];
                    string currentNumber = "";
                    while (character >= '0' && character <= '9')
                    {
                        currentNumber += character;
                        i++;
                        if (i >= numbersLine.Length) { break; }
                        character = numbersLine[i];
                    }
                    if (int.TryParse(currentNumber, out int myNumber))
                    {
                        storedNumbers.Add(myNumber);
                    }
                    i++;
                }
                return storedNumbers;
            }
    }
}