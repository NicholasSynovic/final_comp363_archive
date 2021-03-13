using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Emperor : MonoBehaviour
{
    public Sprite[] cardFaces;
    public GameObject cardPrefab;

    public GameObject wastePos;
    public GameObject[] bottomPos;
    public GameObject[] topPos;

    public static string[] deckN = new string[] {"1", "2"};
    public static string[] suits = new string[] {"C","D","H","S"};
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
    
    public List<string>[] tableaus;
    public List<string>[] foundations;
    public List<string> waste;


    private List<string> tableau0 = new List<string>();
    private List<string> tableau1 = new List<string>();
    private List<string> tableau2 = new List<string>();
    private List<string> tableau3 = new List<string>();
    private List<string> tableau4 = new List<string>();
    private List<string> tableau5 = new List<string>();
    private List<string> tableau6 = new List<string>();
    private List<string> tableau7 = new List<string>();
    private List<string> tableau8 = new List<string>();
    private List<string> tableau9 = new List<string>();

    public List<string> deck;

    // Start is called before the first frame update
    void Start()
    {
        tableaus = new List<string>[] {tableau0,tableau1,tableau2,tableau3,tableau4,tableau5,tableau6,tableau7,tableau8,tableau9};
        Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Methods

    //Populates the deck with 104 cards (x2 of each card of each suit and value) and shuffles deck
    public void Play()
    {
        //104 cards are generated
        deck = GenerateStdDeck();

        //cards are shuffled randomly
        Shuffle(deck);
        
        //test functionality: prints all cards generated to unity activity console
        foreach(string card in deck){
            print(card);
        }

        //4 cards are put into each tableau list
        EmperorSort();

        //cards are instantiated and the tableau cards are properly flipped up at the top
        StartCoroutine(EmperorDeal());
        print(deck.Count);
    }

    //Generates a deck consistent of two standard 52 card decks
    public static List<string> GenerateStdDeck()
    {
        List<string> newDeck = new List<string>();
        foreach(string s in suits)
        {
            foreach(string v in values)
            {
                foreach(string dn in deckN)
                {
                    newDeck.Add(dn + s + v);
                }
            }
        }
        return newDeck;
    }

    //Shuffles card using the Fisher-Yates shuffle method found here (https://stackoverflow.com/questions/1150646/card-shuffling-in-c-sharp)
    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while(n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    //Instantiates and creates the 

    IEnumerator EmperorDeal()
    {
        for (int i = 0; i < 10; i++ )
        {
            float yOffset = 0;
            float zOffset = 0.3f;
            foreach(string card in tableaus[i])
            {
                yield return new WaitForSeconds(0.01f);
                GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[i].transform.position.x, bottomPos[i].transform.position.y - yOffset, bottomPos[i].transform.position.z - zOffset), Quaternion.identity, bottomPos[i].transform);
                newCard.name = card;
                newCard.GetComponent<Selectable>().posRow = i;
                if(card == tableaus[i][tableaus[i].Count - 1])
                {
                    newCard.GetComponent<Selectable>().faceUp = true;
                }
                yOffset = yOffset + 0.3f;
                zOffset = zOffset + 0.03f;
            }
        }
    }

    //Sort method that sends 4 cards to each of the ten bottom slots
    void EmperorSort()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                tableaus[i].Add(deck.Last<string>());
                deck.RemoveAt(deck.Count - 1);
            }
        }
    }


    //draws one card from the deck and places it faceup at the top of waste pile
    public void DrawDeck()
    {
        float zOffset = .01f + (0.01f * waste.Count);
        if(deck.Count > 0 ){
            waste.Add(deck.Last<string>());
            deck.RemoveAt(deck.Count - 1);
            GameObject newWasteCard = Instantiate(cardPrefab, new Vector3(wastePos.transform.position.x, wastePos.transform.position.y, wastePos.transform.position.z - zOffset), Quaternion.identity, wastePos.transform);
            newWasteCard.name = waste[waste.Count - 1];
            newWasteCard.GetComponent<Selectable>().faceUp = true;
            newWasteCard.GetComponent<Selectable>().inWaste = true;
        }

    }
}
