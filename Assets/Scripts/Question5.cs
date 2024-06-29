using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question5 : DecisionNode
{
    public GameObject clouds;
    public GameObject rains;
    public GameObject gameOverPath1;
    public GameObject gameOverPath2;
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
    public override void endNode()
    {
        base.endNode();
        if(nameNode == "SphereStopSeeSea")
        {
            gameOverPath1.SetActive(true);
        }
        if(nameNode == "SphereFirstChoice")
        {
            gameOverPath2.SetActive(true);
        }
    }
}
