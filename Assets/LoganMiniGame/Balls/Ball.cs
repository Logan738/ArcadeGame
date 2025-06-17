using UnityEngine;

public class Ball : MonoBehaviour
{
    
    public AudioSource CollectBread;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            BallCounter.Instance.AddPoint();
            CollectBread.Play();
            Destroy(gameObject);
        }
    }
}
