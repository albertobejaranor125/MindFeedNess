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
        
    }
    public override void initNode()
    {
        base.initNode();
        
    }
    
    public override void updateNode()
    {
        
        if(PathActual == 0)
        {
            dogs.GetComponent<AudioSource>().loop = true;
            dogs.GetComponent<AudioSource>().Play();
        }
        if(PathActual == 1)
        {
            bedBlanketAnimation.Play("BedBlanketIdle");
            dogs.GetComponent<AudioSource>().loop = true;
            dogs.GetComponent<AudioSource>().Play();
        }
        base.updateNode();
    }
}
