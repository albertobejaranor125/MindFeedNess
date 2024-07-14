using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question2 : DecisionNode
{
    private Animator animationUmbrella;
    public GameObject umbrellaOpened;
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
        animationUmbrella.Play(nameAnimation, -1, 0);
        isEndAnimation = false;
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
        if (PathActual == -1 && Input.GetKey(KeyCode.LeftArrow))
        {
            question.SetActive(false);
            PathActual = 0;
            NodoActual = -1;
            animationUmbrella.SetTrigger("Attach");
            changeNode();
        }
        if (PathActual == -1 && Input.GetKey(KeyCode.RightArrow))
        {
            question.SetActive(false);
            PathActual = 1;
            NodoActual = -1;
            animationUmbrella.SetTrigger("BackHome");
            changeNode();
        }
        if (PathActual != -1 && animationUmbrella.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            moveToNextPoint();
        }
    }
    IEnumerator WaitFunction()
    {
        yield return new WaitForSeconds(3);
        question.SetActive(true);
    }
    public override void endNode()
    {
        base.endNode();
        umbrellaOpened.transform.position = player.transform.position;
        umbrellaOpened.transform.rotation = player.transform.rotation;
    }
}
