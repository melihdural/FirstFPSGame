using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask obstacle, player_layer;

    public GameObject death_effect;
    public float laser_multipler = 1f;

    private bool laser_hit;
    public float range = 100f;
    
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, obstacle))
        {
            GetComponent<LineRenderer>().enabled = true;
            laser_hit = true;

            GetComponent<LineRenderer>().SetPosition(0,transform.position);
            GetComponent<LineRenderer>().SetPosition(1,hit.point);

            GetComponent<LineRenderer>().startWidth = 0.025f * laser_multipler + Mathf.Sin(Time.time)/75;
            
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
            laser_hit = false;
        }

        //Kill Player
        if (Physics.Raycast(transform.position,transform.forward, out hit, range,player_layer))
        {
            if (laser_hit)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    if (hit.transform.gameObject.GetComponent<PlayerHealth>().currentHealth>0f)
                    {
                        hit.transform.gameObject.GetComponent<PlayerHealth>().currentHealth -= 5f;

                    }
                    else
                    {
                        hit.transform.gameObject.GetComponent<PlayerMenager>().Death();

                    }

                }

            }
        }
        
        
        
    }
}
