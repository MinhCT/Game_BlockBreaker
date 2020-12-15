using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] Paddle paddle1 = null;
    [SerializeField] Vector2 launchVelocity = new Vector2(1f, 1f);
    [SerializeField] AudioClip[] ballSounds = null;
    [SerializeField] float randomFactor = 0.2f;

    // State variables
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached references
    AudioSource ballAudioSource;
    Rigidbody2D ballRigidbody2D;

    void Start()
    {
        ballAudioSource = GetComponent<AudioSource>();
        ballRigidbody2D = GetComponent<Rigidbody2D>();
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ballRigidbody2D.velocity = launchVelocity;
            hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0, randomFactor),
            Random.Range(0, randomFactor)
        );
        if (hasStarted)
        {
            HandleBallSounds();
            ballRigidbody2D.velocity += velocityTweak;
        }
    }

    private void HandleBallSounds()
    {
        if (ballSounds != null && ballSounds.Length != 0)
        {
            AudioClip ballSound = ballSounds[Random.Range(0, ballSounds.Length)];
            ballAudioSource.PlayOneShot(ballSound);
        }
        else
        {
            Debug.LogError("No sound clips has been assigned to game object: [" + name + "]");
        }
    }
}
