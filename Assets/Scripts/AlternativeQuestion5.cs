using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeQuestion5 : DecisionNode
{
    public GameObject bedBlanket;
    public GameObject axeFirstCross;
    public GameObject logTreeFireplace1;
    public GameObject logTreeFireplace2;
    public GameObject logTreeFireplace3;
    public GameObject fireFireplace;
    public GameObject gameOverAlternativePath1;
    public GameObject gameOverAlternativePath2;
    public AnimationClip axeAlternativeIdle;
    public AnimationClip axeAlternativeCut;
    private Animator animatorAxe;
    private Animator bedBlanketAnimator;
    private int logCutted = 0;
    protected override void Start()
    {
        base.Start();
        bedBlanketAnimator = bedBlanket.GetComponent<Animator>();
        animatorAxe = axeFirstCross.GetComponent<Animator>();
    }
    public override void initNode()
    {
        base.initNode();
    }
    public override void updateNode()
    {
        base.updateNode();
        if(PathActual == 0 && nameNode == "AlternativeSphereFifthChoiceAndTakeAxe" && logCutted < 3)
        {
            
            animatorAxe.Play("Axe Alternative Idle");
            while(logCutted < 3){
                animatorAxe.Play("Axe Alternative Cut");
                if (logCutted == 0)
                {
                    logTreeFireplace1.SetActive(true);
                }
                else if (logCutted == 1)
                {
                    logTreeFireplace2.SetActive(true);
                }
                else if(logCutted == 2)
                {
                    logTreeFireplace3.SetActive(true);
                }
                logCutted++;
            }
            
        }
        if(PathActual == 0 && nameNode == "AlternativeSphereFifthChoiceAndTurnOn")
        {
            fireFireplace.SetActive(true);
            StartCoroutine(waitTurnOnFireplace());
        }
        if (PathActual == 1)
        {
            bedBlanketAnimator.Play("BedBlanketIdle");
        }
    }
    public override void endNode()
    {
        base.endNode();
        if(nameNode == "AlternativeSphereSecondChoice")
        {
            gameOverAlternativePath1.SetActive(true);
        }
        if(nameNode == "AlternativeSphereFifthChoiceOrTakeBlanket")
        {
            gameOverAlternativePath2.SetActive(true);
        }
    }
    IEnumerator waitTurnOnFireplace()
    {
        yield return new WaitForSeconds(10);
    }
}
