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
            SaveExport.getInstance().AddData("N5: Energía; 'sí'");
            SaveExport.getInstance().AddData("N5: Fatiga; 'no'");
        }
        if (PathActual == 1)
        {
            SaveExport.getInstance().AddData("N5: Energía; 'no'");
            SaveExport.getInstance().AddData("N5: Fatiga; 'sí'");
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
