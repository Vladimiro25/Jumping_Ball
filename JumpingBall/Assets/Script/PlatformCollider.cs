using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollider : MonoBehaviour
{
    public Collider Collider;
    public Transform PlayerTransform;

    private bool Done;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = FindObjectOfType<MovingScript>().transform;
        Collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Done == false)
        {
            if (PlayerTransform.position.y > transform.position.y)
            {
                Done = true;
                ScoreScript.instance.AddScore();
                GameOverScore.instance.AddScore();
            }
        }


        if (PlayerTransform.position.y - 0.5f > transform.position.y + 0.05f)
        {
            Collider.enabled = true;
        }
        else if (PlayerTransform.position.y < transform.position.y - 0.5f)
        {
            Collider.enabled = false;
        }
        if (PlayerTransform.position.y > transform.position.y + 12f)
        {
            Destroy(gameObject);
        }
    }
}
