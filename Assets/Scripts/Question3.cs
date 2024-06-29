using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Question3 : DecisionNode
{
    private Animator animatorAxe;
    private Animator animatorLog1;
    private Animator animatorLog2;
    private Animator animatorLog3;
    [SerializeField] private AnimationClip axeSecondCrossIdle;
    [SerializeField] private AnimationClip axeSecondCrossCut;
    [SerializeField] private AnimationClip logTree1Idle;
    [SerializeField] private AnimationClip logTree2Idle;
    [SerializeField] private AnimationClip logTree3Idle;
    public GameObject logTree1;
    public GameObject logTree2;
    public GameObject logTree3;
    public GameObject bridgeLog;
    public GameObject axeSecondCross;
    private int logCutted;
    protected override void Start()
    {
        base.Start();
        animatorAxe = axeSecondCross.GetComponent<Animator>();
        animatorLog1 = logTree1.GetComponent<Animator>();
        animatorLog2 = logTree2.GetComponent<Animator>();
        animatorLog3 = logTree3.GetComponent<Animator>();
    }
    public override void initNode()
    {
        base.initNode();
        animatorAxe.enabled = true;
    }
    public override void updateNode()
    {
        if (PathActual == -1 && Input.GetKey(KeyCode.LeftArrow))
        {
            question.SetActive(false);
            PathActual = 0;
            NodoActual = -1;
            animatorAxe.SetTrigger("TakeAxe");
            cutLog();
            changeNode();
        }
        if (PathActual == -1 && Input.GetKey(KeyCode.RightArrow))
        {
            question.SetActive(false);
            PathActual = 1;
            NodoActual = -1;
            animatorAxe.SetTrigger("AnotherPath");
            changeNode();
        }
        if (PathActual != -1 && animatorAxe.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            moveToNextPoint();
        }
        if(PathActual == 0 && nameNode == "SpherePutLogAndCrossBridge" && logCutted == 3)
        {
            bridgeLog.SetActive(true);
        }
    }

    private void cutLog()
    {
        logCutted = 0;
        while (logCutted < 3)
        {
            if (logCutted == 0)
            {
                animatorAxe.SetTrigger("Cut1");
                logTree1.SetActive(true);
                animatorLog1.Play("LogTree1Idle");
            }
            else if (logCutted == 1)
            {
                animatorAxe.SetTrigger("Cut2");
                logTree2.SetActive(true);
                animatorLog2.Play("LogTree2Idle");
            }
            else if (logCutted == 2)
            {
                animatorAxe.SetTrigger("Cut3");
                logTree3.SetActive(true);
                animatorLog3.Play("LogTree3Idle");
            }
            logCutted++;
        }

    }
}
