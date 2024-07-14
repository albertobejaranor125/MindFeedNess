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
            changeNode();
        }
        if (PathActual == -1 && Input.GetKey(KeyCode.RightArrow))
        {
            question.SetActive(false);
            PathActual = 1;
            NodoActual = -1;
            animatorAxe.SetTrigger("AnotherPath");
            estado = state.irse;
            changeNode();
        }
        if (PathActual == 0 && NodoActual == -1)
        {
            moveToNextPoint();
        }
        /*if(PathActual == 0 && estado == state.none)
        {
            animatorAxe.SetTrigger("TakeAxe");
            estado = state.cogerHacha;
        }
        if(estado == state.cogerHacha && PathActual == 0)
        {
            estado = state.cortar1;
            animatorAxe.SetTrigger("Cut");
            logTree1.SetActive(true);
        }
        if (estado == state.cortar1 && PathActual == 0)
        {
            estado = state.cortar2;
            animatorAxe.SetTrigger("Cut");
            logTree2.SetActive(true);
        }
        if (estado == state.cortar2 && PathActual == 0)
        {
            estado = state.cortar3;
            animatorAxe.SetTrigger("Cut");
            logTree3.SetActive(true);
        }
        if (estado == state.cortar3 && PathActual == 0)
        {
            estado = state.irse;
            animatorAxe.SetTrigger("EndCut");
        }*/
        if(PathActual == 0 && nameNode == "SphereFourthChangeDirectionAndTakeAxe")
        {
            if(estado == state.none)
            {
                animatorAxe.SetTrigger("TakeAxe");
                estado = state.cogerHacha;
            }
            if(estado == state.cogerHacha)
            {
                animatorAxe.SetTrigger("Cut");
                estado = state.cortar1;
                logTree1.SetActive(true);
            }
            if(estado == state.cortar1)
            {
                animatorAxe.SetTrigger("Cut");
                estado = state.cortar2;
                logTree2.SetActive(true);
            }
            if (estado == state.cortar2)
            {
                animatorAxe.SetTrigger("Cut");
                estado = state.cortar3;
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
