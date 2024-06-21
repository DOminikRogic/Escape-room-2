using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enter : MonoBehaviour
{
    public GameObject player;
    public GameObject numpad;
    public pad pad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!pad.look)
            {
                pad.look = true;
                Debug.Log("Look set to true");
                player.SetActive(false);
                numpad.SetActive(true);
            }
        }
    }
}
