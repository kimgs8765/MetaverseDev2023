using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixed_Camera : MonoBehaviour
{
    [SerializeField] GameObject scooter;
    private Vector3 pos; 

    private void Start()
    {
        pos = gameObject.transform.position;  
    }
    // Update is called once per frame
    void Update()
    {
        if (scooter.activeSelf)
        {
            gameObject.transform.position = new Vector3(scooter.transform.position.x, pos.y, scooter.transform.position.z);
            gameObject.transform.rotation = scooter.transform.rotation; 
        }

        else
        {
            gameObject.transform.position = pos; 
        }
    }

}
