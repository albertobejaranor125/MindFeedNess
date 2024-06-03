using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question2 : DecisionNode
{
    private Animation animationClips;
    public override void endNode()
    {
        animationClips.Stop("Umbrella Closed Idle");
        animationClips.Stop("Umbrella Opened Idle");
    }

    public override void initNode()
    {
        animationClips = GetComponent<Animation>();
        animationClips.Play("Umbrella Closed Idle");

    }

    public override bool processNode()
    {
        throw new System.NotImplementedException();
    }

    public override void updateNode()
    {
        animationClips.Play("Umbrella Opened Idle");
    }
}
