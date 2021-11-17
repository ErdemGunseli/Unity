using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
int bumpCounter = 0;

    public void OnCollisionEnter(Collision other) 
    {
       if(other.gameObject.tag != "Hit")
        {
       bumpCounter++;
        Debug.Log("Bump Count: " + bumpCounter);
        }
    }
}
