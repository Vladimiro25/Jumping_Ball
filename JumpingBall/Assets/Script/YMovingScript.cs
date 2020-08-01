using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YMovingScript : MonoBehaviour
{
    private Vector3 PositionA;
    private Vector3 PositionB;

    private Vector3 TargetPosition;

    public float speed;
    void Start()
    {
        PositionA = new Vector3(0f, -1.5f, 0f);
        PositionB = new Vector3(0f, 1.5f, 0f);

        TargetPosition = PositionA;
    }

    
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, TargetPosition, Time.deltaTime * speed);

        if (Vector3.Distance(transform.localPosition, TargetPosition) < 0.1f)
        {
            if (TargetPosition == PositionA)
            {
                TargetPosition = PositionB;
            }
            else
            {
                TargetPosition = PositionA;
            }
        }
    }
}
