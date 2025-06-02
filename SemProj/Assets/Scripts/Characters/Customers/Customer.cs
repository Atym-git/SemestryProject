using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetupCustomer(Sprite CustomerSprite, AnimationClip CustomerAnimation)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = CustomerSprite;

        Debug.Log(CustomerAnimation);
        Debug.Log(CustomerAnimation.name);
        animator.SetTrigger(CustomerAnimation.name);
        sr.color = Color.white;
    }
}
