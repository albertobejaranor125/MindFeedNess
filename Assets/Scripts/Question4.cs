using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Question4 : DecisionNode
{
    [SerializeField] private GameObject sheeps;
    public AnimationClip sheepIdle;
    public AudioClip angrySound;
    private Animator animatorSheep;
    private AudioSource audioSource;
    private void Start()
    {
        animatorSheep = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        sheeps = GetComponent<GameObject>();
        sheeps.GetComponent<AudioSource>().Play();
        sheeps.GetComponent<AudioSource>().loop = true;
    }
    public override void initNode()
    {
        base.initNode();
    }
    public override void updateNode()
    {
        base.updateNode();
        if(PathActual == 0)
        {
            //Thread.Sleep(10000);

        }
        if (PathActual == 1)
        {
            audioSource.Play(0);
            animatorSheep.Play("SheepsIdle");
            //audioSource.Play("");
        }
    }
}
