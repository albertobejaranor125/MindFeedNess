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
        if (PathActual == -1 && Input.GetKey(KeyCode.LeftArrow))
        {
            question.SetActive(false);
            PathActual = 0;
            NodoActual = -1;
            changeNode();
        }
        if (PathActual == -1 && Input.GetKey(KeyCode.RightArrow))
        {
            question.SetActive(false);
            PathActual = 1;
            NodoActual = -1;
            changeNode();
        }
        if (PathActual != -1)
        {
            moveToNextPoint();
        }
        if (PathActual == 0 && nameNode == "AlternativeSphereFifthChoiceAndTakeAxe" && logCutted < 3)
        {
            cutLog();
        }
        if(PathActual == 0 && nameNode == "AlternativeSphereFifthChoiceAndTurnOn")
        {
            fireFireplace.SetActive(true);
        }
        if (PathActual == 1 && nameNode == "AlternativeSphereFifthChoiceOrTakeBlanket")
        {
            bedBlanketAnimator.SetTrigger("CoverBlanket");
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
    private void cutLog()
    {
        logCutted = 0;
        while (logCutted < 3)
        {
            if (logCutted == 0)
            {
                animatorAxe.SetTrigger("Cut1");
                logTreeFireplace1.SetActive(true);
            }
            else if (logCutted == 1)
            {
                animatorAxe.SetTrigger("Cut2");
                logTreeFireplace2.SetActive(true);
            }
            else if (logCutted == 2)
            {
                animatorAxe.SetTrigger("Cut3");
                logTreeFireplace3.SetActive(true);
            }
            logCutted++;
        }

    }
    /*IEnumerator waitTurnOnFireplace()
    {
        yield return new WaitForSeconds(10);
    }*/
}
