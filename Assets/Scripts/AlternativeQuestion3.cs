using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeQuestion3 : DecisionNode
{
    public GameObject bedBlanket;
    [SerializeField] private AnimationClip bedBlanketIdle;
    public GameObject dogs;
    public GameObject eyeBlink;
    private Animator bedBlanketAnimation;
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
    }
    
    public override void updateNode()
    {
        if (PathActual == -1 && Input.GetKey(KeyCode.LeftArrow))
        {
            question.SetActive(false);
            PathActual = 0;
            NodoActual = -1;
            bedBlanketAnimation.SetTrigger("NoCoverBlanket");
            changeNode();
        }
        if (PathActual == -1 && Input.GetKey(KeyCode.RightArrow))
        {
            question.SetActive(false);
            PathActual = 1;
            NodoActual = -1;
            
            bedBlanketAnimation.SetTrigger("CoverBlanket");
            changeNode();
        }
        if (PathActual != -1 && bedBlanketAnimation.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            dogs.GetComponent<AudioSource>().loop = true;
            dogs.GetComponent<AudioSource>().Play();
            moveToNextPoint();
        }
    }
}
