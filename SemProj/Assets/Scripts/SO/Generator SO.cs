using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GeneratorSO",
 menuName = "SO/Generator/Generator")]
public class GeneratorSO : ScriptableObject
{
    [field: SerializeField]
    public Sprite generatorSprite { get; private set; }

    [field: SerializeField]
    public string generatorName { get; private set; }

    [field: SerializeField]
    public float coinsProducement { get; private set; }

    [field: SerializeField]
    public float expProducement { get; private set; }

    [field: SerializeField]
    public float timeConsume { get; private set; }

    [field: SerializeField]
    public float generatorCost { get; private set; }

    [field: SerializeField]
    public float ScaleFactor { get; private set; }

    [field: SerializeField]
    public int generatorAmount { get; private set; }
}
