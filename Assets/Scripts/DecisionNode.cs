using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public abstract class DecisionNode : MonoBehaviour
{
    protected struct CheckPoint
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
    private bool initialize = false;
    private bool isUpdate;
    protected DecisionNode lastCheckpoint;
    protected GameObject player;
    protected string nameNode;
    protected int PathActual;
    protected int NodoActual;
    public GameObject question;
    protected List<List<CheckPoint>> allCheckpoints = new List<List<CheckPoint>>();
    protected ScriptManager scriptManager;
    protected virtual void Start()
    {
        scriptManager = GameObject.Find("Canvas").GetComponent<ScriptManager>();
        player = GameObject.Find("Player");
        nameNode = null;
    }
    public DecisionNode processNode()
    {
        if(!initialize)
        {
            initialize = true;
            initNode();
            return null;
        }
        else if(!isUpdate)
        {
            updateNode();
            return null;
        }
        else
        {
            endNode();
            return lastCheckpoint;
        }
    }
    public virtual void initNode()
    {
        question.SetActive(true);
        player.transform.position = this.transform.position;
        PathActual = -1;
        NodoActual = -1;
        isUpdate = false;
        throughDecisionNode(this.transform);
        Debug.Log("Total Checkpoints: " + allCheckpoints.Count);
    }
    public virtual void updateNode()
    {
        if(PathActual == -1 && Input.GetKey(KeyCode.LeftArrow))
        {
            question.SetActive(false);
            PathActual = 0;
            NodoActual = -1;
            changeNode();
        }
        if(PathActual == -1 && Input.GetKey(KeyCode.RightArrow))
        {
            question.SetActive(false);
            PathActual = 1;
            NodoActual = -1;
            changeNode();
        }
        if(PathActual != -1)
        {
            moveToNextPoint();
        }
    }
    public virtual void endNode()
    {

    }
    static DateTime _lastCheckpoint;
    CheckPoint initi, end;
    static float velocidad = 5f;
    Quaternion final;
    void throughDecisionNode(Transform decisionNode) //decision Node = Nodo negro
    {
        Debug.Log("Name nodes: " + decisionNode.name);
        //para cada Nodo hijo tipo "Path"        
        for (int i = 0; i < decisionNode.childCount; ++i)
        {
            List<Transform> path = throughPathNode(decisionNode.GetChild(i));
            List<CheckPoint> checkPointList = new List<CheckPoint>();
            if (path.Count > 0)
            {
                //distancia en metros
                for (int j = 0; j < path.Count; j++)
                {
                    float distancia = (path[j].position - (j == 0 ? decisionNode.position : path[j - 1].position)).magnitude;
                    float tiempo = distancia / velocidad;
                    CheckPoint checkPointNew = new CheckPoint();
                    checkPointNew.Nodo = path[j];
                    checkPointNew.Tiempo = tiempo;
                    checkPointList.Add(checkPointNew);
                }
                allCheckpoints.Add(checkPointList); //añadir un camino
                                                                     //recursividad para los hijos de hijos
                //throughDecisionNode(path[path.Count - 1]);
            }
            else
            {
                allCheckpoints.Add(checkPointList); //añadir un camino
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
    public void moveToNextPoint()
    {
        if(initi.Nodo == null || end.Nodo == null)
        {
            return;
        }
        float ratio = (float)(DateTime.Now - _lastCheckpoint).TotalMilliseconds / (end.Tiempo * 1000);
        Debug.Log(ratio);
        player.transform.position = Vector3.Lerp(initi.Nodo.position, end.Nodo.position, ratio);
        //player.transform.rotation = final;
        //si ratio = 1 -> hay cambair caminoActual por CaminaoActual+
        if (ratio >= 1)
        {
            NodoActual++;
            changeNode();
        }
        //si estiy en el ultimo node de camino -> cambiar NodoActual por ese nuevo nodo de decision
    }
    public void changeNode()
    {
        List<CheckPoint> path = allCheckpoints[PathActual];
        Debug.Log("Actual Checkpoint: " + allCheckpoints[PathActual]);
        if(path == null || path.Count == 0)
        {
            Debug.Log("Path is null");
            return;
        }
        if(PathActual < 0 || PathActual >= allCheckpoints.Count)
        {
            Debug.Log("PathActual isn't in the index range");
            return;
        }
        if (NodoActual == -1)
        {
            initi.Nodo = this.transform;
            initi.Tiempo = 0;
            end = path[0];
            nameNode = initi.Nodo.name;
        }
        else if (NodoActual < path.Count - 1)
        {
            initi = path[NodoActual];
            end = path[NodoActual + 1];
            nameNode = initi.Nodo.name;
        }
        else if (NodoActual == path.Count - 1)
        {
            lastCheckpoint = path[NodoActual].Nodo.GetComponent<DecisionNode>();
            nameNode = path[NodoActual].Nodo.name;
            //enableQuestion();
            PathActual = -1;
            NodoActual = -1;
            isUpdate = true;
            /*if (!allCheckpointsMap.ContainsKey(NodeDecision))
            {
                isActive = false;
                gameOver();
            }*/
            return;
        }
        _lastCheckpoint = DateTime.Now;
        Vector3 haciaDondeMiroAhora = player.transform.forward;
        Vector3 haciaDondeQuieroMirar = (end.Nodo.position - initi.Nodo.position).normalized;
        final = Quaternion.FromToRotation(haciaDondeMiroAhora, haciaDondeQuieroMirar);
        player.transform.forward = haciaDondeQuieroMirar;
    } 
}
