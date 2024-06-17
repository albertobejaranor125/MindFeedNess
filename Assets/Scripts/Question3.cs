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
    [SerializeField] private GameObject logTree1;
    [SerializeField] private GameObject logTree2;
    [SerializeField] private GameObject logTree3;
    [SerializeField] private GameObject bridgeLog;
    [SerializeField] private GameObject axeSecondCross;
    private int logCutted = 0;
    private void Start()
    {
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
        base.updateNode();
        if(PathActual == 0 && this.name == "SphereFourthChangeDirectionAndTakeAxe" && logCutted < 3)
        {
            while (logCutted < 3)
            {
                animatorAxe.Play("AxeSecondCrossIdle");
                animatorAxe.Play("AxeSecondCrossCut");
                if (logCutted == 0)
                {
                    logTree1.SetActive(true);
                    animatorLog1.Play("LogTree1Idle");
                    changeNode();
                }
                else if (logCutted == 1)
                {
                    logTree2.SetActive(true);
                    animatorLog2.Play("LogTree2Idle");
                    changeNode();
                }else if (logCutted == 2)
                {
                    logTree3.SetActive(true);
                    animatorLog3.Play("LogTree3Idle");
                    changeNode();
                }
                logCutted++;
            }
            /*animationClips.Play("AxeSecondCrossIdle");
            animationClips.Stop("AxeSecondCrossIdle");
            animationClips.Play("AxeSecondCrossCut");
            animationClips.Stop("AxeSecondCrossCut");
            logTree1.SetActive(true);
            animationClips.Play("LogTree1Idle");
            animationClips.Stop("LogTree1Idle");
            logTree2.SetActive(true);
            animationClips.Play("LogTree2Idle");
            animationClips.Stop("LogTree2Idle");
            logTree3.SetActive(true);
            animationClips.Play("LogTree3Idle");
            animationClips.Stop("LogTree3Idle");*/
        }
        if(PathActual == 0 && this.name == "SpherePutLogAndCrossBridge" && logCutted == 3)
        {
            bridgeLog.SetActive(true);
        }
    }
}
