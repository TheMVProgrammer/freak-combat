using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayScript : MonoBehaviour
{
    Camera MainCamera;
    public Knight player;
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        MainCamera.transform.position = new Vector3(SelectStageScript.cameraPosition, 0f, -10f);
        player.transform.position = SelectStageScript.playerPosition;
        enemy.transform.position = SelectStageScript.EnemyPosition;
    }
}
