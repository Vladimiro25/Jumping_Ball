using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingScript : MonoBehaviour
{
    public static MovingScript Move;
    public Rigidbody BallMove;
    
    public float JumpVelocity;

    private float MaxYposition;

    public Image BlackImage;

    public GameObject GameOverUI;
    public static bool GameIsOver = false;

    public float Xmove = 5f;

    
    private void Start()
    {
        if (Move == null)
        {
            Move = this;
        }
    }

    private void Update()
    {
        StopMove();

        
    }

    void FixedUpdate()
    {
        MoveBall();

        if (transform.position.x > 6f)
        {
            transform.position = new Vector3(-6f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -6f)
        {
            transform.position = new Vector3(6f, transform.position.y, transform.position.z);
        }


        if (transform.position.y > MaxYposition)
        {
            MaxYposition = transform.position.y;
        }


        if (transform.position.y < MaxYposition - 11f)
        {
            GameOver();
        }
    }

    private void MoveBall()
    {
        if (Input.GetMouseButton(0) == false)
        {
            return;
        }
        
        int multiplayer = 0;
        if (Input.GetMouseButton(0))
        {

            Vector3 touch = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            if (Input.mousePosition.x < Screen.width / 2)
            {
                multiplayer = -1;
            }
            else
            {
                multiplayer = 1;
            }
        }
        BallMove.velocity = new Vector3(multiplayer * Xmove, BallMove.velocity.y, 0);
    }
    public void StopMove()
    {
        if (Input.GetMouseButtonUp(0))
        {
            BallMove.velocity = new Vector3(0f, BallMove.velocity.y, 0f);
        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        
        BallMove.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
    }
   

    public void GameOver()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsOver = true;
    }

   
}
