using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeQuestion5 : DecisionNode
{
    [SerializeField] private GameObject bedBlanket;
    [SerializeField] private GameObject axeFirstCross;
    private Animation bedBlanketAnimation;
    private Animation animationClips;
    public AnimationClip axeAlternativeIdle;
    public AnimationClip axeAlternativeCut;
    private void Start()
    {
        bedBlanketAnimation = bedBlanket.GetComponent<Animation>();
    }
    public override void initNode()
    {
        base.initNode();
    }
    public override void updateNode()
    {
        base.updateNode();
        if(PathActual == 0 && this.name == "AlternativeSphereFifthChoiceAndTakeAxe")
        {
            animationClips.Play("Axe Alternative Idle");
            animationClips.Stop("Axe Alternative Idle");
            animationClips.Play("Axe Alternative Cut");
            animationClips.Stop("Axe Alternative Cut");
        }
        if (PathActual == 1)
        {
            bedBlanketAnimation.Play("BedBlanketIdle");
            bedBlanketAnimation.Stop("BedBlanketIdle");
        }
    }
}
