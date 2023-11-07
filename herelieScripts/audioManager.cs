using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    // Start is called before the first frame update

   // [SerializeField] AudioClip background;
    // Update is called once per frame
    private void Start()
    {
       // musicSource.clip = background;
        musicSource.Play();
    }
}
