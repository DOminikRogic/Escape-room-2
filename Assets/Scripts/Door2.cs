using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    public AudioSource sound;
    public keyCheck1 key;
    public Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (key.unlocked == true)
        {
            animator.SetBool("Unlocked2", true);
            key.unlocked = false;
            sound.Play();

        }

    }

}
