using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeQuestion3 : DecisionNode
{
    [SerializeField] private GameObject bedBlanket;
    private Animation bedBlanketAnimation;
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
        if(PathActual == 1)
        {
            bedBlanketAnimation.Play("BedBlanketIdle");
            bedBlanketAnimation.Stop("BedBlanketIdle");
        }
    }
}
