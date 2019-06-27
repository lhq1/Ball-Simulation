using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
    public StateSystem state;
    public NotationControl message;
    public LifeScript life;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
    int hp = 1;
    bool access = false;
    public GameObject win;
    public GameObject lose;
	// Update is called once per frame
	void Update () {
        if (Time.timeScale != 0)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }

            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
        }
        

	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "deepdarkfun")
        {
            hp = 0;
            lose.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
            
        }

        if (collision.gameObject.tag == "friend")
        {
            state.SetAbleStone();
            Debug.Log("You can change to the stone form!");
        }

        if (collision.gameObject.tag == "door")
        {

            if (access)
            {
                win.SetActive(true);
                Time.timeScale = 0;
            }                       
        }

        if (collision.gameObject.tag == "keybox")
        {
            access = true;
            GameObject go = message.gameObject;
            go.SetActive(true);
            message.getkey();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fire")
        {
            if (gameObject.tag == "stone_ball")
            {
                Debug.Log("You are not afraid of fire!");
            }

            if (gameObject.tag == "wood_ball")
            {
                Debug.Log("hp-1");
                hp -= 1;
                life.change(hp);
                if (hp == 0)
                {
                    lose.SetActive(true);
                    Destroy(gameObject);
                    Time.timeScale = 0;
                }
            }
        }
    }


}
