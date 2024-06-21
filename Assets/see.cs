using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class see : MonoBehaviour
{
    public GameObject ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<ActionBasedController>().selectAction!=null)
        {
            ray.SetActive(true);
        }
        else
        {
            ray.SetActive(false);
        }
    }
}
