import java.util.ArrayList;

public class Deck
{
    //private Card[] cards = new Card[52];
    ArrayList<Card> c;
    public final int MAX_SHUFFLE = 100;
    public Deck()
    {
        c = new ArrayList <Card>();
        Card x = new Card(0, 0);
        for (int suit = x.SPADES; suit <= x.CLUBS; suit++)
            for (int rank = x.ACE; rank <= x.KING; rank++)
            {
                Card card= new Card(suit, rank);
                c.add(card);
            }
    }

    /**
     * returns true if there are no cards left to deal, otherwise false
     */
    public boolean empty()
    {
        if(c.size()==0){
            return true;
        }
        return false;
    }

    /**
     * returns the number of cards still left int the deck
     */
    public int numCards()
    {
        return c.size();
    }

    /**
     * dealCard returns a card from of the deck as long as one is available.
     * Otherwise, returns null.
     */
    public Card dealCard()
    {
        Card card= c.get(0);
        c.remove(0);
        return card;
    }

    /**
     * shuffles the deck by swapping cards MAX_SHUFFLE number of times
     */
    public void shuffle()
    {
        int num = c.size();
        for (int j = 0; j < MAX_SHUFFLE; j++)
        {
            int rand1 = (int)(Math.random() * num);
            int rand2 = (int)(Math.random() * num);
            Card card1 = c.get(rand1);
            Card card2 = c.get(rand2);
            c.set(rand1, card2);
            c.set(rand2,card1);
        }
    }



    public boolean equals(Object o)
    {
        Deck other = (Deck)o;
        int num = this.numCards();
        if (num != other.numCards())
            return false;
        else {
            for (int i = 0; i < num; i++)
                if (!this.c.get(i).equals(other.c.get(i)))
                    return false;
            return true;
        }
    }

    /**
     * addCard puts a card back into the deck
     *
     */
    public void add(Card card)
    {
        c.add(card);
    }

    /**
     * Sorts cards using insertion method.
     */
    public void insertionSort()
    {
        for(int i=0;i<c.size();i++){
            int spot = findSpot(i);
            c.add(spot,c.remove(i));
        }
    }

    /**
     * Finds spot where the unveiled cards should be placed in deck
     */
    public int findSpot(int i)
    {
        int index=i;
        for(int j=i;j>=0;j--){
            if(c.get(j).getRank()>c.get(i).getRank()){
                index=j;
            }
        }
        return index;
    }



    /**
     * Sorts deck with selection sort.
     */
    public void selectionSort()
    {
        for(int i=0;i<c.size(); i++){
            int j=findSmallest(i);
            swap(i,j);
        }
    }


    /**
     * finds the index of the smallest card in deck
     */
    public int findSmallest(int i){
        int indexOfSmallest=i;
        for(int x=i;x<c.size();x++)
        {
            if(c.get(x).getRank()<c.get(indexOfSmallest).getRank()){
                indexOfSmallest=x;
            }
        }
        return indexOfSmallest;
    }

    /**
     * Swaps cards when necessary
     */
    public void swap(int i, int j)
    {
        Card temp=c.get(i);
        c.set(i,c.get(j));
        c.set(j,temp);
    }

    /**
     * Finds a card of a particular rank in deckk
     */
    public Card findCardBinary(int rank)
    {
        int low=0;
        int high=c.size()-1;//off by 1 if no -1
        int middle=0;
        while(low<=high)
        {
            middle=(high+low)/2;//average
            if(rank<c.get(middle).getRank()){
                high=middle-1;//disregards former middle value
            }
            else if(rank>c.get(middle).getRank()){
                low=middle+1;
            }
            else return c.get(middle);
        }
        return null;  //not there
    }
    /**
     * Finds card of a given rank with a sequential search
     */
    public Card findCardSequential(int rank)
    {
        Card theCard=null;
        for(int i=0;i<c.size();i++)
        {
            if(c.get(i).getRank()==rank)
            {
                theCard=c.get(i);
                break;
            }
        }
        return theCard;
    }



    /**
     * returns all the cards left in the deck as a string put together
     */
    public String toString() {
        String str = "";
        for (Card card : c) {
            str += card.toString();
        }
        return str;
    }


    }

