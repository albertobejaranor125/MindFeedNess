using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Question1 : DecisionNode
{
    public GameObject clouds;
    public GameObject rains;
    public GameObject umbrella;
    public override void updateNode()
    {
        if (PathActual == -1 && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            question.SetActive(false);
            PathActual = 0;
            NodoActual = -1;
            SaveExport.getInstance().AddData("N1: Energia; 'si'");
            changeNode();
        }
        if (PathActual == -1 && Input.GetKeyDown(KeyCode.RightArrow))
        {
            question.SetActive(false);
            PathActual = 1;
            NodoActual = -1;
            SaveExport.getInstance().AddData("N1: Energia; 'no'");
            changeNode();
        }
        if(PathActual != -1)
        {
            moveToNextPoint();
        }
        if(PathActual == 0)
        {
            clouds.SetActive(true);
            rains.SetActive(true);
            umbrella.SetActive(true);
        }
    }
    
}
