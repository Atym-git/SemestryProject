using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrashSO",
 menuName = "SO/Trash/New Trash")]
public class TrashSO : ScriptableObject
{
    [field: SerializeField]
    public Sprite trashSprite { get; private set; }
}
