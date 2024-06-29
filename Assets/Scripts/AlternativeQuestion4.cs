using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeQUestion4 : DecisionNode
{
    public GameObject dogs;
    public GameObject shoes;
    private Animator animatorDog;
    private Animator animatorShoes;
    protected override void Start()
    {
        base.Start();
        animatorDog = dogs.GetComponent<Animator>();
        animatorShoes = shoes.GetComponent<Animator>();
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
        if(PathActual == 1 && nameNode == "AlternativeSphereFourthChoiceAlternate")
        {
            shoes.SetActive(true);
        }
        if(PathActual == 1 && nameNode == "AlternativeSphereFourthChoiceAlternateFirstChangeDirection")
        {
            animatorShoes.Play("ShoesIdle");
            shoes.transform.position = player.transform.position;
            shoes.transform.rotation = player.transform.rotation;
        }
        if(PathActual == 1 && nameNode == "AlternativeSphereFourthChoiceAlternateThirdChangeDirection")
        {
            animatorShoes.Play("ShoesBoomerang");
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
