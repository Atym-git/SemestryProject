using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LMBClicker : MonoBehaviour
{
    private int coinsPerLMB = 1;
    private int maxCoinsPerCd = 50;
    private int currClicksAmount = 0;

    [SerializeField] private int upgradeCost = 30;
    [SerializeField] private TextMeshProUGUI costTMP;

    [SerializeField] private Image danceFloor;

    [SerializeField] private Sprite defaultDFSprite; //DF = Dance Floor
    [SerializeField] private Sprite onCooldownDFSprite;
    [SerializeField] private Sprite upgradedDFSprite;

    [SerializeField] private Image shopCard;
    [SerializeField] private Sprite boughtSprite;

    [SerializeField] private float _cooldownTime = 10;
    private bool _onCooldown = false;

    //[SerializeField] private Button _clickerBut;
    [SerializeField] private CountNShowCoins coinsScript;

    [SerializeField] private AudioClip clickClip;
    [SerializeField] private float clickVolume = 0.05f;

    [SerializeField] private GameObject animationGameObject;

    [SerializeField] private Save save;

    private void Start()
    {
        //_clickerBut.onClick.AddListener(Clicker);
        danceFloor.sprite = defaultDFSprite;
        costTMP.text = upgradeCost.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);
            if (mousePos.x < 1210)
            {
                Clicker();
            }
        }
    }

    private void Clicker()
    {
        if (!_onCooldown)
        {
            SoundFXManager.SFXinstance.PlaySoundFXClip(clickClip, transform, clickVolume);
            coinsScript.AddCoins(coinsPerLMB);
            currClicksAmount++;
        }
        if (currClicksAmount >= maxCoinsPerCd)
        {
            _onCooldown = true;
            StartCoroutine(Cooldown());
            currClicksAmount = 0;
        }
    }

    private IEnumerator Cooldown()
    {
        danceFloor.sprite = onCooldownDFSprite;
        yield return new WaitForSeconds(_cooldownTime);
        danceFloor.sprite = defaultDFSprite;
        _onCooldown = false;
    }

    public void DanceFloorUpgrade()
    {
        CountNShowCoins coins = SingleToneManager.coinsScript;
        if (coins.IsEnoughToBuy(upgradeCost))
        {
            coins.AddCoins(-upgradeCost);
            coinsPerLMB++;
            StockCardsInSt();
            //StopCoroutine(Cooldown());
            defaultDFSprite = upgradedDFSprite;
            _onCooldown = false;
            danceFloor.sprite = defaultDFSprite;

            save.SaveDanceFloorUpgrade();
        }
    }

    private void StockCardsInSt()
    {
        Button button = shopCard.GetComponent<Button>();
        button.interactable = false;
        Destroy(costTMP);
        shopCard.sprite = boughtSprite;
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //SoundFXManager.SFXinstance.PlaySoundFXClip(clickClip, transform, clickVolume);
    ////Vector3 mousePos = Input.mousePosition;
    ////Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);
    ////Instantiate(animationGameObject, eventData.pressPosition, Quaternion.identity);
    //coinsScript.AddCoins(coinsPerLMB);
    //}
}
