using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameStart;
    public GameObject gameEnd;
    public GameObject gamePlay;

    private void Awake()
    {
        gameStart.SetActive(true);
        gameEnd.SetActive(false);
        gamePlay.SetActive(false);
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
    }

    public void StartGame()
    {
        gameStart.SetActive(false);
        gamePlay.SetActive(true);
        Time.timeScale = 1;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Prototype");
    }

}
