using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move2NextScene : MonoBehaviour
{
    private float time = 0; 


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 5)
        {
            SceneManager.LoadScene("SImulation_Scene"); 
        }
    }
}
