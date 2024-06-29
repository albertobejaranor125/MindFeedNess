using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class PlayManager : MonoBehaviour
{
    public DecisionNode decisionNodeActual;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        DecisionNode mol = decisionNodeActual.processNode();
        if (mol != null)
        {
            decisionNodeActual = mol;
        }
    }
}
