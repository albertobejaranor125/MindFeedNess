using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question3 : DecisionNode
{
    private Animation animationClips;
    public override void endNode()
    {
        animationClips.Stop("axeSecondCrossIdle");
        animationClips.Stop("axeSecondCrossCut");
    }

    public override void initNode()
    {
        animationClips = animationClips.GetComponent<Animation>();
        animationClips.Play("axeSecondCrossIdle");
        
    }

    public override bool processNode()
    {
        throw new System.NotImplementedException();
    }

    public override void updateNode()
    {
        animationClips.Play("axeSecondCrossCut");
    }

   
}
