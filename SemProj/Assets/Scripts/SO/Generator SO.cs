using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GeneratorSO",
 menuName = "SO/Generator/New Generator")]
public class GeneratorSO : ScriptableObject
{
    public Sprite generatorSprite { get; private set; }

    public int generatorId { get; private set; }

    public float multiplayer { get; set; }
}
