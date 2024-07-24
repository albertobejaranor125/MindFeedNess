using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeQUestion4 : DecisionNode
{
    public GameObject dogs;
    public GameObject shoes;
    private Animator animatorDog;
    private Animator animatorShoes;
    private DateTime tiempo;
    private AudioSource audioSource;
    protected enum state { none, perroCorrer, irse }
    protected state estado;
    protected override void Start()
    {
        base.Start();
        animatorDog = dogs.GetComponent<Animator>();
        animatorShoes = shoes.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public override void initNode()
    {
        base.initNode();
        /*animatorDog.enabled = true;
        animatorShoes.enabled = true;*/
        tiempo = DateTime.Now;
        audioSource.enabled = true;
        estado = state.none;
    }
    public override void updateNode()
    {
        if (PathActual == -1 && Input.GetKey(KeyCode.LeftArrow))
        {
            question.SetActive(false);
            PathActual = 0;
            NodoActual = -1;
            SaveExport.getInstance().AddData("AN4: Irritabilidad; 'no'");
            SaveExport.getInstance().AddData("AN4: Agitación; 'no'");
            double minusTime = (DateTime.Now - tiempo).TotalMilliseconds;
            animatorDog.SetTrigger("DogAway");
            estado = state.perroCorrer;
            Debug.Log("AlternativeQuestion4 Path_1 Minus Time: " + minusTime.ToString());
            while (minusTime <= 13000)
            {
                minusTime = (DateTime.Now - tiempo).TotalMilliseconds;
            }
            animatorDog.SetTrigger("EndDogAway");
            estado = state.irse;
            dogs.GetComponent<AudioSource>().loop = false;
            dogs.GetComponent<AudioSource>().Stop();
            changeNode();
        }
        if (PathActual == -1 && Input.GetKey(KeyCode.RightArrow))
        {
            question.SetActive(false);
            PathActual = 1;
            NodoActual = -1;
            SaveExport.getInstance().AddData("AN4: Irritabilidad; 'sí'");
            SaveExport.getInstance().AddData("AN4: Agitación; 'sí'");
            shoes.SetActive(true);
            changeNode();
        }
        if(PathActual != -1 && estado == state.irse)
        {
            moveToNextPoint();
        }
        if(PathActual == 1 && nameNode == "AlternativeSphereFourthChoiceAlternateFirstChangeDirection")
        {
            animatorShoes.SetTrigger("TakeShoes");
            shoes.transform.position = player.transform.position;
            shoes.transform.rotation = player.transform.rotation;
        }
        if(PathActual == 1 && nameNode == "AlternativeSphereFourthChoiceAlternateThirdChangeDirection")
        {
            animatorShoes.SetTrigger("ScareDogWithShoes");
            audioSource.Play(0);
            animatorDog.SetTrigger("DogAway");
            estado = state.perroCorrer;
            double minusTime2 = (DateTime.Now - tiempo).TotalMilliseconds;
            Debug.Log("AlternativeQuestion4 Path_2 Minus Time: " + minusTime2.ToString());
            while (minusTime2 <= 16000)
            {
                minusTime2 = (DateTime.Now - tiempo).TotalMilliseconds;
            }
            animatorDog.SetTrigger("EndDogAway");
            estado = state.irse;
            dogs.GetComponent<AudioSource>().loop = false;
            dogs.GetComponent<AudioSource>().Stop();
        }
        if(PathActual == 1 && estado == state.none)
        {
            moveToNextPoint();
        }
    }
}
