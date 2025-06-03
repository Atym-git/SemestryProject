using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomerSO",
 menuName = "SO/Customer/New Customer")]
public class CustomersSO : ScriptableObject
{
    [field: SerializeField]
    public Sprite customerSprite { get; private set; }

    [field: SerializeField]
    public AnimationClip customerAnimation { get; private set; }
}