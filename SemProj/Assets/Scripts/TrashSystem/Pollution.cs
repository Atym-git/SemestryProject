using UnityEngine;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

public class Pollution : MonoBehaviour
{
    [SerializeField] private Transform[] _trashRoots;

    private TrashSO[] trashSOs;

    [SerializeField] private GameObject _trashPrefab;

    [SerializeField] private int _secsBetweenPollution = 120;

    [SerializeField] private int _minTrashAmount = 3;

    [SerializeField] private int _cleanCost = 100;

    List<int> trashPlacements = new List<int>();

    private bool isPolluted;

    private CountNShowCoins coinsScript;
    private ExpGain expScript;

    private const int basicMultiplier = 1;
    private const float pollutionMultiplier = 0.8f;

    private void Start()
    {
        LoadResources();
        coinsScript = GetComponent<CountNShowCoins>();
        expScript = GetComponent<ExpGain>();
        StartCoroutine(PollutionsDelay());
    }

    private void Pollute()
    {
        int amountOfTrash = Random.Range(_minTrashAmount, _trashRoots.Length);
        for (int i = 0; i < amountOfTrash; i++)
        {
            int rootId = Random.Range(0, _trashRoots.Length);
            if (!trashPlacements.Contains(rootId))
            {
                GameObject instance = Instantiate(_trashPrefab, _trashRoots[rootId]);

                Trash trash = instance.GetComponent<Trash>();

                int randomSpriteId = Random.Range(0, trashSOs.Length);

                trash.SetupTrash(trashSOs[randomSpriteId].trashSprite);

                trashPlacements.Add(rootId);
                coinsScript.PolluteMultiplier(pollutionMultiplier);
            }
            else
            {
                i--;
                continue;
            }
        }
    }

    private void CleanAll()
    {
        if (coinsScript.IsEnoughToBuy(_cleanCost))
        {
            coinsScript.PolluteMultiplier(basicMultiplier);
            trashPlacements.Clear();
        }
    }

    private IEnumerator PollutionsDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(_secsBetweenPollution);
        }
    }

    private void LoadResources()
    {
        trashSOs = Resources.LoadAll("SO/TrashSO", typeof(TrashSO))
            .Cast<TrashSO>()
            .ToArray();
        
    }
}
