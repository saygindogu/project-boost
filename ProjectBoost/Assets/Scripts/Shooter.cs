using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject enemy;
    [SerializeField] float period = 2f;


    float time_counter = 0.0f;

    void Start()
    {

    }


    private void Shoot()
    {
        print(transform);
        (enemy.GetComponent("Bullet") as Bullet).enabled = true;
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        time_counter += Time.deltaTime;
        print(time_counter);
        if( time_counter >= period){
            time_counter = 0.0f;
            Shoot();
        }
    }
}
