using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneController : MonoBehaviour
{
    AudioSource startSound;
    private void Start()
    {
        startSound = GameObject.Find("StartSound").GetComponent<AudioSource>();
    }
    public void PlayGame () {
        startSound.Play();
        Invoke(nameof(LoadScene), 1f);
    }

    public void LoadScene ()
    {
        SceneManager.LoadScene("ChooseDifficultyScene");
    }
} // class
