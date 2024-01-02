using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit_Game : MonoBehaviour
{
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            Application.Quit(); 
        }
    }
}
