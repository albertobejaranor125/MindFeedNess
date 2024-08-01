using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeQuestion1 : DecisionNode
{
    protected override void Start()
    {
        base.Start();
    }
    public override void updateNode()
    {
        if(PathActual == -1 && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            question.SetActive(false);
            PathActual = 0;
            NodoActual = -1;
            SaveExport.getInstance().AddData("AN1: Energia; 'no'");
            changeNode();
        }
        if(PathActual != -1)
        {
            moveToNextPoint();
        }
    }
}
