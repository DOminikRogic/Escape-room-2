using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UIElements;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.XR;


public class menues : MonoBehaviour
{
    
    public GameObject Main;
    public GameObject loss;
    public GameObject WIn;
    public GameObject opt;
    public GameObject vropt;
    public GameObject Pau;
    public GameObject play;
    public GameObject music;
    public GameObject end;
    public GameObject Sub;
    public GameObject VRMain;
    public GameObject VRMainpl;
    public GameObject endVR;
    public GameObject move;
    public GameObject rot;
    public GameObject ray;
    public GameObject handmenu;
    public GameObject handop;
    public Player_sc pl;
    public GameObject vrtext;
    public TMP_Text vrtextvr;
    public TMP_Text vrsnap;
    public TMP_Text gamevrtext;
    public TMP_Text gamesnap;
    public GameObject XROrigin;
    public bool fromMain=true;
    public bool IsVR=false;
    public bool lookVR = false;
    public bool pressed = false;
    public bool snap = false;
    public bool looksnap = false;
    public bool inoptions = false;
   

    private void Update()
    {
        if (!IsVR)
        {
            endVR.SetActive(false);
        }
        else
        {
            endVR.SetActive(true);
        }
    }
    public void Start()
    {
        string fileloc = @"SaveFile.txt";

        // Check if the file exists before attempting to read from it
        if (File.Exists(fileloc))
        {
            using (StreamReader read = new StreamReader(fileloc))
            {
                string line;
                int lineNumber = 0;
                while ((line = read.ReadLine()) != null && lineNumber < 3) // Assuming 2 properties
                {
                    if (lineNumber == 0)
                    {
                        if (float.TryParse(line, out float floatValue))
                            pl.Sens.value = floatValue;
                        else
                            Debug.LogError($"Error parsing Sens value on line {lineNumber + 1}");
                    }
                    else if (lineNumber == 1)
                    {
                        if (bool.TryParse(line, out bool boolValue))
                            IsVR = boolValue;
                        else
                            Debug.LogError($"Error parsing isVR value on line {lineNumber + 1}");
                    }
                    else if (lineNumber == 2)
                    {
                        if (bool.TryParse(line, out bool boolValue))
                            snap = boolValue;
                        else
                            Debug.LogError($"Error parsing snap value on line {lineNumber + 1}");
                    }
                    lineNumber++;
                }
            }
        }
        else
        {
            Debug.LogError("File not found: " + fileloc);
        }

        if (IsVR)
        {
            lookVR = true;
        }

        if (snap)
        {
            looksnap = true;
        }

        if (snap)
        {
            move.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
            move.GetComponent<TeleportationProvider>().enabled = true;
            rot.GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
            rot.GetComponent<ActionBasedSnapTurnProvider>().enabled = true;
        }
        else
        {
            move.GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
            move.GetComponent<TeleportationProvider>().enabled = false;
            rot.GetComponent<ActionBasedContinuousTurnProvider>().enabled = true;
            rot.GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
        }
        fromMain = true;
        if (!IsVR)
        {
            end.SetActive(true);
            Main.SetActive(true);
            VRMain.SetActive(false);
            VRMainpl.SetActive(false);
        }
        else
        {
            Main.SetActive(false);
            VRMain.SetActive(true);
            VRMainpl.SetActive(true);
            end.SetActive(false);
        }
}
    public void MainMenu()
    {
         
        SceneManager.LoadScene("SampleScene");
        
        
        fromMain= true;
        
    }
    public void Quit()
    {
        Application.Quit();
        Quit();
    }
    public void NewGame()
    {
        if (fromMain)
        {
            if (!IsVR)
            {
                play.SetActive(true);
                XROrigin.SetActive(false);
            }
            else
            {
                VRMain.SetActive(false);
                VRMainpl.SetActive(false);
                XROrigin.SetActive(true);
            }
        }
        Main.SetActive(false);

        if (!snap)
        {
            ray.SetActive(false);
        }
        else
        {
            ray.SetActive (true);
        }
        music.SetActive(true);
        end.SetActive(false);
        fromMain = false;
    }
    public void Options()
    {
        inoptions = true;
        if (IsVR)
        {
            vrtext.GetComponentInChildren<Text>().text = "VR";
        }
        else
        {
            vrtext.GetComponentInChildren<Text>().text = "NO VR";
        }
        if (looksnap)
        {

            vrsnap.SetText("Snaping motion");
        }
        else
        {

            vrsnap.SetText("Continues motion");
        }

        if (!IsVR)
        {
            if (fromMain)
            {
                Main.SetActive(false);
                opt.SetActive(true);
            }
            else
            {
                Pau.SetActive(false);
                opt.SetActive(true);
            }
        }
        else
        {
            if (fromMain)
            {
                VRMain.SetActive(false);
                vropt.SetActive(true);
            }
            
            {
                handmenu.SetActive(false);
                handop.SetActive(true);
            }
        }
       

    }
    public void submit()
    {
        inoptions = false;
        if (looksnap)
        {
            snap = true;
        }
        else
        {
            snap = false;
        }
        if (lookVR)
        {
            IsVR = true;
        }
        else
        {
            IsVR = false;
        }
        
        if (!fromMain)
        {
            if (!IsVR)
            {
                play.SetActive(true);
                XROrigin.SetActive(false);
            }
            else
            {
                play.SetActive(false);
                XROrigin.SetActive(true);
            }
        }
       
        using (StreamWriter writer = new StreamWriter("SaveFile.txt"))
        {
            writer.Write(pl.Sens.value.ToString()+"\n");
            writer.Write(IsVR + "\n");
            writer.Write(snap + "\n");
        }
        if (IsVR)
        {
            if (fromMain)
            {
                end.SetActive(false);
                VRMainpl.SetActive(true);
                VRMain.SetActive(true);
                opt.SetActive(false);
                fromMain = true;
                vropt.SetActive(false);
            }
            else
            {
                handmenu.SetActive(true);
                handop.SetActive(false);
                fromMain = false;
                if (pl.see == false)
                {
                    GetComponent<Crosshair>().enabled = false;
                    pl.ui.SetActive(true);
                    pl.see = true;
                    UnityEngine.Cursor.lockState = CursorLockMode.None;


                }
                else if (pl.see == true)
                {
                    GetComponent<Crosshair>().enabled = true;
                    pl.ui.SetActive(false);
                    pl.see = false;
                    UnityEngine.Cursor.lockState = CursorLockMode.Locked;


                }
            }
        }
        else
        {
            if (fromMain)
            {
                VRMainpl.SetActive(false);
                VRMain.SetActive(false);
                end.SetActive(true);
                Main.SetActive(true);
                opt.SetActive(false);
                vropt.SetActive(false);
                fromMain = true;
            }
            else
            {
                Pau.SetActive(true);
                opt.SetActive(false);
                fromMain = false;
            }


        }
        if (snap)
        {
            move.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false ;
            move.GetComponent<TeleportationProvider>().enabled = true;
            rot.GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
            rot.GetComponent<ActionBasedSnapTurnProvider>().enabled = true;
        }
        else
        {
            move.GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
            move.GetComponent<TeleportationProvider>().enabled = false;
            rot.GetComponent<ActionBasedContinuousTurnProvider>().enabled = true;
            rot.GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
        }

        if (!snap)
        {
            ray.SetActive(false);
        }
        else
        {
            ray.SetActive(true);
        }
    }
    public void Save()
    {
        // Use StreamWriter to write to the file
        
    }
    public void VR()
    {
        lookVR = !lookVR;
        
        if (IsVR)
        {
            if (fromMain)
            {
                if (lookVR)
                {

                    vrtextvr.SetText("VR");
                }
                else
                {

                    vrtextvr.SetText("NO VR");
                }
            }
            else
            {
                if (lookVR)
                {

                    gamevrtext.SetText("VR");
                }
                else
                {

                    gamevrtext.SetText("NO VR");
                }
            }
        }
        else
        {
            if (lookVR)
            {
                vrtext.GetComponentInChildren<Text>().text = "VR";
               
            }
            else
            {
                vrtext.GetComponentInChildren<Text>().text = "NO VR";
               
            }
        }
    }

    public void Snap()
    {
        looksnap = !looksnap;

        if (fromMain)
        {
            if (looksnap)
            {

                vrsnap.SetText("Snaping motion");
            }
            else
            {

                vrsnap.SetText("Continues motion");
            }
        }
        else
        {
            if (looksnap)
            {

                gamesnap.SetText("Snaping motion");
            }
            else
            {

                gamesnap.SetText("Continues motion");
            }
        }
    }
}
