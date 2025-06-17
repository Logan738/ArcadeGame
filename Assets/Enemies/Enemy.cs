using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;        // Reference to the player's transform
    public float speed = 5f;        // Speed at which the enemy moves

    void Update()
    {
        if (player != null)
        {
            // Calculate direction towards the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
