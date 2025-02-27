using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorkerSO",
 menuName = "SO/Worker/New Worker")]
public class WorkersSO : ScriptableObject
{
    [field: SerializeField]
    public Sprite workerSprite { get; private set; }

    [field: SerializeField]
    public float workerCost { get; private set; }

    [field: SerializeField]
    public float workerXPMultiplayer { get; private set; }

    [field: SerializeField]
    public float workerCoinsMultiplayer { get; private set; }
}
