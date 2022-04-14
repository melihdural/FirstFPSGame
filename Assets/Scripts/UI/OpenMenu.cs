using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
    public GameObject open_menu, close_menu;

   public void Open()
    {
        open_menu.SetActive(true);
        close_menu.SetActive(false);
    }
    
} 
