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
    [SerializeField] private GameObject player;
    [SerializeField] private Transform checkPoints;
    struct CheckPoint
    {
        Transform node;
        float time;
        public Transform Nodo
        {
            get
            {
                return node;
            }
            set
            {
                node = value;
            }
        }
        public float Tiempo
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
    }
    private Dictionary<Transform, List<List<CheckPoint>>> allCheckpointsMap = new Dictionary<Transform, List<List<CheckPoint>>>();
    Transform DecisionActual;
    int PathActual;
    int NodoActual;
    static float velocidad = 5f;
    //List<CheckPoint> checkPointList = new List<CheckPoint>();
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
        //a�adir decision node como clave de mi estructura
        allCheckpointsMap.Add(decisionNode, new List<List<CheckPoint>>());
        //List<CheckPoint> checkPointList = new List<CheckPoint>();
        //para cada Nodo hijo tipo "Path"        
        for (int i = 0; i < decisionNode.childCount; ++i)
        {
            
            List<Transform> path = throughPathNode(decisionNode.GetChild(i));
            List<CheckPoint> checkPointList = new List<CheckPoint>();
            if (path.Count > 0)
            {
                //distancia en metros
                /*float distancia = (path[i].position - decisionNode.position).magnitude;
                float tiempo = distancia / velocidad;
                CheckPoint checkPointNew = new CheckPoint();
                checkPointNew.Nodo = path[i];
                checkPointNew.Tiempo = tiempo;*/
                for(int j = 0; j < path.Count; j++)
                {
                    float distancia = (path[j].position - (j == 0 ? decisionNode.position : path[j - 1].position)).magnitude;
                    float tiempo = distancia / velocidad;
                    CheckPoint checkPointNew = new CheckPoint();
                    checkPointNew.Nodo = path[j];
                    checkPointNew.Tiempo = tiempo;
                    checkPointList.Add(checkPointNew);
                }
                
                //checkPointList.Add(checkPointNew);
                allCheckpointsMap[decisionNode].Add(checkPointList); //a�adir un camino
                                                           //recursividad para los hijos de hijos
                throughDecisionNode(path[path.Count - 1]);
            }
            else
            {
                allCheckpointsMap[decisionNode].Add(checkPointList); //a�adir un camino
            }
        }
    }

    List<Transform> throughPathNode(Transform pathNode) //path Node = Nodo negro
    {
        List<Transform> path = new List<Transform>();
        for (int i = 0; i < pathNode.childCount; ++i)
        {
            //a�adir cada nodo en mi lista
            path.Add(pathNode.GetChild(i).transform);
        }
        return path;
    }

    // Update is called once per frame
    static DateTime _lastCheckpoint;
    CheckPoint initi, end;
    void Update()
    {
        //deberias conocer (variable global) el nodo de decision actual y nodo transitorio actual
        if (PathActual == -1 && Input.GetKey(KeyCode.LeftArrow))
        {
            PathActual = 0;
            NodoActual = -1;//-1;
            _lastCheckpoint = DateTime.Now;
        }

        if (PathActual == -1 && Input.GetKey(KeyCode.RightArrow))
        {
            PathActual = 1;
            NodoActual = -1;//-1;
            _lastCheckpoint = DateTime.Now;
        }

        if (PathActual != -1)
        { 
            moveToNextPoint();
        }
    }

    private void moveToNextPoint()
    {
        List<CheckPoint> path = allCheckpointsMap[DecisionActual][PathActual];
        if (NodoActual == -1) 
        {
            initi.Nodo = DecisionActual;
            initi.Tiempo = 0;
            end = path[0];
        }
        else if(NodoActual < path.Count)
        {
            initi = path[NodoActual];
            end = path[NodoActual+1];
        }
 
        float ratio = (float)(DateTime.Now - _lastCheckpoint).TotalMilliseconds / (end.Tiempo*1000);
        Debug.Log(ratio);
        player.transform.position = Vector3.Lerp(initi.Nodo.position, end.Nodo.position, ratio);
        Vector3 haciaDondeMiroAhora = player.transform.forward;
        Vector3 haciaDondeQuieroMirar = (end.Nodo.position - initi.Nodo.position).normalized;
        Quaternion final = Quaternion.FromToRotation(haciaDondeMiroAhora, haciaDondeQuieroMirar);
        player.transform.rotation = final;
        //si ratio = 1 -> hay cambair caminoActual por CaminaoActual+
        if (ratio >= 1)
        {
            NodoActual++;
            _lastCheckpoint = DateTime.Now;
        }
        if (NodoActual == path.Count-1)
        {
            DecisionActual = path[NodoActual].Nodo;
            PathActual = -1;
            NodoActual = -1;
        }
        
        //si estiy en el ultimo node de camino -> cambiar NodoActual por ese nuevo nodo de decision
    }

    
}
