using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameStart;
    public GameObject gameEnd;
    public GameObject gamePlay;
    public GameObject gamePause;
    public GameObject gameSetting;

    public SpawnManager spawnManager;

    public int distance = 0;
    bool isSettingOpen = false;

    public TextMeshProUGUI disText;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;

    private void Awake()
    {
        gameStart.SetActive(true);
        gameEnd.SetActive(false);
        gamePlay.SetActive(false);
        gamePause.SetActive(false);
        gameSetting.SetActive(false);
        Time.timeScale = 0;
    }

    private void FixedUpdate()
    {
        var player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (player.gameOver == true)
        {
            gameEnd.SetActive(true);
            gamePlay.SetActive(false);
            spawnManager.StopAllCoroutines();

            currentScoreText.text = disText.text;
            SetHighScore();
            highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
        else
        {
            distance += 1;
            disText.text = distance.ToString();
        }
    }

    public void SettingOpen()
    {
        if (isSettingOpen == true)
        {
            gameSetting.SetActive(false);
            isSettingOpen = false ;
        }
        else
        {
            gameSetting.SetActive(true);
            isSettingOpen = true;
        }
    }

    public void SetHighScore()
    {
        if (distance > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", distance);
        }
    }

    public void StartGame()
    {
        gameStart.SetActive(false);
        gamePlay.SetActive(true);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        gamePause.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        gamePause.SetActive(false);
        Time.timeScale = 1;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("GamePlay");
    }

}
