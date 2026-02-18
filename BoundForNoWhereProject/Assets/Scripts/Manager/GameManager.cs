using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public bool levelFinished;
    List<EnemyBase> enemies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // if(enemies.Count <= 0)
        // {
        //     levelFinished = true;
        // }
    }

    void GetAllEnemies()
    {
        enemies = new List<EnemyBase>(Object.FindObjectsByType<EnemyBase>(FindObjectsSortMode.None));
    }
}
