using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
     [SerializeField]float moveSpeed = 4.5f;
     [SerializeField]float timeBeforePlayerCanMove = 3;



    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {
       MovePlayer();
    }

    void PrintInstructions() 
{
    Debug.Log("Welcome to the Game!");
    Debug.Log("To move the character, use WASD or the arrow keys.");
    Debug.Log("Dodge the obstacles and reach the end to win.");
}


 void MovePlayer()
 {
     if(Time.time > timeBeforePlayerCanMove)
     {
        float xValue = moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float zValue = moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(xValue,0,zValue);
     }
}


    
}
