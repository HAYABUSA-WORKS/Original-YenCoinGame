using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] CoinGenerator coinGenerator;
    [SerializeField] PlayerController playerController;
    [SerializeField] Ranking ranking;

    [SerializeField] GameObject titlePanel;
    [SerializeField] Button startButton;
    [SerializeField] GameOverArea gameOverArea;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject resultPanel;
    [SerializeField] TextMeshProUGUI resultScoreText;
    [SerializeField] TextMeshProUGUI resultScoreIntText;
    [SerializeField] Button retryButton;


    int[] scoreArray;
    int score = 0;

    void Start()
    {
        scoreArray = new int[coinGenerator.CoinsLength()];
        scoreArray[0] = 1;
        scoreArray[1] = 5;
        scoreArray[2] = 10;
        scoreArray[3] = 50;
        scoreArray[4] = 100;
        scoreArray[5] = 500;
        scoreArray[6] = 1000;
        scoreArray[7] = 5000;
        scoreArray[8] = 10000;

        coinGenerator.addScore = AddScore;
        gameOverArea.gameOver = () => StartCoroutine(GameOver());

        retryButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
        startButton.onClick.AddListener(OnStartButton);
        resultPanel.SetActive(false);
        SoundManager.instance.PlayBGM(0);
        ranking.DisplayRank();
    }

    void AddScore(int coinIndex)
    {
        score += scoreArray[coinIndex] * 2;
        scoreText.text = score + "ÅÒ~";
    }

    IEnumerator GameOver()
    {
        ranking.SetRank(score);
        resultScoreIntText.text = score + "ÅÒ~";
        resultPanel.SetActive(true);
        SoundManager.instance.PlayBGM(1);

        yield return new WaitForSeconds(2f);

        resultScoreIntText.gameObject.SetActive(true);
        ranking.DisplayRank();

        yield return new WaitForSeconds(0.5f);

        retryButton.gameObject.SetActive(true);
    }

    void OnStartButton()
    {
        titlePanel.SetActive(false);
        playerController.IsStart = true;
        coinGenerator.GenerateStart();
    }

}