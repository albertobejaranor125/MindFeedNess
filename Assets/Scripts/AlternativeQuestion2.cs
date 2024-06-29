using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AlternativeQuestion2 : DecisionNode
{
    private Animator animatorEyes;
    public GameObject eyeBlink;
    [SerializeField] private AnimationClip eyesBlinking;
    //private bool isEndAnimation = false;
    protected override void Start()
    {
        base.Start();
        animatorEyes = eyeBlink.GetComponent<Animator>();
    }
    
    public override void updateNode()
    {
        
        if(PathActual == 1)
        {
            eyeBlink.SetActive(true);
            animatorEyes.Play("EyesBlinking");
            
        }
        base.updateNode();
    }
}
