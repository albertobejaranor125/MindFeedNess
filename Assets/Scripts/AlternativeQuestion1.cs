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
        base.updateNode();
        SaveExport.getInstance().AddData("AN1: Energía; 'no'");
    }
}
