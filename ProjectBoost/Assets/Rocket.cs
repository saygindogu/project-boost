using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Thrust(){
        if(Input.GetKey(KeyCode.Space)){
            rigidBody.AddRelativeForce(Vector3.up * 5);
            if( !audioSource.isPlaying){
                audioSource.Play();
            }
        }
        else{
            if(audioSource.isPlaying){
                audioSource.Stop();
            }
        }
    }

    private void Rotate(){
        rigidBody.freezeRotation = true;

        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.forward * Time.deltaTime * 50);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(-Vector3.forward * Time.deltaTime * 50);
        }

        rigidBody.freezeRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
        
    }
}
