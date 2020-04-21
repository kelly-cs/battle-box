using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uimanager : MonoBehaviour
{
    public static Action enemyDestroyed;
    public TextMeshProUGUI text;
    public TextMeshProUGUI score;
    private TextMeshProUGUI gameover_text;
    private TextMeshProUGUI gameover_text2;
    private int _enemiesDestroyed = 0;

    private void OnDestroy()
    {
        enemyDestroyed -= UpdateText;

    }

    void Awake()
    {
        DontDestroyOnLoad(this);
        enemyDestroyed += UpdateText;
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(ShowToolTips());
        }

        SceneManager.sceneLoaded += ShowFinalScore;
        


    }

    private void ShowFinalScore(Scene scene, LoadSceneMode mode) // get data about the scene, required
    {
        if(scene.buildIndex == 1)
        {
            gameover_text = GameObject.FindWithTag("gameover1").GetComponent<TextMeshProUGUI>();
            gameover_text2 = GameObject.FindWithTag("gameover2").GetComponent<TextMeshProUGUI>();
            gameover_text.text = "GAME OVER";
            gameover_text2.text = "Final Score: " + _enemiesDestroyed.ToString();
        }
        
    }

    void UpdateText()
    {
        _enemiesDestroyed++;
        score.text = "SCORE: " + _enemiesDestroyed.ToString();
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    
    IEnumerator ShowToolTips()
    {

        yield return new WaitForSeconds(2);
        text.text = "WASDQE to Move Ship";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);
        text.text = "Arrow Keys to Move Pilot";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);
        text.text = "Move Pilot to Turrets to Activate";
        yield return new WaitForSeconds(3);
        text.text = "Keep Your Pilot Alive!";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield break;
    }
}
