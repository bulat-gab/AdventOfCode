using AdventOfCode2023.Day7;

namespace AdventOfCode.Day7;
public class Part1
{
    /*
     * Find type of hand for each line, i.e. 
     * one pair, 2 pairs, 3 of a kind, full house, 4 of a kind, 5 of a kind
     * Order by strength
     * Deal with the hands with the same strength, by comparing characters from the start
     * 
     */

    public int PartOne()
    {
        var lines = File.ReadAllLines("./Day7/input.txt");
        IEnumerable<CardHand> hands = ParseInput(lines);

        var seed = (Score: 0, Rank: 1);
        var (Score, Rank) = hands
            .OrderBy(hand => hand.HandType)
            .ThenBy(keySelector => keySelector.Cards, new HandsComparer())
            .Aggregate(seed, (acc, nextHand) => (acc.Score + nextHand.BidAmount * acc.Rank, acc.Rank + 1));

        Console.WriteLine(Score);
        return Score;
    }

    private static IEnumerable<CardHand> ParseInput(string[] lines)
    {
        foreach (var line in lines)
        {
            var split = line.Split(' ');
            var cards = split[0];
            var bidAmount = int.Parse(split[1]);
            yield return new CardHand(cards, bidAmount);
        }
    }
}
