using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterLevel : MonoBehaviour
{
   public LevelMenager lm;
   public bool enter;

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         if (enter)
         {
            lm.player_enter = true;

         }
         else
         {
            lm.player_enter = false;
         }
      }
   }
}
