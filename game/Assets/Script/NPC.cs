using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }
    public GameObject tutorialPanel;   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            tutorialPanel.SetActive(true);
            Input.GetKeyDown(KeyCode.N);
        }
         
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            tutorialPanel.SetActive(false);
        }    
    }
}
