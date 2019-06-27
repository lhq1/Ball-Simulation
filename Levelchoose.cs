using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levelchoose : MonoBehaviour
{
    int NoUnlock;
    int no;
    // Start is called before the first frame update
    void Start()
    {
        NoUnlock = PlayerPrefs.GetInt("UnlockLevel",1);
        no = gameObject.name[5]-'0';

        Image img = gameObject.GetComponent<Image>();
        Sprite spr;
        if (no <= NoUnlock)
            spr = Resources.Load("door",typeof(Sprite)) as Sprite;
        else spr = Resources.Load("face-block", typeof(Sprite)) as Sprite;
        img.sprite = spr;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Debug.Log(no);
        if (no <= NoUnlock)
        {
            Debug.Log("succ");
            Debug.Log(gameObject.name);
            UnityEngine.SceneManagement.SceneManager.LoadScene(gameObject.name);
            Time.timeScale = 1f;
        }
        else Debug.Log("fail");
    }
}
