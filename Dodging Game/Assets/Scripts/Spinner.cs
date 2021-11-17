using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{


    [SerializeField]float yRotation = 2f;
    [SerializeField]float xRotation = 0f;

    

    // Start is called before the first frame update
    void Start()
    {
     yRotation = yRotation * Time.deltaTime;
     xRotation = xRotation * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(xRotation, yRotation,0);
    
    }
}
