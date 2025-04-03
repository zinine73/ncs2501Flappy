using UnityEngine;

public class AddScore : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.UpdateScore();
        }
    }
}
