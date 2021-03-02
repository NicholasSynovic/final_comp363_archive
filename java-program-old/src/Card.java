public class Card
{

    private int rank;  // the "number" of the suit from Ace to King
    private int suit;

    public final int ACE = 1;
    public final int JACK = 11;
    public final int QUEEN = 12;
    public final int KING = 13;

    public final int SPADES = 1;
    public final int HEARTS = 2;
    public final int DIAMONDS = 3;
    public final int CLUBS = 4;

    /**
     * Constructer for objects of class Card
     */
    public Card(int suit, int rank)
    {
        this.suit = suit;
        this.rank = rank;
    }

    /**
     * sets the rank of the card (see constants above)
     */
    public void setRank(int theRank)
    {
        rank = theRank;
    }

    /**
     * returns the rank of the card
     */
    public int getRank()
    {
        return rank;
    }

    /**
     * sets the suit of the card (see constants above)
     */
    public void setSuit(int theSuit)
    {
        suit = theSuit;
    }

    /**
     * returns the suit of the card as a number
     */
    public int getSuit()
    {
        return suit;
    }

    /**
     * turns card into "rank" of "suit"
     */
    public String toString()
    {
        return getRankString() + " of " + getSuitString();
    }

    /**
     * returns the rank of the card as a String including words like jack, queen, king and ace
     */
    public String getRankString()
    {
        if (rank == 1)
            return "Ace";
        else if (rank == JACK)
            return "Jack";
        else if (rank == QUEEN)
            return "Queen";
        else if (rank == KING)
            return "King";
        else
            return "" + rank;
    }

    /**
     * turns the suit of the card into a string
     */
    public String getSuitString()
    {
        if (suit == SPADES)
            return "Spades";
        else if (suit == HEARTS)
            return "Hearts";
        else if (suit == DIAMONDS)
            return "Diamonds";
        else if (suit == CLUBS)
            return "Clubs";
        else
            return "unknown suit";
    }


    public boolean equals(Object o)
    {
        Card other = (Card)o;
        return this.suit==other.suit && this.rank == other.rank;
    }

}
