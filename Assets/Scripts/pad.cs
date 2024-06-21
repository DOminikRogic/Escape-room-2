
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Newtonsoft.Json.Bson;

public class pad : MonoBehaviour
{
    public int broj = 1;
    public GameObject player;
    public GameObject numpad;
    public bool look = false;
    int pass = 0;
    bool prvi = true;
    public TMP_Text Text;
    public bool unlocked = false;
    public Animator animator;
    public string inputString;
    public bool flicker = false;
    public Wall moveing;
    public bool pressed = false;
    public menues me;
    public GameObject[] num;
    public KeyCode[] keycodes = { KeyCode.Keypad0, KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3, KeyCode.Keypad4, KeyCode.Keypad5, KeyCode.Keypad6, KeyCode.Keypad7, KeyCode.Keypad8, KeyCode.Keypad9 };
    public KeyCode[] numcodes = { KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };

    void Start()
    {
        prvi = true;
    }
   
    IEnumerator colorFlick()
    {
        while (flicker)
        {
            Text.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            Text.color = Color.white;
            yield return new WaitForSeconds(0.5f);
            flicker = false;
        }
    }
    void Update()
    {
        if (unlocked)
        {
            animator.SetBool("Unlocked", true);
        }
        else
        {
            if (flicker)
            {
                StartCoroutine(colorFlick());
            }
            if (!me.IsVR)
            {
                if (look)
                {

                    for (int i = 0; i < keycodes.Length; i++)
                    {
                        if (pass.ToString().Length < 4 && (Input.GetKeyUp(keycodes[i]) || Input.GetKeyUp(numcodes[i])))
                        {



                            broj = i;
                            string objectName = "num" + i;
                            num[i] = GameObject.Find(objectName);

                            pressed = true;




                            //StartCoroutine(press());

                            Debug.Log(num[i]);
                            Debug.Log(broj);
                            Debug.Log(pass);

                            if (prvi)
                            {
                                pass = broj;
                                prvi = false;
                            }
                            else
                            {
                                pass = pass * 10 + broj;
                            }



                            Text.text = pass.ToString();




                        }


                    }

                    if (Input.GetKeyUp(KeyCode.Return))
                    {


                        pressed = true;

                        if (pass == 8367)
                        {
                            unlocked = true;
                            moveing.moveing = true;
                            look = false;
                            player.SetActive(true);
                            numpad.SetActive(false);
                        }
                        else
                        {
                            flicker = true;
                        }
                        Text.text = pass.ToString();

                    }

                    if (Input.GetKeyUp(KeyCode.Backspace))
                    {


                        pressed = true;

                        if (pass != 0)
                        {
                            pass = pass / 10;
                        }
                        else
                        {
                            look = false;
                            player.SetActive(true);
                            numpad.SetActive(false);
                        }
                        Text.text = pass.ToString();
                    }
                }
            }        

        }

    }
 
    public void press(int broj) 
    {
        
           

        
        
        if (pass.ToString().Length < 4 && broj <= 9)
        {

            Debug.Log(broj);
            Debug.Log(pass);

            if (prvi)
            {
                pass = broj;
                prvi = false;
            }
            else
            {
                pass = pass * 10 + broj;
            }



            Text.text = pass.ToString();

        }

        if (broj == 10)
        {


            pressed = true;

            if (pass == 8367)
            {
                unlocked = true;
                moveing.moveing = true;
                look = false;
                player.SetActive(true);
                numpad.SetActive(false);
            }
            else
            {
                flicker = true;
            }
            Text.text = pass.ToString();

        }

        if (broj== 11)
        {


            if (pass != 0)
            {
                pass = pass / 10;
            }
            else
            {
                player.SetActive(true);
                numpad.SetActive(false);
            }
            Text.text = pass.ToString();
        }
        
    }
    

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!look)
            {
                look = true;
                Debug.Log("Look set to true");
                player.SetActive(false);
                numpad.SetActive(true);
            }
        }
    }
}

