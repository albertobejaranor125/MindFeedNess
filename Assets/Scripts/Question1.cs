using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Question1 : DecisionNode
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
        if (PathActual == 0)
        {
            clouds.SetActive(true);
            rains.SetActive(true);
        }
    }
    
}
