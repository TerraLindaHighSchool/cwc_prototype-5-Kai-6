using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float maxSpawn = 2f;
    private float minSpawn = 0.8f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public bool isGameActive;
    public Button restartButton;
    public int mistakes = 0;
    public int maxMistakes = 0;
    public GameObject mistake1;
    public GameObject mistake2;
    public GameObject mistake3;

    void Start()
    {
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        maxMistakes = difficulty;
        switch(difficulty)
        {
            case 1:
                mistake3.SetActive(true);
                break;
            case 2:
                mistake2.SetActive(true);
                mistake3.SetActive(true);
                break;
            case 3:
                mistake1.SetActive(true);
                mistake2.SetActive(true);
                mistake3.SetActive(true);
                break;
        }
        scoreText.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(Random.Range(minSpawn, maxSpawn));
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    // Update is called once per frame
    void Update()
    {
        if(mistakes >= maxMistakes)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}