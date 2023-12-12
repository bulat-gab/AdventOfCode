using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day7;
internal record CardHand
{
    public string Cards { get; init; }
    public int BidAmount { get; init; }
    public HandType HandType { get; set; }
    public int Rank { get; set; }

    public CardHand(string cards, int bidAmount)
    {
        Cards = cards;
        BidAmount = bidAmount;

        HandType = GetHandType(cards);
        Rank = -1;
    }

    protected virtual HandType GetHandType(string cards)
    {
        if (string.IsNullOrEmpty(cards))
        {
            return HandType.None;
        }

        List<(int Count, char Card)> cardOccurences = cards
            .GroupBy(c => c)
            .OrderByDescending(x => x.Count())
            .Select(x => (x.Count(), x.Key))
            .ToList();

        if (cardOccurences[0].Count == 5)
        {
            return HandType.FiveOfKind;
        }
        if (cardOccurences[0].Count == 4)
        {
            return HandType.FourOfKind;
        }
        if (cardOccurences[0].Count == 3 
            && cardOccurences.Count > 1 
            && cardOccurences[1].Count == 2)
        {
            return HandType.FullHouse;
        }
        if (cardOccurences[0].Count == 3)
        {
            return HandType.ThreeOfKind;
        }
        if (cardOccurences[0].Count == 2 
            && cardOccurences.Count > 1 
            && cardOccurences[1].Count == 2)
        {
            return HandType.TwoPair;
        }
        if (cardOccurences[0].Count == 2)
        {
            return HandType.OnePair;
        }
        if (cardOccurences[0].Count == 1)
        {
            return HandType.HighCard;
        }

        return HandType.None;
    }
}
