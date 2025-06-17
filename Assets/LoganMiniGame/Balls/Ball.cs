using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BallCounter.Instance.AddPoint();
            Destroy(gameObject);
        }
    }
}
