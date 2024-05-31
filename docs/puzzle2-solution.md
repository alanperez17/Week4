# Puzzle 2 Solution for AoC 2023 Week 4 {#puzzle2-header}

This section describes the C# code solution that solves the second puzzle in week 4 of Advent of Code 2023.
It includes brief descriptions of the functions and their intended purpose.

## Reading the Input File {#puzzle2-input}

Before the solution can start solving the puzzle, it reads the input and writes each line in the file to a String Array. This solution assumes the input file is named `PuzzleInput.txt` and is included in the program folder.
This solution writes the input file contents to the variable `myInput`.

```
var myInput = File.ReadAllLines(@"..\..\..\PuzzleInput.txt");
```
	
## Counting the Initial Cards {#puzzle2-initialCards}

This puzzle requires adding cards to the existing input and then continuously processing both the initial and added cards. As a first step, the function creates a new integer list that accounts for all of the initial cards.
It does this by adding a new element to this list with a value of one for each line in the input file.

The main function includes the following lines of code to do this:

```
var myCards = new List<int> { };
CardNumberProcessor.FillListWithCards(input, myCards);
```

The `FillListWithCards` method adds the elements to the new list. It does this using a `foreach` loop that iterates through each line in the input.

```
public static void FillListWithCards(string[] input, List<int> myCardList)
{
    foreach (var line in input)
    {
		myCardList.Add(1);
    }
}
```

## Processing Cards {#puzzle2-processingCards}

With the initial cards set in the integer list `myCards`, the solution can now:

1. Step through each element in `myCards`.
2. Calculate the number of matches in the current card.
	- This is done using the CardNumberProcessor.GetNumberOfMatches method. This method uses the `CardReader` object and the original input Strings to get the number of matches. For more information, see [Storing the Numbers](./puzzle1-solution.md#puzzle1-storing) in the first puzzle solution.
3. Add cards to the following indices in the list.
4. Add the current card to the variable that tracks the total number of cards.
	- To support this, the `PuzzleSolver2` method declares an integer `total` at the start.
5. Decrement the current list element.
	- This removes the current card so it not counted again.
6. Continue on to the next index when the current one equals zero.
	- When the current index equals zero, all cards of that number have been processed.

To accomplish this, the solution uses nested `for` loops, as shown in the follow codeblock. The outer `for` loop tracks the current index in the list (integer `i`) while the inner loop tracks the number of cards to process in the index (integer `j`).

```
for (int i = 0; i < myCards.Count; i++)
{
    int numberOfMatches = CardNumberProcessor.GetNumberOfMatches(input[i]);
    for (int j = myCards[i]; j > 0; j--)
    {
        CardNumberProcessor.AddCards(numberOfMatches, i, myCards);
        total++;
    }
}
```

### Adding Cards {#puzzle2-addingCards}

The `CardNumberProcessor` object includes the method AddCards, which adds cards of the following types based on the number of matches in the current card.

This method takes the following as parameters:
- The current number of matches as from `.GetNumberOfMatches`. This determines the number of cards to add.
- The current line index in `myCards`. In the solver function, this is `i`.
- The card list `myCards`.

In a while loop, this method performs the following:
1. Ensures that the number of cards to add is greater than 0.
2. In an if loop, checks that the end of the card list index has not been reached.
3. Increments the number of cards in the next index.
4. Increments the current index.
5. Decrements the number of cards to add.

This process adds one card to the following indices for each match in the current line.
For example, if card 1 has four matches, then it increments the number of cards 2, 3, 4, and 5 by one.

The following codeblock shows the `.AddCards` method.

```
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
```

## Calculating the Total Score {#puzzle2-scoring}

As shown above, the function increments the integer `total` each time it processes a card.
Once it finishes both `for` loops and processes every card, the function prints the total to the console window using the code below, solving the puzzle.

```
Console.WriteLine($"The second puzzle total is: {total}");
```