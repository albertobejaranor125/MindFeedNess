using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform checkPoints;
    private Dictionary<Transform, List<List<Transform>>> allCheckpointsMap = new Dictionary<Transform, List<List<Transform>>>();
    static Transform NodoActual;
    static int PathActual;
    static int NodosTotales = 0;
    static int PathTotales = 0;
    // Start is called before the first frame update
    void Start()
    {
        throughDecisionNode(checkPoints.GetComponent<Transform>());
    }

    void throughDecisionNode(Transform decisionNode) //decision Node = Nodo negro
    {
        //añadir decision node como clave de mi estructura
        allCheckpointsMap.Add(decisionNode, new List<List<Transform>>());
        NodosTotales++;
        //para cada Nodo hijo tipo "Path"        
        for (int i = 0; i < decisionNode.childCount; ++i)
        {
            
            List<Transform> path = throughPathNode(decisionNode.GetChild(i));
            if (path.Count > 0)
            {
                PathTotales += path.Count;
                allCheckpointsMap[decisionNode].Add(path); //añadir un camino
                                                           //recursividad para los hijos de hijos
                throughDecisionNode(path[path.Count - 1]);
            }
            else
            {
                allCheckpointsMap[decisionNode].Add(path);
            }
        }
    }

    List<Transform> throughPathNode(Transform pathNode) //path Node = Nodo negro
    {
        List<Transform> path = new List<Transform>();
        for (int i = 0; i < pathNode.childCount; ++i)
        {
            //añadir cada nodo en mi lista
            path.Add(pathNode.GetChild(i).transform);
        }
        return path;
    }

    // Update is called once per frame
    static DateTime _iniciorecorrido;
    static float _tiempoPaseo = 1000;
    
    void Update()
    {
        //deberias conocer (variable global) el nodo de decision actual y nodo transitorio actual

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _iniciorecorrido = DateTime.Now;

            moveToNextPoint();
        }
    }

    private void moveToNextPoint()
    {
        PathActual = 0;
        List<Transform> path = allCheckpointsMap[NodoActual][PathActual];
        float partialTime = _tiempoPaseo / path.Count;
        Transform init = path[PathActual];
        Transform end = path[PathActual + 1];
        float ratio = (float)(DateTime.Now - _iniciorecorrido).TotalMilliseconds / partialTime;
        player.transform.position = Vector3.Lerp(init.position, end.position, ratio);
        //si ratio = 1 -> hay cambair caminoActual por CaminaoActual+
        if (ratio == 1)
        {
            path = allCheckpointsMap[NodoActual][PathActual + 1];
        }
        else if (path.Count == 0)
        {
            PathActual++;
            
            path = allCheckpointsMap[NodoActual][PathActual];
        }
        //si estiy en el ultimo node de camino -> cambiar NodoActual por ese nuevo nodo de decision
    }
}
