using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Question4 : DecisionNode
{
    public GameObject sheeps;
    public GameObject sheepChild1;
    public GameObject sheepChild2;
    public GameObject sheepChild3;
    public GameObject sheepChild4;
    public GameObject sheepChild5;
    public GameObject sheepChild6;
    public GameObject sheepChild7;
    public GameObject sheepChild8;
    public GameObject sheepChild9;
    public GameObject sheepChild10;
    public GameObject sheepChild11;
    public GameObject sheepChild12;
    public GameObject sheepChild13;
    public GameObject sheepChild14;
    public GameObject sheepChild15;
    public GameObject sheepChild16;
    public GameObject sheepChild17;
    public GameObject sheepChild18;
    public GameObject sheepChild19;
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
        sheepChild1.GetComponent<AudioSource>().enabled = true;
        sheepChild1.GetComponent<AudioSource>().loop = true;
        sheepChild1.GetComponent<AudioSource>().Play();
        sheepChild2.GetComponent<AudioSource>().enabled = true;
        sheepChild2.GetComponent<AudioSource>().loop = true;
        sheepChild2.GetComponent<AudioSource>().Play();
        sheepChild3.GetComponent<AudioSource>().enabled = true;
        sheepChild3.GetComponent<AudioSource>().loop = true;
        sheepChild3.GetComponent<AudioSource>().Play();
        sheepChild4.GetComponent<AudioSource>().enabled = true;
        sheepChild4.GetComponent<AudioSource>().loop = true;
        sheepChild4.GetComponent<AudioSource>().Play();
        sheepChild5.GetComponent<AudioSource>().enabled = true;
        sheepChild5.GetComponent<AudioSource>().loop = true;
        sheepChild5.GetComponent<AudioSource>().Play();
        sheepChild6.GetComponent<AudioSource>().enabled = true;
        sheepChild6.GetComponent<AudioSource>().loop = true;
        sheepChild6.GetComponent<AudioSource>().Play();
        sheepChild7.GetComponent<AudioSource>().enabled = true;
        sheepChild7.GetComponent<AudioSource>().loop = true;
        sheepChild7.GetComponent<AudioSource>().Play();
        sheepChild8.GetComponent<AudioSource>().enabled = true;
        sheepChild8.GetComponent<AudioSource>().loop = true;
        sheepChild8.GetComponent<AudioSource>().Play();
        sheepChild9.GetComponent<AudioSource>().enabled = true;
        sheepChild9.GetComponent<AudioSource>().loop = true;
        sheepChild9.GetComponent<AudioSource>().Play();
        sheepChild10.GetComponent<AudioSource>().enabled = true;
        sheepChild10.GetComponent<AudioSource>().loop = true;
        sheepChild10.GetComponent<AudioSource>().Play();
        sheepChild11.GetComponent<AudioSource>().enabled = true;
        sheepChild11.GetComponent<AudioSource>().loop = true;
        sheepChild11.GetComponent<AudioSource>().Play();
        sheepChild12.GetComponent<AudioSource>().enabled = true;
        sheepChild12.GetComponent<AudioSource>().loop = true;
        sheepChild12.GetComponent<AudioSource>().Play();
        sheepChild13.GetComponent<AudioSource>().enabled = true;
        sheepChild13.GetComponent<AudioSource>().loop = true;
        sheepChild13.GetComponent<AudioSource>().Play();
        sheepChild14.GetComponent<AudioSource>().enabled = true;
        sheepChild14.GetComponent<AudioSource>().loop = true;
        sheepChild14.GetComponent<AudioSource>().Play();
        sheepChild15.GetComponent<AudioSource>().enabled = true;
        sheepChild15.GetComponent<AudioSource>().loop = true;
        sheepChild15.GetComponent<AudioSource>().Play();
        sheepChild16.GetComponent<AudioSource>().enabled = true;
        sheepChild16.GetComponent<AudioSource>().loop = true;
        sheepChild16.GetComponent<AudioSource>().Play();
        sheepChild17.GetComponent<AudioSource>().enabled = true;
        sheepChild17.GetComponent<AudioSource>().loop = true;
        sheepChild17.GetComponent<AudioSource>().Play();
        sheepChild18.GetComponent<AudioSource>().enabled = true;
        sheepChild18.GetComponent<AudioSource>().loop = true;
        sheepChild18.GetComponent<AudioSource>().Play();
        sheepChild19.GetComponent<AudioSource>().enabled = true;
        sheepChild19.GetComponent<AudioSource>().loop = true;
        sheepChild19.GetComponent<AudioSource>().Play();
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
            SaveExport.getInstance().AddData("N4: Irritabilidad; 'no'");
            SaveExport.getInstance().AddData("N4: Agitación; 'no'");
            animatorSheep.enabled = true;
            double minusTime = (DateTime.Now - tiempo).TotalMilliseconds;
            Debug.Log("Question4 Minus Time: " + minusTime.ToString());
            while (minusTime <= 10000)
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
            SaveExport.getInstance().AddData("N4: Irritabilidad; 'sí'");
            SaveExport.getInstance().AddData("N4: Agitación; 'sí'");
            animatorSheep.enabled = true;
            audioSource.enabled = true;
            audioSource.Play(0);
            animatorSheep.SetTrigger("SheepsWalkAway");
            changeNode();
        }
        if (PathActual != -1 && animatorSheep.GetCurrentAnimatorStateInfo(0).IsName("SheepsIdle"))
        {
            sheepChild1.GetComponent<AudioSource>().loop = false;
            sheepChild1.GetComponent<AudioSource>().Stop();
            sheepChild2.GetComponent<AudioSource>().loop = false;
            sheepChild2.GetComponent<AudioSource>().Stop();
            sheepChild3.GetComponent<AudioSource>().loop = false;
            sheepChild3.GetComponent<AudioSource>().Stop();
            sheepChild4.GetComponent<AudioSource>().loop = false;
            sheepChild4.GetComponent<AudioSource>().Stop();
            sheepChild5.GetComponent<AudioSource>().loop = false;
            sheepChild5.GetComponent<AudioSource>().Stop();
            sheepChild6.GetComponent<AudioSource>().loop = false;
            sheepChild6.GetComponent<AudioSource>().Stop();
            sheepChild7.GetComponent<AudioSource>().loop = false;
            sheepChild7.GetComponent<AudioSource>().Stop();
            sheepChild8.GetComponent<AudioSource>().loop = false;
            sheepChild8.GetComponent<AudioSource>().Stop();
            sheepChild9.GetComponent<AudioSource>().loop = false;
            sheepChild9.GetComponent<AudioSource>().Stop();
            sheepChild10.GetComponent<AudioSource>().loop = false;
            sheepChild10.GetComponent<AudioSource>().Stop();
            sheepChild11.GetComponent<AudioSource>().loop = false;
            sheepChild11.GetComponent<AudioSource>().Stop();
            sheepChild12.GetComponent<AudioSource>().loop = false;
            sheepChild12.GetComponent<AudioSource>().Stop();
            sheepChild13.GetComponent<AudioSource>().loop = false;
            sheepChild13.GetComponent<AudioSource>().Stop();
            sheepChild14.GetComponent<AudioSource>().loop = false;
            sheepChild14.GetComponent<AudioSource>().Stop();
            sheepChild15.GetComponent<AudioSource>().loop = false;
            sheepChild15.GetComponent<AudioSource>().Stop();
            sheepChild16.GetComponent<AudioSource>().loop = false;
            sheepChild16.GetComponent<AudioSource>().Stop();
            sheepChild17.GetComponent<AudioSource>().loop = false;
            sheepChild17.GetComponent<AudioSource>().Stop();
            sheepChild18.GetComponent<AudioSource>().loop = false;
            sheepChild18.GetComponent<AudioSource>().Stop();
            sheepChild19.GetComponent<AudioSource>().loop = false;
            sheepChild19.GetComponent<AudioSource>().Stop();
            moveToNextPoint();
        }
        
    }
}
