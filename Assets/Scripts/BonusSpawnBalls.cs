using UnityEngine;

public class BonusSpawnBalls : MonoBehaviour
{
    // Config parameters
    [SerializeField] GameObject spawnBall = null;
    [SerializeField] int numSpawns = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MainPaddle"))
        {
            Destroy(gameObject);
            CreateSpawnBalls();
        }
    }

    private void CreateSpawnBalls()
    {
        Ball mainBall = FindObjectOfType<Ball>();
        for (int i = 0; i < numSpawns; i++)
        {
            GameObject sBall = Instantiate(spawnBall, mainBall.transform.position, mainBall.transform.rotation);
            Physics2D.IgnoreCollision(sBall.GetComponent<Collider2D>(), mainBall.GetComponent<Collider2D>());
            sBall.GetComponent<Rigidbody2D>().velocity += new Vector2(Random.Range(1, 10), Random.Range(10, 14));
        }
    }
}
