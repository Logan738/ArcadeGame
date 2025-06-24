using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;        // Reference to the player's transform
    public float speed = 5f;        // Speed at which the enemy moves
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate direction towards the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.position += direction * speed * Time.deltaTime;

            // Flip sprite based on horizontal movement
            if (direction.x != 0)
            {
                spriteRenderer.flipX = direction.x < 0;
            }
        }
    }
}
