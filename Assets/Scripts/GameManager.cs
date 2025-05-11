using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameStart;
    public GameObject gameEnd;
    public GameObject gamePlay;
    public GameObject gamePause;

    public int distance = 0;
    public TextMeshProUGUI disText;

    private void Awake()
    {
        gameStart.SetActive(true);
        gameEnd.SetActive(false);
        gamePlay.SetActive(false);
        gamePause.SetActive(false);
        Time.timeScale = 0;
    }

    private void FixedUpdate()
    {
        var player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (player.gameOver == true)
        {
            gameEnd.SetActive(true);
            gamePlay.SetActive(false);
            StopAllCoroutines();
        }
        else
        {
            distance += 1;
            disText.text = distance.ToString();
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
        SceneManager.LoadScene("Prototype");
    }

}
