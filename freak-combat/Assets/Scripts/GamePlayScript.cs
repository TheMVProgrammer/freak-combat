using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayScript : MonoBehaviour
{
    Camera MainCamera;
    public Knight player;
    public Enemy enemy;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("Background Sound").GetComponent<AudioSource>();
        Destroy(audioSource);
        MainCamera = Camera.main;
        MainCamera.transform.position = new Vector3(SelectStageScript.cameraPosition, 0f, -10f);
        player.transform.position = SelectStageScript.playerPosition;
        enemy.transform.position = SelectStageScript.EnemyPosition;
        HandleSound();
    }   

    public void RestartGame ()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void HomeButton ()
    {
        SceneManager.LoadScene("IntroScreen");
    }

    public void HandleSound ()
    {
        if (MainCamera.transform.position.x == -96f)
        {
            AudioSource theGraveyard = GameObject.Find("The Graveyard").GetComponent<AudioSource>();
            theGraveyard.Play();
        }
        else if (MainCamera.transform.position.x == -76.8f)
        {
            AudioSource rockyMountains = GameObject.Find("Rocky Mountains").GetComponent<AudioSource>();
            rockyMountains.Play();
        }
        else if (MainCamera.transform.position.x == -57.6f)
        {
            AudioSource magicForest = GameObject.Find("Magic Forest").GetComponent<AudioSource>();
            magicForest.Play();
        }
        else if (MainCamera.transform.position.x == -38.4f)
        {
            AudioSource lostCity = GameObject.Find("Lost City").GetComponent<AudioSource>();
            lostCity.Play();
        }
        else if (MainCamera.transform.position.x == -19.2f)
        {
            AudioSource childrensParadise = GameObject.Find("Children's Paradise").GetComponent<AudioSource>();
            childrensParadise.Play();
        }
        else if (MainCamera.transform.position.x == 0)
        {
            AudioSource theLake = GameObject.Find("The Lake").GetComponent<AudioSource>();
            theLake.Play();
        }
        else if (MainCamera.transform.position.x == 19.2f)
        {
            AudioSource draculaCastle = GameObject.Find("Dracula Castle").GetComponent<AudioSource>();
            draculaCastle.Play();
        }
        else if (MainCamera.transform.position.x == 38.4f)
        {
            AudioSource greatMountainRange = GameObject.Find("Great Mountain Range").GetComponent<AudioSource>();
            greatMountainRange.Play();
        }
        else if (MainCamera.transform.position.x == 57.6f)
        {
            AudioSource lostRemains = GameObject.Find("Lost Remains").GetComponent<AudioSource>();
            lostRemains.Play();
        }
        else if (MainCamera.transform.position.x == 76.8f)
        {
            AudioSource postApocalypse = GameObject.Find("Post Apocalypse").GetComponent<AudioSource>();
            postApocalypse.Play();
        }
        else if (MainCamera.transform.position.x == 95.99999f)
        {
            AudioSource theForbiddenForest = GameObject.Find("The Forbidden Forest").GetComponent<AudioSource>();
            theForbiddenForest.Play();
        }
        else
        {
            AudioSource theHauntedTrain = GameObject.Find("The Haunted Train").GetComponent<AudioSource>();
            theHauntedTrain.Play();
        }
    }
}
