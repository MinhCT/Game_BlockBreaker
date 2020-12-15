using UnityEngine;

public class Block : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] AudioClip breakSound = null;
    [SerializeField] GameObject blockSparklesVFX = null;
    [SerializeField] Sprite[] hitSprites = null;
    [SerializeField] float sparklesDestroySec = 2f;

    // Cached references
    Level level;
    GameSession gameStatus;

    // State variables
    int timesHit;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (CompareTag("Breakable"))
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Breakable"))
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        level.BlockDestroyed();
        TriggerSparklesVFX();

        Destroy(gameObject);
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites != null && hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Some block sprites are missing from array. Name: [" + name + "]");
        }
    }

    private void PlayBlockDestroySFX()
    {
        gameStatus.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, sparklesDestroySec);
    }
}
