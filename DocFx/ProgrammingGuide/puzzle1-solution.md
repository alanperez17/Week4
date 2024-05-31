# Puzzle 1 Solution for AoC 2023 Week 4

This section describes the C# code solution that solves the first puzzle in week 4 of Advent of Code 2023.
It includes brief descriptions of the functions and their intended purpose.

## Reading the Input File

Before the solution can start solving the puzzle, it reads the input and writes each line in the file to a String Array. This solution assumes the input file is named `PuzzleInput.txt` and is included in the program folder.
This solution writes the input file contents to the variable `myInput`.

```
var myInput = File.ReadAllLines(@"..\..\..\PuzzleInput.txt");
```

## Storing the Numbers

The solution now begins to process each line from the input file. By creating a `foreach` loop, it processes each line individually.

    foreach (var line in input)
    {
        int lineMatches = 0;
        var myNumbers = new CardReader(line);
        myNumbers.StoreWinningNumbers();
        myNumbers.StoreCardNumbers();	

In this codeblock, the solution instantiates the `CardReader` object as myNumbers. This instance takes the current line as a parameter.
The `CardReader` object removes unnecessary text from the input String and parses the number values as integers. The store number methods then write the appropriate integers to the winning number or card number properties in the current `CardReader` instance.

The lineMatches variable tracks the number of card and winning number matches in a line. The line scoring mechanism uses this later in the function.

### CardReader Object Fields

The `CardReader` object includes multiple fields that process the string to remove unnecessary components and write the winning and card numbers correctly. Note that object expects a line that follows the format below:

```
Card [Number]: [Winning numbers each separated by a space] | [Card numbers separated by a space]
```
	
As a result, the following fields handle the String:
```
public CardReader(string line)
{
	_cleanedLine = line.Remove(0, line.IndexOf(':') + 2);
	_winningNumbersLine = _cleanedLine.Remove(_cleanedLine.IndexOf('|'));
	_cardNumbersLine = _cleanedLine.Remove(0, _cleanedLine.IndexOf('|'));
	_winningNumbers = [];
	_cardNumbers = [];
}
```

They perform the following:
- `_cleanedLine`: String. Removes the card number and colon from the beginning of the line.
- `_winningNumbersLine`: String. Includes the numbers before the vertical bar. This does not include the card number before the colon.
- `_cardNumbersLine`:  String. Includes the numbers after the vertical bar.
- `_winningNumbers` and `_cardNumbers`: Integers. The store number methods write the parsed integers to these fields. The main function then accesses the values through properties.

### CardReader Object Methods {#puzzle1-cardReader-methods}

The `CardReader` object includes a few methods that store the winning and card numbers as integers in the object instance.
The StoreNumbers method parses any numbers in the String input to it. It reads numbers from the line in a `foreach` loop that iterates through each character in the line.
It uses the `int.TryParse` command to check if the current character is a digit. If it is, the function continues to add digits to the number until it reaches a space or a character that fails the `TryParse` check.
```
private static List<int> StoreNumbers(string numbersLine)
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
```

To store the winning numbers and card numbers, the `CardReader` object includes methods that write these values to integer list fields.
Both of these methods use the above function, but write the values to the winning numbers or card numbers fields, respectively.

```
public void StoreWinningNumbers()
{
    _winningNumbers = StoreNumbers(_winningNumbersLine);

public void StoreCardNumbers()
{
    _cardNumbers = StoreNumbers(_cardNumbersLine);
}
```	

### CardReader Object Properties {#puzzle1-cardReader-properties}

The `CardReader`object includes properties that allow other functions to get the card and winning numbers. The solver function uses these to compare the numbers for the number of matches.
The properties are defined as follows:

```
public List<int> WinningNumbers { get => _winningNumbers; }

public List<int> CardNumbers { get => _cardNumbers; }
```

## Calculating the Number of Matches {#puzzle1-matches}

With the contents of a line converted to integer values, the solution can compare the winning numbers to the numbers on the card. It then determines the number of matches in a line.
To do so, the program uses a `foreach` loop that runs through each winning number in the current line. If the `.CardNumber` property includes the same value, the function increments a match number variable and continues to the next winning number.

The following code is nested within the `foreach` loop that iterates through each line.

```
foreach (var number in myNumbers.WinningNumbers)
{
    if (myNumbers.CardNumbers.Contains(number))
    {
        lineMatches++;
    }
}
```

## Calculating the Total Score {#puzzle1-scoring}

Finally, the function now calculates the number of matches in the line and adds the appropriate value to an integer that tracks the total score.
This integer is declared at the start of the function, before the first `foreach` loop.
The `foreach` loop then continues on to the next line.

```
if (lineMatches == 0) { continue; }
else if (lineMatches == 1) { total += 1; }
else { total += (int)Math.Pow(2, lineMatches - 1); }
```

After processing all the lines, the function then writes the total to the console window, solving the puzzle:

```
Console.WriteLine($"The first puzzle total is: {total}");
```