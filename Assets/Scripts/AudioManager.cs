using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
   
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip shoot, button, asteroid, death, thrust;


    public void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
