using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject RedEnemy1;
    public GameObject SpawnPoint1;
    public TextMeshProUGUI text;
    public TextMeshProUGUI score;
    public static Action enemyDestroyed;
    private float _spawnDelay = 5f;
    private float _difficulty = 1f;
    private int _randomEnemyType = 0;
    private int _enemySpawnedCounter = 0;
    private int _enemiesDestroyed = 0;
    private float _timer = 0f;


    private void OnDestroy()
    {
        enemyDestroyed -= UpdateText;
    }

    private void Awake()
    {
        enemyDestroyed += UpdateText;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowToolTips());
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        _randomEnemyType = UnityEngine.Random.Range(0,4);

        _spawnDelay = 5f - (_enemySpawnedCounter * 0.05f);
        if(_spawnDelay < 2f)
        {
            _spawnDelay = 2f;
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

    void UpdateText()
    {
       
        _enemiesDestroyed++;
        score.text = "SCORE: " + _enemiesDestroyed.ToString();
    }

    IEnumerator ShowToolTips()
    {

        yield return new WaitForSeconds(4);
        text.text = "WASDQE to Move Ship";
        yield return new WaitForSeconds(4);
        text.text = "";
        yield return new WaitForSeconds(4);
        text.text = "Arrow Keys to Move Pilot";
        yield return new WaitForSeconds(4);
        text.text = "";
        yield return new WaitForSeconds(4);
        text.text = "Move Pilot to Turrets to Activate";
        yield return new WaitForSeconds(4);
        text.text = "";
        yield return new WaitForSeconds(4);
        text.text = "Walls Heal While Pilot is in Ship";
        yield return new WaitForSeconds(4);
        text.text = "Keep Your Pilot Alive!";
        yield return new WaitForSeconds(4);
        text.text = "";
        yield break;
    }

    void Spawn(Colors color) // pass in enum
    {
        var enemy = Instantiate(RedEnemy1, SpawnPoint1.transform.position, Quaternion.AngleAxis(-90, Vector3.forward));
        var enemy_code = enemy.GetComponent<Enemy1>();
        enemy_code.color = color;
    }

}
