using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Question1 : DecisionNode
{
    public GameObject clouds;
    public GameObject rains;
    
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
