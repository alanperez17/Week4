# Advent of Code 2023: Week 4 Documentation

This user guide describes my solution to the Week 4 puzzles of Advent of Code 2023. I programmed this solution in C# and used a Console App project template.
To read the original puzzle description, click [here](https://adventofcode.com/2023/day/4).

This challenge involves deciphering a scratch card that includes winning numbers and the actual numbers on the card. If a number on the card matches a winning number, the card earns points.
The number of points a card earns depends on the number of matching numbers.

The input to this challenge is formatted as shown below:

	Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
	Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
	Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
	Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
	Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
	Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11

Each card is numbered and includes its winning numbers after a colon and before a vertical bar. The card numbers are shown after the vertical bar.

Like all advent of code puzzles, this challenge includes two distinct puzzles. Both puzzles are described below.

## First Puzzle

This puzzle requires you to get the total number of points earned by the lines in the input, where the number of matches determines the amount of points earned by a line.
A line one point for the first match and is then multiplied by two for each subsequent match. For example, a line with 3 matches is scored as 1 * 2 * 2, which amounts to 4.

The list below shows the score for each number of matches in a line:
- 0 matches: 0 points
- 1 match: 1 point (1 * 1)
- 2 matches: 2 points (1 * 2)
- 3 matches: 4 points (1 * 2 * 2)
- 4 matches: 8 points (1 * 2 * 2 * 2)
- And so on.

After processing each line, the program should return the total number of points scored.

## Second Puzzle

This puzzle requires you to get the total number of cards. The file input includes about 160 cards, but, in this puzzle, a match in a line adds a card of the following line to the number of cards.
For example, if Card 1 has one match, then you would get another copy of card 2. Then when processing card 2, you need to process both copies and add them.
This continues on until all cards are processed and counted.

The number of matches determines how many of the following lines get copies. With one match, the next line gets a copy. With two matches, the next two lines get one copy. With three matches, the next three lines get a copy, and so on.
For example, if card 1 has four matches, you would receive copies of the following cards:
- Card 2
- Card 3
- Card 4
- Card 5

Ultimately, this amounts to a large number as the amount of cards increases exponentially. After processing each card and all copies, the program should return the total number of cards.