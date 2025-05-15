using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    [SerializeField] private bool canBePressed = false;

    [SerializeField] private KeyCode keyToPress;

    [SerializeField] private float startingClickYArea = 0.4f;

    [SerializeField] private float normalHit = 0.22f;
    [SerializeField] private float goodHit = 0.05f;
    [SerializeField] private float perfectHit = 0.22f;

    private void Update()
    {
        OnArrowPress();
    }

    private void OnArrowPress()
    {
        if (GameManager.instance.hasStarted && Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
                if (Mathf.Abs(transform.position.y) > normalHit)
                {
                    GameManager.instance.NormalHit();
                }
                else if (Mathf.Abs(transform.position.y) > goodHit)
                {
                    GameManager.instance.GoodHit();
                }
                else
                {
                    GameManager.instance.PerfectHit();
                }
            }
            //else if (!canBePressed)
            //{
            //    GameManager.instance.Miss();
            //}

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
