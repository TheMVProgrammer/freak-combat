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
    }   

    public void RestartGame ()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("IntroScreen");
    }
}
