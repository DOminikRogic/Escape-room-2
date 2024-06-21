using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public pad unlocked;
    public Animator animator;
    public bool moveing = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    IEnumerator move()
    {
        while (moveing == true)
        {
            yield return new WaitForSeconds(3f);
            
            animator.SetBool("unlocked", true);
            moveing = false;
        }
    }
    void Update()
    {

        if (moveing == true)
        {

            StartCoroutine(move());


        }
            
           


       

    }

}
