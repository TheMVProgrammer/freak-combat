using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneController : MonoBehaviour
{
    public AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(audioSource);
    }
    public void PlayGame () {
        SceneManager.LoadScene("ChooseDifficultyScene");
    }
} // class
