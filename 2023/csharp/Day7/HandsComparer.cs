namespace AdventOfCode2023.Day7;
internal class HandsComparer(bool treatJAsWeakestCard = false) : IComparer<string>
{
    private const string NormalOrder = "AKQJT98765432";
    private const string JIsWeakestCard = "AKQT98765432J";

    private readonly string CardLabelsStrength = treatJAsWeakestCard ? JIsWeakestCard : NormalOrder;

    public int Compare(string? hand1, string? hand2)
    {
        if (hand1 == null || hand2 == null)
        {
            throw new ArgumentNullException();
        }

        for (int cardIndex = 0; cardIndex < hand1.Length; cardIndex++)
        {
            var card1Index = CardLabelsStrength.IndexOf(hand1[cardIndex]);
            var card2Index = CardLabelsStrength.IndexOf(hand2[cardIndex]);

            if (card1Index == card2Index)
            {
                continue;
            }

            if (card1Index < card2Index)
            {
                return 1;
            }

            if (card1Index > card2Index)
            {
                return -1;
            }
        }

        throw new NotImplementedException("Cards are identical.");
    }
}
