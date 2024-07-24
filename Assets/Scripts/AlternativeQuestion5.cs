using System;
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
    protected enum state { none, cogerHacha, cortar1, cortar2, cortar3, irse }
    protected state estado;
    private DateTime tiempo;
    protected override void Start()
    {
        base.Start();
        bedBlanketAnimator = bedBlanket.GetComponent<Animator>();
        animatorAxe = axeFirstCross.GetComponent<Animator>();
    }
    public override void initNode()
    {
        base.initNode();
        animatorAxe.enabled = true;
        estado = state.none;
        tiempo = DateTime.Now;
    }
    public override void updateNode()
    {
        if (PathActual == -1 && Input.GetKey(KeyCode.LeftArrow))
        {
            question.SetActive(false);
            PathActual = 0;
            NodoActual = -1;
            SaveExport.getInstance().AddData("AN5: Energía; 'sí'");
            SaveExport.getInstance().AddData("AN5: Fatiga; 'no'");
            changeNode();
        }
        if (PathActual == -1 && Input.GetKey(KeyCode.RightArrow))
        {
            question.SetActive(false);
            PathActual = 1;
            NodoActual = -1;
            SaveExport.getInstance().AddData("AN5: Energía; 'no'");
            SaveExport.getInstance().AddData("AN5: Fatiga; 'sí'");
            animatorAxe.SetTrigger("AnotherPath");
            estado = state.irse;
            changeNode();
        }
        if(PathActual == 0 && NodoActual == -1)
        {
            moveToNextPoint();
        }
        if (PathActual != -1 && estado == state.irse)
        {
            moveToNextPoint();
        }
        if (PathActual == 0 && nameNode == "AlternativeSphereFifthChoiceAndTakeAxe")
        {
            double minusTime = (DateTime.Now - tiempo).TotalMilliseconds;
            Debug.Log("AlternativeQuestion5 Minus Time: " + minusTime.ToString());
            if (estado == state.none)
            {
                animatorAxe.SetTrigger("TakeAxe");
                estado = state.cogerHacha;
            }
            if (estado == state.cogerHacha)
            {
                animatorAxe.SetTrigger("Cut");
                estado = state.cortar1;
                while(minusTime <= 11000)
                {
                    minusTime = (DateTime.Now - tiempo).TotalMilliseconds;
                }
                logTreeFireplace1.SetActive(true);
            }
            if (estado == state.cortar1)
            {
                animatorAxe.SetTrigger("Cut");
                estado = state.cortar2;
                while (minusTime <= 14000)
                {
                    minusTime = (DateTime.Now - tiempo).TotalMilliseconds;
                }
                logTreeFireplace2.SetActive(true);
            }
            if (estado == state.cortar2)
            {
                animatorAxe.SetTrigger("Cut");
                estado = state.cortar3;
                while (minusTime <= 17000)
                {
                    minusTime = (DateTime.Now - tiempo).TotalMilliseconds;
                }
                logTreeFireplace3.SetActive(true);
            }
            if (estado == state.cortar3)
            {
                animatorAxe.SetTrigger("EndCut");
                estado = state.irse;
            }
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

}
