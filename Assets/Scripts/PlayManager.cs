using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class PlayManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform checkPoints;
    private Dictionary<Transform, List<List<Transform>>> allCheckpointsMap = new Dictionary<Transform, List<List<Transform>>>();
    Transform DecisionActual;
    int PathActual;
    int NodoActual;
    // Start is called before the first frame update
    void Start()
    {
        DecisionActual = checkPoints.GetComponent<Transform>();
        player.transform.position = DecisionActual.transform.position;

        PathActual = -1;
        NodoActual = -1;

        throughDecisionNode(DecisionActual);
    }

    void throughDecisionNode(Transform decisionNode) //decision Node = Nodo negro
    {
        //añadir decision node como clave de mi estructura
        allCheckpointsMap.Add(decisionNode, new List<List<Transform>>());
        
        //para cada Nodo hijo tipo "Path"        
        for (int i = 0; i < decisionNode.childCount; ++i)
        {
            
            List<Transform> path = throughPathNode(decisionNode.GetChild(i));
            if (path.Count > 0)
            {
                
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
    static float _tiempoPaseo = 10000;
    static Transform initi, end;
    void Update()
    {
        //deberias conocer (variable global) el nodo de decision actual y nodo transitorio actual
        if (PathActual == -1 && Input.GetKey(KeyCode.LeftArrow))
        {
            PathActual = 0;
            NodoActual = -1;//-1;
            _iniciorecorrido = DateTime.Now;
        }

        if (PathActual == -1 && Input.GetKey(KeyCode.RightArrow))
        {
            PathActual = 1;
            NodoActual = -1;//-1;
            _iniciorecorrido = DateTime.Now;
        }

        if (PathActual != -1)
        { 
            moveToNextPoint();
        }
    }

    private void moveToNextPoint()
    {
        List<Transform> path = allCheckpointsMap[DecisionActual][PathActual];
        float partialTime = _tiempoPaseo / path.Count;

        //Transform initi, end;
        if (NodoActual == -1) 
        {
            initi = DecisionActual;
            end = path[0];
        }
        else if(NodoActual <= path.Count)
        {
            initi = path[NodoActual];
            end = path[NodoActual+1];
        }
        
         
        float ratio = (float)(DateTime.Now - _iniciorecorrido).TotalMilliseconds / partialTime;
        Debug.Log(ratio);
        player.transform.position = Vector3.Lerp(initi.position, end.position, ratio);
        Vector3 initRotation = new Vector3(initi.rotation.x, initi.rotation.y, initi.rotation.z);
        Vector3 endRotation = new Vector3(end.rotation.x, end.rotation.y, end.rotation.z);
        //player.transform.rotation = Quaternion.FromToRotation(initRotation, endRotation);
        player.transform.rotation = Quaternion.Lerp(initi.rotation, end.rotation, ratio);
        //si ratio = 1 -> hay cambair caminoActual por CaminaoActual+
        if (ratio >= 1)
        {
            NodoActual++;
        }
        if (NodoActual == path.Count-1)
        {
            DecisionActual = path[NodoActual];
            PathActual = -1;
            NodoActual = -1;
        }
        
        //si estiy en el ultimo node de camino -> cambiar NodoActual por ese nuevo nodo de decision
    }

    
}
