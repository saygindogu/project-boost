using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Bullet : MonoBehaviour
{

    [SerializeField] Vector3 movementVector;
    [SerializeField] float speed;

    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position; 
        print(startingPos);    
    }

    // Update is called once per frame
    void Update()
    {
        float movementThisFrame = speed * Time.deltaTime;
        Vector3 movement =  movementThisFrame * movementVector;
        transform.position = startingPos + movement;
        startingPos = transform.position;
        if(startingPos.y < -10f){
            Destroy(gameObject); 
        }   
    }
}
