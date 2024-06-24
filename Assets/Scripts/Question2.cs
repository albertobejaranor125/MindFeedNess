using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question2 : DecisionNode
{
    private Animator animationUmbrella;
    public GameObject umbrellaOpened;
    [SerializeField] private AnimationClip umbrellaAttract;
    [SerializeField] private AnimationClip umbrellaAttach;
    private bool isEndAnimation = false;
    protected override void Start()
    {
        base.Start();
        animationUmbrella = umbrellaOpened.GetComponent<Animator>();  
    }
    public override void initNode()
    {
        base.initNode();
        question.SetActive(false);
        animationUmbrella.enabled = true;
        StartCoroutine(PlayAnimation("UmbrellaAttract"));
        StartCoroutine(WaitFunction());
    }

    private IEnumerator PlayAnimation(string nameAnimation)
    {
        animationUmbrella.Play(nameAnimation);
        while (!isEndAnimation)
        {
            if(animationUmbrella.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                isEndAnimation = true;
            }
        }
        yield return null;
    }

    public override void updateNode()
    {
        base.updateNode();
        if(PathActual == 0)
        {
            StartCoroutine(PlayAnimation("UmbrellaAttach"));
            StartCoroutine(WaitFunction2());
        }
    }
    IEnumerator WaitFunction()
    {
        yield return new WaitForSeconds(3);
        question.SetActive(true);
    }
    IEnumerator WaitFunction2()
    {
        yield return new WaitForSeconds(5);
    }
    public override void endNode()
    {
        base.endNode();
        
    }
}
