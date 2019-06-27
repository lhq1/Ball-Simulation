using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessScript : MonoBehaviour
{
    public GameObject inGameMeun;
    private string name;

    public void OnPause()
    {
        inGameMeun.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnResume()
    {
        Time.timeScale = 1f;
        inGameMeun.SetActive(false);
    }
    public void OnRestart()
    {
        name = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);

        Time.timeScale = 1f;

    }

    public void OnMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainPage");
    }

    public void OnNext()
    {
        name = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        string s = "" + name[5];
        int n = int.Parse(s);
        n += 1;
        s = "level" + n;
        Debug.Log(s);
        UnityEngine.SceneManagement.SceneManager.LoadScene(s);
    }

}
