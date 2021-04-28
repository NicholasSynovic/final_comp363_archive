using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private Emperor emperor;
    private UserInput userInput;
    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = Emperor.GenerateStdDeck();
        emperor = FindObjectOfType<Emperor>();
        userInput = FindObjectOfType<UserInput>();

        int i = 0;
        foreach(string card in deck)
        {
            if (this.name == card)
            {
                cardFace = emperor.cardFaces[i];
                break;
            }
            i++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectable.faceUp == true)
        {
            spriteRenderer.sprite = cardFace;
        }
        else
        {
            spriteRenderer.sprite = cardBack;
        }

        if(userInput.selectedCard)
        {
            //TODO Remove from update and make this change happen only when card is clicked 
            if(name == userInput.selectedCard.name){
                spriteRenderer.color = Color.cyan;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
        }
    }
}
