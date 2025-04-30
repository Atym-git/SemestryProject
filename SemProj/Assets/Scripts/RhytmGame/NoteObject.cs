using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    [SerializeField] private bool canBePressed;

    [SerializeField] private KeyCode keyToPress;

    private void Update()
    {
        if (Input.GetKeyDown(keyToPress) && canBePressed)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.GetComponent<ButtonController>())
        //{
            canBePressed = true;
        //}
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.GetComponent<ButtonController>())
        //{
           canBePressed = false;
        //}
    }
}
