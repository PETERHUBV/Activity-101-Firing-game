using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class FiringGame : MonoBehaviour
{
    public static FiringGame Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public Text scoreText;
   
    public Text endText;

   
    private int score;
    private int hitCount;
    private bool gameEnded;

    public List<FiringGameEnemy> Enemy = new List<FiringGameEnemy>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        score = 0;
      

        scoreText.text = "Score: 0";
        endText.gameObject.SetActive(false);
    }

  void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EndGame();
        }
    }
    public void RegisterTarget(FiringGameEnemy target)
    {
        if (!Enemy.Contains(target))
            Enemy.Add(target);
    }

    public void AddScore(int points)
    {
        if (gameEnded) return;

        score += points;

        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void TargetHit()
    {
        if (gameEnded) return;

        hitCount++;

        int activeEnemies = 0;

        for (int i = 0; i < Enemy.Count; i++)
        {
            if (Enemy[i].gameObject.activeSelf)
                activeEnemies++;
        }

        if (hitCount >= activeEnemies)
        {
            hitCount = 0;
            ResetAllTargets();
        }
    }

    void ResetAllTargets()
    {
        hitCount = 0;

        foreach (FiringGameEnemy enemy in Enemy)
        {
           
            
                enemy.ResetTarget();
            }
        }
    

    public void EndGame()
    {
        gameEnded = true;

        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score;
        }

        if (endText != null)
        {
            endText.text =
                "GAME OVER\n\n" +
                "Score: " + score +
                "\nHigh Score: " + highScore;

            endText.gameObject.SetActive(true);


            Time.timeScale = 0f;
        }
    }
}