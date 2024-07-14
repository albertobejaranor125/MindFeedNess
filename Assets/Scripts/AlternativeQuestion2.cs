using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AlternativeQuestion2 : DecisionNode
{
    private Animator animatorEyes;
    public GameObject eyeBlink;

    protected override void Start()
    {
        base.Start();
        animatorEyes = eyeBlink.GetComponent<Animator>();
    }
    public override void initNode()
    {
        base.initNode();
        animatorEyes.enabled = true;
    }
    public override void updateNode()
    {
        if (PathActual == -1 && Input.GetKey(KeyCode.LeftArrow))
        {
            question.SetActive(false);
            PathActual = 0;
            NodoActual = -1;
            eyeBlink.SetActive(true);
            animatorEyes.SetTrigger("StayWakeUp");
            changeNode();
        }
        if (PathActual == -1 && Input.GetKey(KeyCode.RightArrow))
        {
            question.SetActive(false);
            PathActual = 1;
            NodoActual = -1;
            eyeBlink.SetActive(true);
            animatorEyes.SetTrigger("EyesBlinkingOn");
            changeNode();
        }
        if (PathActual != -1 && animatorEyes.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            eyeBlink.SetActive(false);
            moveToNextPoint();
        }
    }
}
