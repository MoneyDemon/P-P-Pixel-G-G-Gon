using TMPro;
using UnityEngine;

public class SimMoSci : MonoBehaviour
{
    Rigidbody2D _rb;

    float _speed = 10f;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float _xSpeed = 0;
        if (Input.GetKey(KeyCode.A))
        {
            _xSpeed = -_speed;
        }
        if(Input.GetKey(KeyCode.D))
        {
            _xSpeed = _speed;
        }
        _rb.linearVelocityX = _xSpeed;
    }
}
