using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_sc : MonoBehaviour
{
    public keyCheck key;
    public AudioSource sound;
    public Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (key.unlocked == true)
        {
            animator.SetBool("Unlocked", true);
            key.unlocked = false;
            sound.Play();

        }
      
    }
    
}
