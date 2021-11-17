using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHit : MonoBehaviour
{
    MeshRenderer renderer;
    CapsuleCollider collider;
    

int coinCounter = 0;

    public void OnCollisionEnter(Collision other) 
    {
       
        if(other.gameObject.tag == "Player")
        {
      
        
        renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;

        collider = GetComponent<CapsuleCollider>();
        collider.enabled = false;
        
        coinCounter = coinCounter + 1;
        Debug.Log("You have obtained a Coin! You have " + coinCounter + " coin(s).");
        
        
      
        }
        }
}
