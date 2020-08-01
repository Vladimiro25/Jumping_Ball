using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 positionA;
    private Vector3 positionB;

    private Vector3 TargetPosition;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        positionA = new Vector3(-2f, 0f, 0f);
        positionB = new Vector3(2f, 0f, 0f);

        TargetPosition = positionA;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, TargetPosition, Time.deltaTime * speed);


        if (Vector3.Distance(transform.localPosition,TargetPosition) < 0.1f)
        {
            if (TargetPosition == positionA)
            {
                TargetPosition = positionB;
            }
            else
            {
                TargetPosition = positionA;
            }
        }
        
    }
}
