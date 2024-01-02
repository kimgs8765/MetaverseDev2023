using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_Move : MonoBehaviour
{
    [SerializeField] GameObject delete; 

    float speed = 6.0f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, delete.transform.position, Time.deltaTime * speed ); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == delete.GetComponent<Collider>() || other.tag == "Car") 
        {
            Debug.Log("µé¾î¿È");
            Destroy(gameObject); 
        }
    }
}
