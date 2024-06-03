using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class DecisionNode : MonoBehaviour
{
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
    protected Transform NodeDecision;
    public abstract bool processNode();
    public abstract void initNode();
    public abstract void updateNode();
    public abstract void endNode();
    static DateTime _lastCheckpoint;
    CheckPoint initi, end;
    int PathActual;
    int NodoActual;
    private GameObject player;
    private List<GameObject> allQuestions;
    private Dictionary<Transform, List<List<CheckPoint>>> allCheckpointsMap;
    Quaternion final;
    public void moveToNextPoint()
    {
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
        List<CheckPoint> path = allCheckpointsMap[NodeDecision][PathActual];
        if (NodoActual == -1)
        {
            initi.Nodo = NodeDecision;
            initi.Tiempo = 0;
            end = path[0];
        }
        else if (NodoActual < path.Count - 1)
        {
            initi = path[NodoActual];
            end = path[NodoActual + 1];
        }
        else if (NodoActual == path.Count - 1)
        {
            NodeDecision = path[NodoActual].Nodo;
            enableQuestion();
            PathActual = -1;
            NodoActual = -1;
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
    public void disableQuestion()
    {
        int i = 0;
        bool found = false;
        while (i < allQuestions.Count && !found)
        {
            if (NodeDecision.name.Equals(allQuestions[i].name))
            {
                allQuestions[i].SetActive(false);
                found = true;
            }
            i++;
        }
    }

    public void enableQuestion()
    {
        int i = 0;
        bool found = false;
        while (i < allQuestions.Count && !found)
        {
            if (NodeDecision.name.Equals(allQuestions[i].name))
            {
                allQuestions[i].SetActive(true);
                found = true;
            }
            i++;
        }
    }
}
