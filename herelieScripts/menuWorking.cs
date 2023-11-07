using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuWorking : MonoBehaviour
{
    public
    void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public
    void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    //public
    //void Options()
    //{
    //    this.enabled = false;
    //}
}
