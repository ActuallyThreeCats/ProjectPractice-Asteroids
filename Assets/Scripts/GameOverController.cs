using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    private int score;
    private int highScore;
    public void Start()
    {
        score = GameManager.Instance.score;
        highScore = PlayerPrefs.GetInt("_highScore");
        highScoreText.text = string.Format("High Score:\n {0:000000}", highScore);
        finalScoreText.text = string.Format(" Final Score:\n {0:000000}", score);
    }
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
        GameManager.Instance.score = 0;
        GameManager.Instance.lives = 3;
        AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.button);

    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
