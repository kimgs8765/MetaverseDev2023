using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning_FadeOut : MonoBehaviour
{
    float time = 0.0f ; 
    public float fadeOutTime = 1.0f ;
    public float R;
    public float G;
    public float B;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject)
        {
            if (time < fadeOutTime)
            {
                GetComponent<SpriteRenderer>().color = new Color(R / 255f, G / 255f, B/255, 1 - time / fadeOutTime);
            }

            else
            {
                GetComponent<SpriteRenderer>().color = new Color(R/ 255f, G/255f, B/255f, 1);
                time = 0.0f ;
            }

            time += Time.deltaTime;

        }

        else  time = 0;   

    }


}
