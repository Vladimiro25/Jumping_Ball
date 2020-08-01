using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    
    public GameObject Parent;

     Rigidbody rb;

    
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    private void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Invoke("FallPlatform", 0f);
        Destroy(Parent, 1f);
        Destroy();

    }
    void FallPlatform()
    {
        rb.isKinematic = false;
    }

    void Destroy()
    {
        if (Input.GetMouseButton(0))
        {
            MovingScript.Move.BallMove.velocity = new Vector3(Input.GetAxis("Mouse X"), 0f, 0f);
        }
    }
}
