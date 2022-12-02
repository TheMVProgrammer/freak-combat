using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectStageScript : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public static float cameraPosition;
    public static Vector3 playerPosition;
    public static Vector3 EnemyPosition;

    private void Update()
    {
        if (textMeshProUGUI.text == "The Graveyard")
        {
            cameraPosition = -96f;
            playerPosition = new Vector3(-101.74f, -0.35f, 0f);
            EnemyPosition = new Vector3(-90.49f, 1.12f, 0);

        }
        else if (textMeshProUGUI.text == "Rocky Mountains")
        {
            cameraPosition = -76.8f;
            playerPosition = new Vector3(-82.58f, -1.96f, 0f);
            EnemyPosition = new Vector3(-71.33f, -0.65f, 0f);
        }
        else if (textMeshProUGUI.text == "Magic Forest")
        {
            cameraPosition = -57.6f;
            playerPosition = new Vector3(-63.12f, -0.4700001f, 0f);
            EnemyPosition = new Vector3(-51.87f, 1.01f, 0f);

        }
        else if (textMeshProUGUI.text == "Lost City")
        {
            cameraPosition = -38.4f;
            playerPosition = new Vector3(-44.3f, -1.41f, 0f);
            EnemyPosition = new Vector3(-32.5f, 0.07f, 0f);

        }
        else if (textMeshProUGUI.text == "Children's Paradise")
        {
            cameraPosition = -19.2f;
            playerPosition = new Vector3(-24.75f, -1.41f, 0f);
            EnemyPosition = new Vector3(-12.95f, 0.16f, 0f);

        }
        else if (textMeshProUGUI.text == "The Lake")
        {
            cameraPosition = 0f;
            playerPosition = new Vector3(-5.11f, -1.83f, 0f);
            EnemyPosition = new Vector3(5.39f, -0.66f, 0f);
        }
        else if (textMeshProUGUI.text == "Dracula Castle")
        {
            cameraPosition = 19.2f;
            playerPosition = new Vector3(13.79f, -0.42f, 0f);
            EnemyPosition = new Vector3(24.95f, 0.97f, 0f);
        }
        else if (textMeshProUGUI.text == "Great Mountain Range")
        {
            cameraPosition = 38.4f;
            playerPosition = new Vector3(33.08f, -2f, 0f);
            EnemyPosition = new Vector3(44.24f, -0.61f, 0f);
        }
        else if (textMeshProUGUI.text == "Lost Remains")
        {
            cameraPosition = 57.6f;
            playerPosition = new Vector3(52.06f, -0.7499999f, 0f);
            EnemyPosition = new Vector3(63.22f, 0.64f, 0f);
        }
        else if (textMeshProUGUI.text == "Post Apocalypse")
        {
            cameraPosition = 76.8f;
            playerPosition = new Vector3(71.28f, -1.37f, 0f);
            EnemyPosition = new Vector3(82.44f, 0.02f, 0f);
        }
        else if (textMeshProUGUI.text == "The Forbidden Forest")
        {
            cameraPosition = 95.99999f;
            playerPosition = new Vector3(90.78f, -1.61f, 0f);
            EnemyPosition = new Vector3(101.94f, 0.83f, 0f);
        }
        else 
        { 
            cameraPosition = 115.2f;
            playerPosition = new Vector3(109.95f, -1.41f, 0f);
            EnemyPosition = new Vector3(121.11f, 0.06f, 0f);
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
