using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning_FadeIn : MonoBehaviour
{
    float time = 0.0f ; 
    public float fadeInTime = 4.0f ;
    public float R;
    public float G;
    public float B;

    private Image image; 

    void Start()
    {
        image = GetComponent<Image>();  //
        image.color = new Color(R / 255f, G / 255f, B / 255, 0);
    }

    void Update()
    {
        if (this.gameObject)
        {
            if (time < fadeInTime)
            {
                image.color = new Color(R / 255f, G / 255f, B/255, 0 + time / fadeInTime);
            }

            else
            {

            }

            time += Time.deltaTime;

        }

    }


}
