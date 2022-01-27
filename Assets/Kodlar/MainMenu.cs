using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public AudioSource au;
    
    public void SesKapa()
    {
        au.volume = 0;
    }
    public void SesAc()
    {
        au.volume = 1;
    }
    public void Gecis()
    {
        Application.LoadLevel(1);
    }
}
