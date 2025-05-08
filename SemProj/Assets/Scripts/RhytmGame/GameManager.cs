using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource music;

    [SerializeField] private bool startPlaying;

    [SerializeField] private BeatScroller mBeatScroller;

    public static GameManager instance;

    private int currentScore = 0;
    [SerializeField] private int scorePerNote = 100;
    [SerializeField] private int scorePerGoodNote = 125;
    [SerializeField] private int scorePerPerfectNote = 150;

    [SerializeField] private GameObject hitIndicatorObject;
    [SerializeField] private float hitIndicatorShowTime = 0.1f;
    [SerializeField] private TextMeshProUGUI scoreTMP;

    [SerializeField] private GameObject anyKeyDownTMP;

    private void Start()
    {
        instance = this;
        scoreTMP.text = "Score: 0";
    }

    private void Update()
    {
        StartMusic();
    }

    public void NoteHit()
    {
        //currentScore += scorePerNote;
        StartCoroutine(HitIndicatior());
        scoreTMP.text = "Score: " + currentScore.ToString();
        
    }

    private IEnumerator HitIndicatior()
    {
        hitIndicatorObject.SetActive(true);
        yield return new WaitForSeconds(hitIndicatorShowTime);
        hitIndicatorObject.SetActive(false);
    }

    public void NormalHit()
    {
        currentScore += scorePerNote;
        NoteHit();
    }
    public void GoodHit()
    {
        currentScore += scorePerGoodNote;
        NoteHit();
    }
    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote;
        NoteHit();
    }

    private void StartMusic()
    {
        if (!startPlaying && Input.anyKeyDown)
        {
            Destroy(anyKeyDownTMP);
            startPlaying = true;
            mBeatScroller.hasStarted = true;

            music.Play();
        }
    }
}
