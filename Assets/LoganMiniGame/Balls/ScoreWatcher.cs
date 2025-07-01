using UnityEngine;

public class ScoreWatcher : MonoBehaviour
{
    public GameObject Victory; // Optional: assign something in the inspector
    private bool triggered = false;

    void Update()
    {
        if (!triggered && BallCounter.Instance.score >= 12)
        {
            triggered = true;
            OnTwelveCollected();
        }
    }

    private void OnTwelveCollected()
    {
        Debug.Log("🎉 Score reached 12!");

        if (Victory != null)
        {
            Victory.SetActive(true);
        }

        // You can also:
        // - Load a new scene
        // - Show a UI element
        // - Play a sound
        // - Trigger animation
    }
}
