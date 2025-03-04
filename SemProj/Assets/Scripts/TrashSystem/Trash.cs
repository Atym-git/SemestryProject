using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public void SetupTrash(Sprite trashSprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = trashSprite;
    }
}
