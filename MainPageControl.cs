using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPageControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        const int buttonWidth = 84;
        const int buttonHeight = 60;
        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (1 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight), "开始游戏"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelPage");
            Time.timeScale = 1f;
        }

    }
}
