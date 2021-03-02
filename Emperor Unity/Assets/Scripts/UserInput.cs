using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit)
            {
                if(hit.collider.CompareTag("Deck"))
                {

                }
                else if(hit.collider.CompareTag("Card"))
                {

                }
                else if(hit.collider.CompareTag("Top"))
                {

                }
                else if(hit.collider.CompareTag("Bottom"))
                {

                }
            }
        }
    }
}
