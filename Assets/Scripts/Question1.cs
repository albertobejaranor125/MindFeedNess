using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Question1 : DecisionNode
{
    private bool init = false;
    private bool update = false;
    private bool end = false;
    
    public override bool processNode()
    {
        if (!init)
        {
            init = true;
            initNode();
        }else if(!update)
        {
            update = true;
            updateNode();
        }
        else
        {
            end = true;
            endNode();
        }
        return end;
    }

    public override void endNode()
    {
        throw new System.NotImplementedException();
    }

    public override void initNode()
    {
        
        if(NodeDecision != null)
        {

        }
    }

    public override void updateNode()
    {
        throw new System.NotImplementedException();
    }

}
