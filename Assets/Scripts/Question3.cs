using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class Question3 : DecisionNode
{
    protected enum state { none, cogerHacha, cortar1, cortar2, cortar3, irse}
    protected state estado;
    private Animator animatorAxe;
    private Animator animatorLog1;
    private Animator animatorLog2;
    private Animator animatorLog3;
    public GameObject logTree1;
    public GameObject logTree2;
    public GameObject logTree3;
    public GameObject bridgeLog;
    public GameObject axeSecondCross;
    //private int logCutted;
    private DateTime tiempo;
    /*en el update
(Datetime.Now-tiempo).TotalMilliseconds*/
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
        tiempo = DateTime.Now;
        estado = state.none;
    }
    public override void updateNode()
    {
        //Debug.Log("Question3 Minus Time: "+(DateTime.Now - tiempo).TotalMilliseconds.ToString());
        //Debug.Log("Animation current name: " + animatorAxe.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        if (PathActual == -1 && Input.GetKey(KeyCode.LeftArrow))
        {
            question.SetActive(false);
            PathActual = 0;
            NodoActual = -1;
            SaveExport.getInstance().AddData("N3: Energia; 'si'");
            SaveExport.getInstance().AddData("N3: Fatiga; 'no'");
            changeNode();
        }
        if (PathActual == -1 && Input.GetKey(KeyCode.RightArrow))
        {
            question.SetActive(false);
            PathActual = 1;
            NodoActual = -1;
            SaveExport.getInstance().AddData("N3: Energia; 'no'");
            SaveExport.getInstance().AddData("N3: Fatiga; 'si'");
            animatorAxe.SetTrigger("AnotherPath");
            estado = state.irse;
            changeNode();
        }
        if (PathActual == 0 && NodoActual == -1)
        {
            moveToNextPoint();
        }
        if(PathActual == 0 && nameNode == "SphereFourthChangeDirectionAndTakeAxe")
        {
            double minusTime = (DateTime.Now - tiempo).TotalMilliseconds;
            Debug.Log("Question3 Minus Time: " + minusTime.ToString());
            if (estado == state.none)
            {
                animatorAxe.SetTrigger("TakeAxe");
                estado = state.cogerHacha;
            }
            if(estado == state.cogerHacha)
            {
                animatorAxe.SetTrigger("Cut");
                estado = state.cortar1;
                while (minusTime <= 7000)
                {
                    minusTime = (DateTime.Now - tiempo).TotalMilliseconds;
                }
                logTree1.SetActive(true);
            }
            if(estado == state.cortar1)
            {
                animatorAxe.SetTrigger("Cut");
                estado = state.cortar2;
                while (minusTime <= 10000)
                {
                    minusTime = (DateTime.Now - tiempo).TotalMilliseconds;
                }
                logTree2.SetActive(true);
            }
            if (estado == state.cortar2)
            {
                animatorAxe.SetTrigger("Cut");
                estado = state.cortar3;
                while (minusTime <= 13000)
                {
                    minusTime = (DateTime.Now - tiempo).TotalMilliseconds;
                }
                logTree3.SetActive(true);
            }
            if (estado == state.cortar3)
            {
                animatorAxe.SetTrigger("EndCut");
                estado = state.irse;
            }
        }
        if (PathActual != -1 && estado == state.irse)
        {
            moveToNextPoint();
        }
        if(PathActual == 0 && nameNode == "SpherePutLogAndCrossBridge")
        {
            bridgeLog.SetActive(true);
        }
    }
   
}
