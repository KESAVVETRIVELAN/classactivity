
using UnityEngine;

public class SimpleGameController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the character movement
    public int jumpForce;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component of the character
    }

    void Update()
    {
        // Get input from arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal");      
       transform.Translate(Vector2.right * moveHorizontal * moveSpeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickup"))
        {
            // Do something when character collides with object tagged as "Pickup"
            Destroy(other.gameObject); // Destroy the object
            // Add score, play sound, etc.
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
