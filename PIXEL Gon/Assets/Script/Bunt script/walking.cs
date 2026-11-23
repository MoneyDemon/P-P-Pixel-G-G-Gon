using UnityEngine;

public class walking : MonoBehaviour
{
    [SerializeField] float movespeed;
   private Rigidbody2D rb;
     float speedX, speedY;
    private Vector2 input;
       
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = input * movespeed;
    }
    private void GetInput()
    {
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");

        input = new Vector2(speedX, speedY);
        input.Normalize();
    }
}
