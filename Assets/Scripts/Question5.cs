using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question5 : DecisionNode
{
    public GameObject clouds;
    public GameObject rains;

    protected override void Start()
    {
        base.Start();
    }
    public override void updateNode()
    {
        base.updateNode();
        if(PathActual == 0)
        {
            clouds.SetActive(false);
            rains.SetActive(false);
        }
    }
}
