using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private Transform _playerPosition;
    private Rigidbody _playerRigidbody;
    public float _force = 2f;
    public float _speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _playerPosition = gameObject.GetComponent<Transform>();
        _playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirection = 0;
        var dir = new Vector3();
        if (Input.GetMouseButtonUp(0))
        {
            moveDirection = 1;
            dir = (Camera.main.ScreenToViewportPoint(Input.mousePosition) - _playerPosition.transform.position).normalized;
            dir.y = 0;
            dir.z = 0;
        }
        if (moveDirection > 0)
        {
            dir = Vector3.Lerp(dir, Vector3.zero, moveDirection);
            moveDirection -= Time.deltaTime;
            transform.position += dir * (_speed * Time.deltaTime);
        }
        if (Input.GetMouseButton(0))
        {
            dir = (Camera.main.ScreenToViewportPoint(Input.mousePosition) - _playerPosition.transform.position).normalized;
            dir.y = 0;
            dir.z = 0;
            transform.position += dir * (_speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            _playerRigidbody.AddForce(Vector3.up * _force, ForceMode.Impulse);
        }
    }
}
