using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class Rocket : MonoBehaviour
{

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip bigBoom;
    [SerializeField] AudioClip winWin;


    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem bigBoomParticles;
    [SerializeField] ParticleSystem winWinParticles;
    Rigidbody rigidBody;
    AudioSource audioSource;

    enum State { 
        Alive, 
        Dying, 
        Trancending
    };
    State state = State.Alive;
    static int scene = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if( state == State.Alive){
            RespondToThrustInput();
            RespondToRotateInput();
        }
        
    }

    void OnCollisionEnter(Collision collision){
        if(state != State.Alive){
            return;
        }
        audioSource.Stop();
        
        switch(collision.gameObject.tag){
            case "Friendly":
                break;
            case "Finish":
                state = State.Trancending;
                audioSource.PlayOneShot(winWin);
                winWinParticles.Play();
                Invoke("LoadNextScene", 1f);
                break;
            default:
                state = State.Dying;
                audioSource.PlayOneShot(bigBoom);
                bigBoomParticles.Play();
                Invoke("LoadThisScene", 1f);
                break;
        }
    }

    private void LoadThisScene(){
        bigBoomParticles.Stop();
        SceneManager.LoadScene(scene);
    }

    private void LoadNextScene(){
        winWinParticles.Stop();
        SceneManager.LoadScene(++scene);
    }

    private void Thrust(){
        rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
    }

    private void RespondToThrustInput(){
        if(Input.GetKey(KeyCode.Space)){
            Thrust();
            if( !audioSource.isPlaying){
                audioSource.PlayOneShot(mainEngine);
            }
            mainEngineParticles.Play();
        }
        else{
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }

    private void RespondToRotateInput(){
        rigidBody.freezeRotation = true;

        float rotationThisFrame = rcsThrust * Time.deltaTime;
        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false;
    }
}
