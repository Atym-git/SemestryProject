using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class GeneratorsUnlocker : MonoBehaviour
{
    [SerializeField] private Sprite[] level3StCUnlockedSprites; //StC = Store Cards
    [SerializeField] private Image[] level3StCImages;
    [SerializeField] private Button[] level3StCButtons;

    [SerializeField] private Sprite[] level6StCUnlockedSprites;
    [SerializeField] private Image[] level6StCImages;
    [SerializeField] private Button[] level6StCButtons;

    //[SerializeField] private Sprite[] level9StcSprites;
    //[SerializeField] private Image[] level9StCImages;

    public void Unlock(int currLevel)
    {
        if (currLevel >= 3)
        {
            for (int i = 0; i < level3StCUnlockedSprites.Length; i++)
            {
                level3StCButtons[i].interactable = true;
                level3StCImages[i].sprite = level3StCUnlockedSprites[i];
            }
        }
        if (currLevel >= 6)
        {
            for (int i = 0; i < level6StCUnlockedSprites.Length; i++)
            {
                level6StCButtons[i].interactable = true;
                level6StCImages[i].sprite = level6StCUnlockedSprites[i];
            }
        }
        //if (currLevel == 9)
        //{
        //    for (int i = 0; i < level9StcSprites.Length; i++)
        //    {
        //        level9StCImages[i].sprite = level9StcSprites[i];
        //    }
        //}
    }
}
