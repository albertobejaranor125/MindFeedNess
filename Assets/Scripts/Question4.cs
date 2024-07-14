using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Question4 : DecisionNode
{
    public GameObject sheeps;
    public AnimationClip sheepIdle;
    public AudioClip angrySound;
    private Animator animatorSheep;
    private AudioSource audioSource;
    private DateTime tiempo;
    protected override void Start()
    {
        base.Start();
        animatorSheep = sheeps.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
        sheeps.GetComponent<AudioSource>().Play();
        sheeps.GetComponent<AudioSource>().loop = true;
    }
    public override void initNode()
    {
        base.initNode();
        sheeps.SetActive(true);
        audioSource.enabled = true;
        tiempo = DateTime.Now;
    }
    public override void updateNode()
    {
        if (PathActual == -1 && Input.GetKey(KeyCode.LeftArrow))
        {
            question.SetActive(false);
            PathActual = 0;
            NodoActual = -1;
            animatorSheep.enabled = true;
            double minusTime = (DateTime.Now - tiempo).TotalMilliseconds;
            Debug.Log("Question4 Minus Time: " + minusTime.ToString());
            while (minusTime < 10000)
            {
                minusTime = (DateTime.Now - tiempo).TotalMilliseconds;
            }
            animatorSheep.SetTrigger("SheepsWalkAway");
            changeNode();
        }
        if (PathActual == -1 && Input.GetKey(KeyCode.RightArrow))
        {
            question.SetActive(false);
            PathActual = 1;
            NodoActual = -1;
            animatorSheep.enabled = true;
            audioSource.Play(0);
            animatorSheep.SetTrigger("SheepsWalkAway");
            changeNode();
        }
        if (PathActual != -1 && animatorSheep.GetCurrentAnimatorStateInfo(0).IsName("SheepsIdle"))
        {
            moveToNextPoint();
        }
        
    }
}
