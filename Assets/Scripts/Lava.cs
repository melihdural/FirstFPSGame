using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if player hit to lava
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMenager>().Death();
        }
        
    }
}
