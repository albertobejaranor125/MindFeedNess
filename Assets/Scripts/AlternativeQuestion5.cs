using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeQuestion5 : DecisionNode
{
    private Animation animationClips;
    public override void endNode()
    {
        animationClips.Stop("Axe Alternative Idle");
        animationClips.Stop("Axe Alternative Cut");
    }

    public override void initNode()
    {
        animationClips = GetComponent<Animation>();
        animationClips.Play("Axe Alternative Idle");
    }

    public override bool processNode()
    {
        throw new System.NotImplementedException();
    }

    public override void updateNode()
    {
        animationClips.Play("Axe Alternative Cut");
    }
}
