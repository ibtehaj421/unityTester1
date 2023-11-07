using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class soundControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioMixer menuMusic;
    [SerializeField] private Slider music;

    // Update is called once per frame
    public
    void SetMusicVolume()
    {
       float volume = music.value;
        menuMusic.SetFloat("Music", Mathf.Log10(volume)*20);
    }
}
