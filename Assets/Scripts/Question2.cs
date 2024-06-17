using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question2 : DecisionNode
{
    private Animator animationUmbrella;
    [SerializeField] private GameObject umbrellaOpened;
    [SerializeField] private AnimationClip umbrellaAttract;
    [SerializeField] private AnimationClip umbrellaAttach;
    private bool isEndAnimation = false;
    private void Start()
    {
        animationUmbrella = umbrellaOpened.GetComponent<Animator>();
        
    }
    public override void initNode()
    {
        base.initNode();
        animationUmbrella.enabled = true;
        StartCoroutine(PlayAnimation("UmbrellaAttract"));
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
            yield return null;
        }
        question.SetActive(true);
    }

    public override void updateNode()
    {
        base.updateNode();
        if(PathActual == 0)
        {
            animationUmbrella.Play("UmbrellaAttach");
            umbrellaOpened.transform.position = this.transform.position;
        }
    }
    public override void endNode()
    {
        base.endNode();
        
    }
}
