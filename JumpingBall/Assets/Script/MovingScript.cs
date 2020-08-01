using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingScript : MonoBehaviour
{
    public static MovingScript Move;
    public Rigidbody BallMove;
    
    public float JumpVelocity;

    //public float speed;

    private float _MaxYposition;

    public Image BlackImage;

    public GameObject GameOverUI;
    public static bool GameIsOver = false;

    public float xMove = 5f;

    private int mult;
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
        OnMouseDrag();

        if (transform.position.x > 6f)
        {
            transform.position = new Vector3(-6f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -6f)
        {
            transform.position = new Vector3(6f, transform.position.y, transform.position.z);
        }


        if (transform.position.y > _MaxYposition)
        {
            _MaxYposition = transform.position.y;
        }


        if (transform.position.y < _MaxYposition - 11f)
        {
            GameOver();
        }
    }

    private void OnMouseDrag()
    {
        Vector3 MoveDirection = Vector3.zero;
        int mult = 0;
        if (Input.touchCount>0)
        {
            Touch MyTouch = Input.GetTouch(0);
            if (MyTouch.phase == TouchPhase.Moved)
            {
                Vector3 positionChange = MyTouch.deltaPosition;
                positionChange.y = -positionChange.y;
                MoveDirection = positionChange.normalized;

                //if (MyTouch.position.x < Screen.width / 2)
                //{
                //    mult = -1;
                //}
                //else
                //{
                //    mult = 1;
                //}
            }
        }
        transform.position += MoveDirection * xMove * Time.deltaTime;
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

        if (gameObject.name.Equals("PlatformDestroyer"))
        {
            BallMove.velocity = new Vector3(BallMove.velocity.x, 0f, 0f);
        }
        else
        {
            BallMove.velocity = new Vector3(BallMove.velocity.x, JumpVelocity, 0f);
        }
    }
   

    public void GameOver()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsOver = true;
    }

   
}
