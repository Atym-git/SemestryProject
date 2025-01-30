using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorkerSO",
 menuName = "SO/Worker/New Worker")]
public class WorkersSO : ScriptableObject
{
    public Sprite workerSprite { get; private set; }

    public float generatorXPMultiplayer { get; private set; }

    public float generatorCoinsMultiplayer { get; private set; }
}
