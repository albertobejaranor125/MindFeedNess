using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Question4 : DecisionNode
{
    public GameObject sheeps;
    public AnimationClip sheepIdle;
    public AudioClip angrySound;
    private Animator animatorSheep;
    private AudioSource audioSource;
    protected override void Start()
    {
        base.Start();
        animatorSheep = sheeps.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
        sheeps.GetComponent<AudioSource>().Play();
        sheeps.GetComponent<AudioSource>().loop = true;
    }
    public override void initNode()
    {
        base.initNode();
        sheeps.SetActive(true);
    }
    public override void updateNode()
    {
        base.updateNode();
        if(PathActual == 0)
        {
            animatorSheep.enabled = true;
            StartCoroutine(WaitSheeps());
            
            moveToNextPoint();
        }
        if (PathActual == 1)
        {
            audioSource.Play(0);
            animatorSheep.Play("SheepsIdle");
            //audioSource.Play("");
        }
    }
    private IEnumerator WaitSheeps()
    {
        yield return new WaitForSeconds(10);
        animatorSheep.Play("SheepsIdle");
    }
}
