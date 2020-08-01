using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject PlatformA;
    public GameObject PlatformB;
    public GameObject PlatformC;
    public GameObject PlatformD;

    public Transform PlayerTransform;

    private float LastCreatedPlatformPosition;
    // Update is called once per frame
    void Update()
    {
        while (LastCreatedPlatformPosition<PlayerTransform.position.y + 10f)
        {
            CreateNewPlatform();
        }
    }
    public void CreateNewPlatform()
    {
        float xPosition = Random.Range(-4f, 4f);
        float yOffSet = Random.Range(-0.1f, 0.1f);
        

        Vector3 Position = new Vector3(xPosition, LastCreatedPlatformPosition + 2f + yOffSet, 0f);

        int RandomValue = Random.Range(0, 10);


        if (RandomValue == 9 || RandomValue == 8 || RandomValue == 7 || RandomValue == 6 || RandomValue == 5 || RandomValue == 4)
        {
            Instantiate(PlatformA, Position, Quaternion.identity);
        }
        else if (RandomValue == 3)
        {
            Instantiate(PlatformB, Position, Quaternion.identity);
        }
        else if (RandomValue == 2)
        {
            Instantiate(PlatformC, Position, Quaternion.identity);
        }
        else if (RandomValue == 1 || RandomValue == 0)
        {
            Instantiate(PlatformD, Position, Quaternion.identity);
        }
        LastCreatedPlatformPosition = Position.y;




    }
}
