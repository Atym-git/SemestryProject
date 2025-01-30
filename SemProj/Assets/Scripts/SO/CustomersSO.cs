using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomerSO",
 menuName = "SO/Customer/New Customer")]
public class CustomersSO : ScriptableObject
{
    public Sprite customerSprite { get; private set; }
}