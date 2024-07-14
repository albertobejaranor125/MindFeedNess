using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeQuestion3 : DecisionNode
{
    public GameObject bedBlanket;
    public GameObject dogs;
    public GameObject eyeBlink;
    private Animator bedBlanketAnimation;
    protected enum state { none, cogerManta, noCogerManta, irse }
    protected state estado;
    private DateTime tiempo;
    protected override void Start()
    {
        base.Start();
        bedBlanketAnimation = bedBlanket.GetComponent<Animator>();
        /*dogs.GetComponent<AudioSource>().loop = true;
        dogs.GetComponent<AudioSource>().Play();*/
    }
    public override void initNode()
    {
        base.initNode();
        bedBlanketAnimation.enabled = true;
        question.SetActive(false);
        tiempo = DateTime.Now;
        StartCoroutine(WaitFunction());
    }
    
    public override void updateNode()
    {
        if (PathActual == -1 && Input.GetKey(KeyCode.LeftArrow))
        {
            question.SetActive(false);
            PathActual = 0;
            NodoActual = -1;
            bedBlanketAnimation.SetTrigger("NoCoverBlanket");
            estado = state.noCogerManta;
            bedBlanketAnimation.SetTrigger("EndBlanket");
            estado = state.irse;
            changeNode();
        }
        if (PathActual == -1 && Input.GetKey(KeyCode.RightArrow))
        {
            question.SetActive(false);
            PathActual = 1;
            NodoActual = -1;
            bedBlanketAnimation.SetTrigger("CoverBlanket");
            estado = state.cogerManta;
            double minusTime = (DateTime.Now - tiempo).TotalMilliseconds;
            Debug.Log("AlternativeQuestion3 Minus Time: " + minusTime.ToString());
            while (minusTime < 7000)
            {
                minusTime = (DateTime.Now - tiempo).TotalMilliseconds;
            }
            bedBlanketAnimation.SetTrigger("EndBlanket");
            estado = state.irse;
            changeNode();
        }
        if (PathActual != -1 && estado == state.irse)
        {
            dogs.GetComponent<AudioSource>().loop = true;
            dogs.GetComponent<AudioSource>().Play();
            moveToNextPoint();
        }
    }
    IEnumerator WaitFunction()
    {
        yield return new WaitForSeconds(3);
        question.SetActive(true);
    }
}
