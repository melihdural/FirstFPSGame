using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Drone : MonoBehaviour
{
    private Transform player;

    public float speed = 1f;
    public float follow_distance = 10f;

    private float coolDown = 2f;

    public GameObject mesh;
    public GameObject bullet;

    public float health = 100f;

    public GameObject death_effect;

    public AudioClip death_sound;
    


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        FollowPlayer();
        Shot();
        Death();
    }

    private void FollowPlayer()
    {
        //Look to Player
        transform.LookAt(player.position);
        transform.rotation *= Quaternion.Euler(new Vector3(-90, 0, 0));

        //Move to Player
        if (Vector3.Distance(transform.position, player.position) >= follow_distance)
        {
            transform.Translate(transform.forward * Time.deltaTime * speed * -1);
            
        }
        else
        {
            transform.RotateAround(player.position, transform.forward, Time.deltaTime * speed * Random.Range(0.2f, 3f));
            transform.Translate(transform.forward * Time.deltaTime);
            
        }


    }

    private void Shot()
    {


        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }

        else
        {
            coolDown = 2f;
            //Shot
            mesh.GetComponent<Animator>().SetTrigger("shot");
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(new Vector3(-90, 0, 0)));

        }

       

    }

    private void Death()
    {
        if (health <= 0)
        {
            //Spawn Particle
            Instantiate(death_effect, transform.position, Quaternion.identity); 
                
            //Play Sound Effect
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(death_sound);
            
            //Destroy
            Destroy(this.gameObject);
        }
        
        
    }

    

   
    
   
}
