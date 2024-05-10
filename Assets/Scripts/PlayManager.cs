using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayManager : MonoBehaviour
{
    public GameObject player;
    public GameObject checkPoints;
    
    private Dictionary<Transform, List<List<Transform>>> allCheckpointsMap = new Dictionary<Transform, List<List<Transform>>>();
    
    /*struct Value
    {
        List<GameObject> path1;
        List<GameObject> path2;
        List<GameObject> path3;
    }
    private Value[] allValues;*/
    // Start is called before the first frame update
    void Start()
    {
        

    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveToNextPoint();
        }
    }

    private void moveToNextPoint()
    {
        player.transform.position = Vector3.Lerp(allCheckpointsMap.Keys,,(float) DateTime.Now.Minute);
    }
}
