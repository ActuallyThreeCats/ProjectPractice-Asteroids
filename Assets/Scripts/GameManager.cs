using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public int lives;
    [SerializeField] public int score;
    private int highScore;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        highScore = PlayerPrefs.GetInt("_highScore");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
            if (score > highScore)
            {
                SaveScore(score);

            }
            lives = 3;
        }
    }

    public void SaveScore(int score)
    {
        PlayerPrefs.SetInt("_highScore", score);
        PlayerPrefs.Save();
    }
}
