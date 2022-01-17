using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon){ return ;}
        float cycles = Time.time/period;    // continually growing overtime
        const float tau = Mathf.PI*2;       // constant value of 6.283
        float rawSineWave = Mathf.Sin(cycles*tau);      // range of -1 to 1

        movementFactor = (rawSineWave + 1f)/2f;     // results in a range between 0 and 1
        
        Vector3 offset = movementVector*movementFactor;     
        transform.position = startingPosition + offset;
    }
}
