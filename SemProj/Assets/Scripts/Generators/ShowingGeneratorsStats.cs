using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowingGeneratorsStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameTMP;
    [SerializeField] private TextMeshProUGUI coinsProducTMP;
    [SerializeField] private TextMeshProUGUI expProducTMP;
    [SerializeField] private TextMeshProUGUI remainingTimeTMP;
    [SerializeField] private Image generatorRenderer;

    private Transform[] generatorRoots; 

    private Generator generator;
    private GeneratorTimer generatorTimer;

    private bool _isShowing = false;
    private void Awake()
    {
        generatorRoots = GetComponent<GeneratorPlacer>().GetGeneratorRoots();
    }

    public void ShowStats(int generatorId)
    {
        _isShowing = true;
        generator = generatorRoots[generatorId].GetComponentInChildren<Generator>();
        nameTMP.text = generator.name;
        generatorRenderer.sprite = generator.generatorSprite;
        coinsProducTMP.text = generator.coinsProducement.ToString();
        expProducTMP.text = generator.expProducement.ToString();
        generatorTimer = generator.GetComponentInChildren<GeneratorTimer>();
        StartCoroutine(ShowTimeInSecs());
    }

    private IEnumerator ShowTimeInSecs()
    {
        while (_isShowing)
        {
            remainingTimeTMP.text = Mathf.Round(generatorTimer.GetRemainingTime()).ToString();
            yield return new WaitForSeconds(1);
        }
    }

    public void StopShowing()
    {
        _isShowing = false;
    }
}
