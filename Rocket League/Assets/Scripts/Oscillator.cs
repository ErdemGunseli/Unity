using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector; //The vector of the movement of the obstacle.
    [SerializeField] [Range(0,1)] float movementFactor;

    [SerializeField] float period = 5f; //The period of the wave.

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        const float tau = Mathf.PI*2; //The constant value 2PI.

        if (period <= Mathf.Epsilon){return;} //If the period is 0 or less, return from the function.
       
            float cycles = Time.time / period; //This is the number of cycles that has taken place and will continuously grow.
            float rawSinWave = Mathf.Sin(cycles * tau); //This will multiply the number of cycles with tau to get an angle and then get the sin of that angle, outputing a result between 1 and -1. This will continuously change.

            movementFactor = (rawSinWave + 1f) / 2f; //Altering the sin value to be between 0 and 1.

            Vector3 offset = movementVector * movementFactor; //This will apply the movementFactor to the movementVector, getting a value between 0 and movementVector.
            transform.position = startingPosition + offset; //This will apply the offset to the starting position.
        
    }
}
