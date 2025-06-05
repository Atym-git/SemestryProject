using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorsUnlocker : MonoBehaviour
{
    //private Sprite[] stCUnlockedSprites;
    //[SerializeField] private Image[] stCImages;
    //[SerializeField] private Button[] stCButtons;
    //private List<Image> stCImagesL = new List<Image>();
    //private List<Button> stCButtonsL = new List<Button>();
    //[SerializeField] private Transform imagesParent;
    //private List<int> filledSprites = new List<int>();

    [SerializeField] private Sprite[] level3StCUnlockedSprites; //StC = Store Cards
    [SerializeField] private Image[] level3StCImages;
    [SerializeField] private Button[] level3StCButtons;

    [SerializeField] private Sprite[] level6StCUnlockedSprites;
    [SerializeField] private Image[] level6StCImages;
    [SerializeField] private Button[] level6StCButtons;

    [SerializeField] private int firstUnlockLevel = 3;
    [SerializeField] private int secondUnlockLevel = 6;

    private List<int> filledLevel3Sprites = new List<int>();
    private List<int> filledLevel6Sprites = new List<int>();

    //[SerializeField] private Sprite[] level9StcSprites;
    //[SerializeField] private Image[] level9StCImages;

    //private void Awake()
    //{
    //    LoadResources();
    //    for (int i = 0; i < imagesParent.childCount; i++)
    //    {
    //        var child = imagesParent.GetChild(i);
    //        //stCImages[i] = child.GetComponent<Image>();
    //        //stCButtons[i] = child.GetComponent<Button>();
    //        stCImagesL.Add(child.GetComponent<Image>());
    //        stCButtonsL.Add(child.GetComponent<Button>());
    //    }
    //}

    public void Unlock(int currLevel)
    {
        if (currLevel >= firstUnlockLevel)
        {
            for (int i = 0; i < level3StCUnlockedSprites.Length; i++)
            {
                if (!filledLevel3Sprites.Contains(i))
                {
                    level3StCButtons[i].interactable = true;
                    level3StCImages[i].sprite = level3StCUnlockedSprites[i];
                    filledLevel3Sprites.Add(i);
                }
            }
        }
        if (currLevel >= secondUnlockLevel)
        {
            for (int i = 0; i < level6StCUnlockedSprites.Length; i++)
            {
                if (!filledLevel6Sprites.Contains(i))
                {
                    level6StCButtons[i].interactable = true;
                    level6StCImages[i].sprite = level6StCUnlockedSprites[i];
                    filledLevel6Sprites.Add(i);
                }

            }
        }
        //if (currLevel >= 9)
        //{
        //    for (int i = 0; i < level9StcSprites.Length; i++)
        //    {
        //        level9StCImages[i].sprite = level9StcSprites[i];
        //    }
        //}
    }
    //public void Unlock(int currLevel) // 2nd attempt
    //{
    //    if (currLevel >= firstUnlockLevel)
    //    {
    //        for (int i = 0; i < level3UnlockAmount; i++)
    //        {
    //            if (!filledSprites.Contains(i))
    //            {
    //                stCButtonsL[i].interactable = true;
    //                stCImagesL[i].sprite = stCUnlockedSprites[i];
    //                filledSprites.Add(i);
    //            }
    //        }
    //    }
    //    if (currLevel >= secondUnlockLevel)
    //    {
    //        for (int i = level3UnlockAmount; i < level6UnlockAmount; i++)
    //        {
    //            if (!filledSprites.Contains(i))
    //            {
    //                stCButtonsL[i].interactable = true;
    //                stCImagesL[i].sprite = stCUnlockedSprites[i];
    //                filledSprites.Add(i);
    //            }

    //        }
    //    }
    //}

    private void LoadResources()
    {
        //stCUnlockedSprites = Resources.LoadAll("Sprites/Store cards versions/Generators/AbleToBuy",
        //    typeof(Sprite))
        //    .Cast<Sprite>().ToArray();
        //Assets/Resources/Sprites/Store cards versions/Generators/AbleToBuy
    }
}
