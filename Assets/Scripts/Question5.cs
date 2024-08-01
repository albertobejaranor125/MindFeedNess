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
        if(PathActual == -1 && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            question.SetActive(false);
            PathActual = 0;
            NodoActual = -1;
            
            SaveExport.getInstance().AddData("N5: Energia; 'si'");
            SaveExport.getInstance().AddData("N5: Fatiga; 'no'");
            changeNode();
        }
        if (PathActual == -1 && Input.GetKeyDown(KeyCode.RightArrow))
        {
            question.SetActive(false);
            PathActual = 1;
            NodoActual = -1;
            SaveExport.getInstance().AddData("N5: Energia; 'no'");
            SaveExport.getInstance().AddData("N5: Fatiga; 'si'");
            changeNode();
        }
        if(PathActual != -1)
        {
            moveToNextPoint();
        }
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
