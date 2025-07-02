using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    public Transform player;             // Reference to Pac-Man
    public float moveSpeed = 5f;
    public LayerMask wallLayer;

    private Vector2 currentDirection;
    private Rigidbody2D rb;

    private Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PickDirectionTowardPlayer(); // Initial direction
    }

    void FixedUpdate()
    {
        Vector2 newPos = rb.position + currentDirection * moveSpeed * Time.fixedDeltaTime;

        if (!CanMove(currentDirection))
        {
            PickDirectionTowardPlayer(); // Collision detected, choose new path
        }
        else
        {
            rb.MovePosition(newPos);
        }
    }

    void PickDirectionTowardPlayer()
    {
        Vector2 toPlayer = player.position - transform.position;

        // Get priority directions (e.g., move vertically if player is higher)
        List<Vector2> preferredDirs = new List<Vector2>();

        if (Mathf.Abs(toPlayer.x) > Mathf.Abs(toPlayer.y))
        {
            preferredDirs.Add(toPlayer.x > 0 ? Vector2.right : Vector2.left);
            preferredDirs.Add(toPlayer.y > 0 ? Vector2.up : Vector2.down);
        }
        else
        {
            preferredDirs.Add(toPlayer.y > 0 ? Vector2.up : Vector2.down);
            preferredDirs.Add(toPlayer.x > 0 ? Vector2.right : Vector2.left);
        }

        // Add remaining directions as fallback
        foreach (var dir in directions)
        {
            if (!preferredDirs.Contains(dir))
                preferredDirs.Add(dir);
        }

        // Pick the first valid direction
        foreach (Vector2 dir in preferredDirs)
        {
            if (CanMove(dir))
            {
                currentDirection = dir;
                return;
            }
        }

        // If stuck, stop moving
        currentDirection = Vector2.zero;
    }

    bool CanMove(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, dir, 1f, wallLayer);
        return hit.collider == null;
    }
}
