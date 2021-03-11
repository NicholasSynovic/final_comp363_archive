using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{

    private Emperor emperor;
    public GameObject selectedCard;

    // Start is called before the first frame update
    void Start()
    {
        emperor = FindObjectOfType<Emperor>();
        selectedCard = this.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseClick();
    }

    void GetMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //TODO Utilize switch to remove if statement redundancy
            if(hit)
            {
                if(hit.collider.CompareTag("Deck"))
                {
                    Deck();
                }
                else if(hit.collider.CompareTag("Card"))
                {
                    Card(hit.collider.gameObject);
                }
                else if(hit.collider.CompareTag("Foundation"))
                {
                    Foundation();
                }
                else if(hit.collider.CompareTag("Tableau"))
                {
                    Tableau();
                }
                else if(hit.collider.CompareTag("Waste"))
                {
                    Waste();
                }
            }
        }
    }

    void Deck()
    {
        print("Hit Deck");
        emperor.DrawDeck();
    }

    void Tableau()
    {
        print("Hit Tableau");
    }

    void Foundation()
    {
        print("Hit Foundation");
    }

    //TODO Find a better solution for selecting
    void Card(GameObject selected)
    {
        print("Hit Card");
        if (selectedCard == this.gameObject)
        {
            selectedCard = selected;
        }
        else if (selectedCard != selected)
        {
            if (isValidMove(selected))
            {

            }
            else
            {
                selectedCard = selected;
            }
        }
    }

    void Waste()
    {
        print("Hit Waste");
    }

    bool isValidMove(GameObject selected)
    {
        Selectable origin = selectedCard.GetComponent<Selectable>();
        Selectable destination = selected.GetComponent<Selectable>();

        //TODO add switch statements here in place of if statements
        if(destination.onFoundation)
        {
            if(origin.suit == destination.suit || (origin.rank == 1 && destination.rank == null))
            {
                if(origin.rank == destination.rank + 1)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            if(origin.rank == destination.rank - 1 && origin.color != destination.color)
            {
                    print("Can Stack");
                    return true;
            }
            else{
                print("Not stackable");
                return false;
            }
        }
        return false;
    }
    //WIP: This moves cards but it needs a sufficient check 
    // void StackCards(GameObject newSelected)
    // {
    //     Selectable origin = selectedCard.GetComponent<Selectable>();
    //     Selectable destination = newSelected.GetComponent<Selectable>();

    //     float yOffset = 0.3f;

    //     if(destination.onFoundation || (!destination.onFoundation && origin.rank == 13))
    //     {
    //         yOffset = 0;
    //     }

    //     selectedCard.transform.position = new Vector3(newSelected.transform.position.x, newSelected.transform.position.y - yOffset, newSelected.transform.position.z - 0.02f);

    //     if(origin.inWaste)
    //     {
    //         emperor.waste.Remove(selectedCard.name);

    //     }
    // }
}
