using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Dialogues : MonoBehaviour
{
    [SerializeField] private List<int> levelDialoguesRequirLvls = new List<int>();
    [SerializeField] private List<GameObject> levelBasedDialoguesGO = new List<GameObject>();

    [SerializeField] private GameObject startingDialogue;
    private bool _isStartDialogueOut = false;

    [SerializeField] private GameObject genDoneDial;
    [SerializeField] private GameObject moneyTakenDial;

    [SerializeField] private Save save;

    private int singleDialoguesId = 0;

    private void Start()
    {
        StartingGameDialogue();
    }

    private void StartingGameDialogue()
    {
        if (!_isStartDialogueOut)
        {
            ActivateSingleDialogue(startingDialogue);
        }
    }

    public void ActivateSingleDialogue(GameObject dialogue)
    {
        if (!PlayerPrefs.HasKey("SingleDialogue-" + singleDialoguesId))
        {
            dialogue.transform.GetChild(0).gameObject.SetActive(true);
            save.SaveSingleDialoguesOut(1, singleDialoguesId);
            singleDialoguesId++;
        }
    }

    public void RequiredLevelAchieved(int currLvl)
    {
        int requirLvlIndex = levelDialoguesRequirLvls.IndexOf(currLvl);
        Debug.Log(PlayerPrefs.HasKey("LevelDialogue-" + requirLvlIndex));
        Debug.Log(levelDialoguesRequirLvls.Contains(currLvl));
        if (levelDialoguesRequirLvls.Contains(currLvl) && PlayerPrefs.GetInt("LevelDialogue-" + requirLvlIndex) == requirLvlIndex)
        {
            levelBasedDialoguesGO[requirLvlIndex].transform.GetChild(0).gameObject.SetActive(true);
            save.SaveLevelDialoguesOut(levelDialoguesRequirLvls.Count, requirLvlIndex);
        }
    }

    public void SetupGeneratorsDialogues(List<Generator> generators)
    {
        Dialogues dialogues = transform.GetComponent<Dialogues>();
        foreach (Generator generator in generators)
        {
            generator.SetupGeneratorDialogues(dialogues, genDoneDial, moneyTakenDial);
        }
    }
}
