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
    public float XPMultiplayer { get; private set; }

    [field: SerializeField]
    public float coinsMultiplayer { get; private set; }

    [field: SerializeField]
    public string workerName { get; private set; }
}
