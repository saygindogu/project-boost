using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscilator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;

    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;
        const float TAU = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(TAU * cycles);

        float movementFactor = rawSineWave;
        Vector3 movement = movementFactor * movementVector;
        transform.position = startingPos + movement;   
    }
}
