namespace AdventOfCode2023.Day7;
internal record CardHandPartTwo : CardHand
{
    public CardHandPartTwo(string cards, int bidAmount) : base(cards, bidAmount)
    {
    }

    protected override HandType GetHandType(string cards)
    {
        if (!cards.Contains('J'))
        {
            return base.GetHandType(cards);
        }

        var cardsWithoutJ = cards.Replace("J", "");
        int handTypeWithoutJ = (int) base.GetHandType(cardsWithoutJ);

        var numberOfJ = cards.Count(x => x == 'J');

        if (numberOfJ == 1)
        {
            switch (handTypeWithoutJ)
            {
                case 1:
                    return (HandType) 2;
                case 2:
                    return (HandType) 4;
                case 3:
                    return (HandType) 5;
                case 4:
                    return (HandType) 6;
                case 6:
                case 7:
                    return (HandType) 7;

                default:
                    throw new NotImplementedException();
            }
        }
        else if (numberOfJ == 2)
        {
            switch (handTypeWithoutJ)
            {
                case 1:
                    return (HandType) 4;
                case 2:
                    return (HandType) 6;
                case 4:
                    return (HandType) 7;
            }
        }
        else if (numberOfJ == 3)
        {
            switch (handTypeWithoutJ)
            {
                case 1:
                    return (HandType) 6;
                case 2:
                    return (HandType) 7;
            }
        }
        else if (numberOfJ == 4 || numberOfJ == 5)
        {
            return (HandType) 7;
        }

        throw new NotImplementedException($"Invalid cards: {cards}");
    }
}
