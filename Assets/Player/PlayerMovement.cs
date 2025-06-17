using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool is2D = true; // Toggle for 2D or 3D movement

    private Rigidbody2D rb2D;
    private Rigidbody rb3D;
    private Vector2 movement2D;
    private Vector3 movement3D;

    void Start()
    {
        if (is2D)
        {
            rb2D = GetComponent<Rigidbody2D>();
        }
        else
        {
            rb3D = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (is2D)
        {
            movement2D = new Vector2(moveX, moveY).normalized;
        }
        else
        {
            movement3D = new Vector3(moveX, 0, moveY).normalized;
        }
    }

    void FixedUpdate()
    {
        if (is2D && rb2D != null)
        {
            rb2D.MovePosition(rb2D.position + movement2D * moveSpeed * Time.fixedDeltaTime);
        }
        else if (!is2D && rb3D != null)
        {
            rb3D.MovePosition(rb3D.position + movement3D * moveSpeed * Time.fixedDeltaTime);
        }
    }
}


