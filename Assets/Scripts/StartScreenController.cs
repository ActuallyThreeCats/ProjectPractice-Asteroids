using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScreenController : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
        AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.button);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
