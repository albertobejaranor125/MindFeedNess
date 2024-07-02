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
        animatorDog.enabled = true;
        animatorShoes.enabled = true;
    }
    public override void updateNode()
    {
        if (PathActual == -1 && Input.GetKey(KeyCode.LeftArrow))
        {
            question.SetActive(false);
            PathActual = 0;
            NodoActual = -1;
            animatorDog.SetTrigger("DogAwayPath1");
            dogs.GetComponent<AudioSource>().loop = false;
            dogs.GetComponent<AudioSource>().Stop();
            changeNode();
        }
        if (PathActual == -1 && Input.GetKey(KeyCode.RightArrow))
        {
            question.SetActive(false);
            PathActual = 1;
            NodoActual = -1;
            shoes.SetActive(true);
            changeNode();
        }
        if (PathActual != -1)
        {
            moveToNextPoint();
        }
        if(PathActual != -1 && animatorDog.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            moveToNextPoint();
        }
        if(PathActual == 1 && nameNode == "AlternativeSphereFourthChoiceAlternateFirstChangeDirection")
        {
            animatorShoes.SetTrigger("TakeShoes");
            shoes.transform.position = player.transform.position;
            shoes.transform.rotation = player.transform.rotation;
        }
        if(PathActual == 1 && nameNode == "AlternativeSphereFourthChoiceAlternateThirdChangeDirection")
        {
            animatorShoes.SetTrigger("ScareDogWithShoes");
            animatorDog.SetTrigger("DogAwayPath2");
            dogs.GetComponent<AudioSource>().loop = false;
            dogs.GetComponent<AudioSource>().Stop();
        }
    }
    /*IEnumerator waitAwayDog()
    {
        yield return new WaitForSeconds(10);
    }*/
}
