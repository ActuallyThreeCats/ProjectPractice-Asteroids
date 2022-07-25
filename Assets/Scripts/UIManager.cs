using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score, lives;
    private string livesText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score.text = GameManager.Instance.score.ToString();
        lives.text = "Lives: " + GameManager.Instance.lives.ToString();
    }
}
