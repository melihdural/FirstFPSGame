using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public float lifeTime = 5f;

    public bool enemy_bullet = false;
    public float bullet_radius = 0.5f;
    public LayerMask player_layer;

    public GameObject hit_effect;

    public AudioClip hit_sound;

   


    private void Update()
    {
        transform.Translate(Vector3.forward * -1 * Time.deltaTime * speed);

        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
        
        //Enemy Bullet
       /* if (enemy_bullet)
        {
            
            if (Physics.CheckSphere(transform.position, bullet_radius, player_layer))
            {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMenager>().Death();
                
            }  
       
        }
       */ 
    }

    private void OnTriggerEnter(Collider other)
    {
        //Hit Enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            GameObject drone = other.transform.parent.gameObject;
            drone.GetComponent<Drone>().health -= 10f;
            drone.GetComponent<AudioSource>().PlayOneShot(hit_sound);

           
        }
        
        //Hit Effect
       Instantiate(hit_effect, transform.position, transform.rotation);
       Destroy(this.gameObject);
        
       
    }

   
    
}
