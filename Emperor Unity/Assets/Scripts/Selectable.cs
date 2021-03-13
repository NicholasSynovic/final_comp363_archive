using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public bool faceUp = false;
    public bool onFoundation = false;
    public bool inWaste = false;
    public string suit;
    public int rank;
    public string color;
    public int posRow;
    private string rankStr;

    
    // Start is called before the first frame update
    void Start()
    {
        if (CompareTag("Card")){
            suit = transform.name[1].ToString();

            for(int i = 2; i < transform.name.Length; i++)
            {
                char c = transform.name[i];
                rankStr = rankStr + c.ToString();
            }
            rank = assignRank(rankStr);

            if(suit == "C" || suit == "S")
            {
                color = "B";
            }
            else
            {
                color = "R";
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void faceState(bool state)
    {
        this.faceUp = state;
    }

    public bool getfaceState(){
        return this.faceUp;
    }

    public int assignRank(string obj)
    {
        //TODO find a better "null" system that can troubleshoot if the switch cases don't function properly
        int newRank = 0;
        switch(obj)
        {
            case "A":
                newRank = 1;
                break;
            case "2":
                newRank = 2;
                break;
            case "3":
                newRank = 3;
                break;
            case "4":
                newRank = 4;
                break;
            case "5":
                newRank = 5;
                break;
            case "6":
                newRank = 6;
                break;
            case "7":
                newRank = 7;
                break;
            case "8":
                newRank = 8;
                break;
            case "9":
                newRank = 9;
                break;
            case "10":
                newRank = 10;
                break;
            case "J":
                newRank = 11;
                break;
            case "Q":
                newRank = 12;
                break;
            case "K":
                newRank = 13;
                break;
        }
        return newRank;
    }
}
