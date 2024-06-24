using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeQUestion4 : DecisionNode
{
    public GameObject dogs;
    private Animator animatorDog;
    protected override void Start()
    {
        base.Start();
        animatorDog = dogs.GetComponent<Animator>();
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
            StartCoroutine(waitAwayDog());
            animatorDog.Play("DogIdle");
            dogs.GetComponent<AudioSource>().loop = false;
            dogs.GetComponent<AudioSource>().Stop();
        }
        if(PathActual == 1 && nameNode == "AlternativeSphereFourthChoiceAlternateThirdChangeDirection")
        {
            animatorDog.Play("DogIdle");
            dogs.GetComponent<AudioSource>().loop = false;
            dogs.GetComponent<AudioSource>().Stop();
        }
    }
    IEnumerator waitAwayDog()
    {
        yield return new WaitForSeconds(10);
    }
}
