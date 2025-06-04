using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Animations;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{
    public Sprite workerSprite;

    public float workerCost;

    public float XPMultiplayer;

    public float coinsMultiplayer;

    public string workerName;

    //private AnimatorController animatorController;
    [SerializeField]
    private Animator animator;
    private AnimationClip workerAnimation;

    private Generator generatorScript;

    public void SetupWorker(Sprite WorkerSprite, float WorkerCost, float WorkerXPMultiplayer, float WorkerCoinsMultiplayer,
        string WorkerName, /*AnimatorController AnimatorController,*/ AnimationClip WorkerAnimation)
    {
        animator.SetTrigger(WorkerAnimation.name);
        Image image = GetComponent<Image>();
        image.color = Color.white;

        workerSprite = WorkerSprite;
        image.sprite = WorkerSprite;
        //Debug.Log(workerSprite);
        //Debug.Log(image.sprite);
        workerCost = WorkerCost;
        coinsMultiplayer = WorkerCoinsMultiplayer;
        XPMultiplayer = WorkerXPMultiplayer;
        workerName = WorkerName;
        workerAnimation = WorkerAnimation;
        //animatorController = AnimatorController;
    }

    //private void Start()
    //{
    //    SetupAnimator();
    //}

    //private void SetupAnimator()
    //{
    //    animator = GetComponent<Animator>();
    //    RuntimeAnimatorController anim = animatorController;
    //    animator.runtimeAnimatorController = anim;
    //}

    public void WorkerSet()
    {
        generatorScript = GetComponentInParent<Generator>();
        generatorScript.WorkerOnGenerator(coinsMultiplayer, XPMultiplayer);
        
    }
    public void WorkerOff()
    {
        generatorScript = GetComponentInParent<Generator>();
        generatorScript.WorkerOffGenerator(coinsMultiplayer, XPMultiplayer);
    }
}
