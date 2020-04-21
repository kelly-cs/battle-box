using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject RedEnemy1;
    public GameObject SpawnPoint1;

    
    private float _spawnDelay = 5f;
    private float _difficulty = 1f;
    private int _randomEnemyType = 0;
    private int _enemySpawnedCounter = 0;
    private float _timer = 0f;



    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        _randomEnemyType = UnityEngine.Random.Range(0,4);

        _spawnDelay = 5f - (_enemySpawnedCounter * 0.06f);
        if(_spawnDelay < 1.5f)
        {
            _spawnDelay = 1.5f;
        }
        if(_timer > _spawnDelay)
        {
            switch (_randomEnemyType)
            {
                case 0:
                    Spawn(Colors.red);
                    break;
                case 1:
                    Spawn(Colors.blue);
                    break;
                case 2:
                    Spawn(Colors.green);
                    break;
                case 3:
                    Spawn(Colors.yellow);
                    break;
            }
            _timer = 0;
            _enemySpawnedCounter++;
        }
    }

   

  

    void Spawn(Colors color) // pass in enum
    {
        var enemy = Instantiate(RedEnemy1, SpawnPoint1.transform.position, Quaternion.AngleAxis(-90, Vector3.forward));
        var enemy_code = enemy.GetComponent<Enemy1>();
        enemy_code.color = color;
    }

}
