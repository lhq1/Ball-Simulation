using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotationControl : MonoBehaviour
{
    private string hints;
    bool PressUp = false;
    bool PressDown = false;
    bool PressLeft = false;
    bool PressRight = false;
    bool PressZ = false;
    public StateSystem state;
    public GameObject go;
    public Text t;
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find("notation");
        t = go.GetComponent<Text>();
        hints = "按方向左右键或者AD键控制移动";
        t.text = hints;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            go = GameObject.Find("notation");
            t = go.GetComponent<Text>();
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) PressUp = true;
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) PressDown = true;
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) PressLeft = true;
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) PressRight = true;
            if (Input.GetKeyDown(KeyCode.Z)) PressZ = true;
            switch (hints)
            {
                case "按方向左右键或者AD键控制移动":
                    if (PressLeft && PressRight)
                    {
                        hints = "按方向上键或者W键跳跃";
                        t.text = hints;
                    }
                    break;
                case "按方向上键或者W键跳跃":

                    if (PressUp)
                    {
                        hints = "接下来触碰石头小球，获得新的能力";
                        t.text = hints;
                    }
                    break;
                case "接下来触碰石头小球，获得新的能力":
                    if (state.GetAbleStone())
                    {
                        hints = "按Z键转换形态，变成石头小球";
                        t.text = hints;
                    }
                    break;
                case "按Z键转换形态，变成石头小球":
                    if (PressZ)
                    {
                        go.SetActive(false);
                    }
                    break;

                default: break;
            }
            if (PressLeft || PressRight) PressUp = PressDown = PressZ = false;
            else PressUp = PressDown = PressLeft = PressRight = PressZ = false;
        }
    }

        public void getkey()
        {
            go = GameObject.Find("notation");
            t = go.GetComponent<Text>();
            hints = "小球从箱子里拿到了钥匙!";
            t.text = hints;
            
    }
    
}
