using UnityEngine;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Pollution : MonoBehaviour
{
    [SerializeField] private Transform[] _trashRoots;

    private TrashSO[] trashSOs;

    [SerializeField] private GameObject _trashPrefab;

    [SerializeField] private int _secsBetweenPollution = 120;

    [SerializeField] private int _minTrashAmount = 3;

    [SerializeField] private int _cleanCost = 100;

    List<int> trashPlacements = new List<int>();

    List<GameObject> trashObjects = new List<GameObject>();

    private bool _isPolluted;

    private CountNShowCoins coinsScript;
    private ExpGain expScript;

    [SerializeField] private int basicMultiplier = 1;
    [SerializeField] private float pollutionMultiplier = 0.8f;

    [SerializeField] private Button cleanUpButton;

    [SerializeField] private Dialogues dialogues;

    [SerializeField] private GameObject firstPollutionDialogue;
    private bool _pollutionDialogueOut = false;

    [SerializeField] private GameObject firstCleanUpDialogue;
    private bool _cleanUpDialogueOut = false;
   
    private void Start()
    {
        LoadResources();
        coinsScript = GetComponent<CountNShowCoins>();
        expScript = GetComponent<ExpGain>();
        StartCoroutine(PollutionsDelay());
    }

    private void Pollute()
    {
        if (!_isPolluted)
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

                    _isPolluted = true;
                    trashPlacements.Add(rootId);
                    trashObjects.Add(instance);
                    coinsScript.PolluteMultiplier(pollutionMultiplier);
                }
                else
                {
                    i--;
                    continue;
                }
            }
            FirstCleanUpDialogue(firstPollutionDialogue);
            cleanUpButton.gameObject.SetActive(true);
        }
    }

    public void CleanAll()
    {
        if (coinsScript.IsEnoughToBuy(_cleanCost))
        {
            coinsScript.AddCoins(-_cleanCost);
            _isPolluted = false;
            coinsScript.PolluteMultiplier(basicMultiplier);
            cleanUpButton.gameObject.SetActive(false);
            foreach (var gameObject in trashObjects)
            {
                Destroy(gameObject);
            }

            trashObjects.Clear();
            trashPlacements.Clear();

            FirstCleanUpDialogue(firstCleanUpDialogue);

            StartCoroutine(PollutionsDelay());
        }
    }

    //private void FirstPollutionDialogue()
    //{
    //    if (_pollutionDialogueOut)
    //    {
    //        dialogues.ActivateSingleDialogue(firstPollutionDialogue);
    //        _pollutionDialogueOut = true;
    //    }
    //}

    private void FirstCleanUpDialogue(GameObject dialogue)
    {
        if (!_cleanUpDialogueOut)
        {
            dialogues.ActivateSingleDialogue(dialogue);
        }
        if (dialogue == firstCleanUpDialogue)
        {
            _cleanUpDialogueOut = true;
        }
    }


    private IEnumerator PollutionsDelay()
    {
            yield return new WaitForSeconds(_secsBetweenPollution);
            Pollute();
    }

    private void LoadResources()
    {
        trashSOs = Resources.LoadAll("SO/TrashSO", typeof(TrashSO))
            .Cast<TrashSO>()
            .ToArray();
    }
}
