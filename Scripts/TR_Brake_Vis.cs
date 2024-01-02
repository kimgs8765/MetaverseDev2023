using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TR_Brake_Vis : MonoBehaviour
{
    public bool brake_Input;
    Vector3 curr_rot;

    // Start is called before the first frame update
    void Start()
    {
        curr_rot = transform.localEulerAngles;
        Debug.Log("Y ����" + curr_rot.y);
    }

    // Update is called once per frame    void Update()
    void Update()
    {

        float prev_rot = (transform.localEulerAngles.y > 180) ? transform.localEulerAngles.y - 360 : transform.localEulerAngles.y;


        if (brake_Input == true & curr_rot.y - 20.0f < prev_rot)
        {
            Debug.Log("���簢��" + prev_rot);

            float y_change = Mathf.Lerp(Mathf.Abs(prev_rot), 10, 0.5f);
            transform.Rotate(0, -y_change, 0);
        }


        else if (brake_Input == false & curr_rot.y > prev_rot)
        {
            float y_change = Mathf.Lerp(0, Mathf.Abs(prev_rot), 0.5f);
            transform.Rotate(0, y_change, 0);

        }
    }
}