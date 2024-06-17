using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question5 : DecisionNode
{
    [SerializeField] private GameObject clouds;
    [SerializeField] private GameObject rains;
    public override void initNode()
    {
        base.initNode();
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
