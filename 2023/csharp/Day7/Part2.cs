using AdventOfCode2023.Day7;
using System.Collections.Immutable;

namespace AdventOfCode2023.Day7;
public class Part2
{
    public int PartTwo()
    {
        var lines = File.ReadAllLines("./Day7/input.txt");
        IEnumerable<CardHand> hands = ParseInput(lines);

        var seed = (Score: 0, Rank: 1);
        var (Score, Rank) = hands
            .OrderBy(hand => hand.HandType)
            .ThenBy(keySelector => keySelector.Cards, new HandsComparer(treatJAsWeakestCard: true))
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
            yield return new CardHandPartTwo(cards, bidAmount);
        }
    }
}
