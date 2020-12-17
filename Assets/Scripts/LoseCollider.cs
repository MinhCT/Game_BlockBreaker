using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MainBall"))
        {
            SceneManager.LoadScene("Game Over");
        }
        else if (collision.gameObject.CompareTag("Bonus"))
        {
            // Destroy the bonus object to save resources
            Destroy(collision.gameObject, 1f);
        }
    }
}
