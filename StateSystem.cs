using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BallState
{
    Wooden,
    Stone,
    Invincibility
}
public class StateSystem : MonoBehaviour
{
    public CharacterController2D control;
    private bool AbleStone = false;
    private bool pause;
    public BallState current;
    void ChangeState()
    {
        switch (current) { 
            case (BallState.Wooden):
                if (AbleStone)
                {
                    current = BallState.Stone;
                    SpriteRenderer spr1 = gameObject.GetComponent<SpriteRenderer>();
                    Texture2D Tex1 = Resources.Load("ball1") as Texture2D;
                    Sprite spriteA = Sprite.Create(Tex1, new Rect(0, 0, 32, 32), new Vector2(0.5f, 0.5f), 23);
                    spr1.sprite = spriteA;
                    gameObject.tag = "stone_ball";
                    control.SetJump(500f);
                }
                
                break;

            case (BallState.Stone): 
                current = BallState.Wooden;
                SpriteRenderer spr2 = gameObject.GetComponent<SpriteRenderer>();
                Texture2D Tex2 = Resources.Load("ball2") as Texture2D;
                Sprite spriteB = Sprite.Create(Tex2, new Rect(0, 0, 32, 32), new Vector2(0.5f, 0.5f), 23);
                spr2.sprite = spriteB;
                gameObject.tag = "wood_ball";
                control.SetJump(700f);
                break;

            default: break;
        }
        
    }

    public void SetAbleStone()
    {
        AbleStone = true;
    }

    public bool GetAbleStone()
    {
        return AbleStone;
    } 
    // Start is called before the first frame update
    void Start()
    {
        current = BallState.Wooden;
        SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
        Texture2D Tex = Resources.Load("ball2") as Texture2D;
        Sprite sprite = Sprite.Create(Tex, new Rect(0, 0, 32, 32), new Vector2(0.5f, 0.5f), 23);
        spr.sprite = sprite;
        gameObject.tag = "wood_ball";
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ChangeState();
            }
            if (Input.GetKeyDown(KeyCode.P))
                pause = !pause;
            if (pause) Time.timeScale = 0;
            else Time.timeScale = 1;
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }
    
}
