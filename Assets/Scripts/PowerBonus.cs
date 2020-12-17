using System.Collections;
using UnityEngine;

public class PowerBonus : MonoBehaviour
{

    // Config parameters
    [SerializeField] float bonusSpawnMinX = 0.5f;
    [SerializeField] float bonusSpawnMaxX = 15.5f;
    [SerializeField] float bonusSpawnY = 12.5f;
    [SerializeField] Vector2 dropForce = new Vector2(0f, -5f);
    [SerializeField] GameObject bonusTrippleBalls = null;
    [SerializeField] string bonusTag = "Bonus";
    [SerializeField] float minSpawnSec = 5f;
    [SerializeField] float maxSpawnSec = 15f;

    void Start()
    {
        float spawnAfter = Random.Range(minSpawnSec, maxSpawnSec);
        StartCoroutine(SpawnBonusAfterDelay(spawnAfter));
    }

    private IEnumerator SpawnBonusAfterDelay(float sec)
    {
        yield return new WaitForSeconds(sec);
        SpawnBonus();
    }

    private void SpawnBonus()
    {
        float spawnXPos = Random.Range(bonusSpawnMinX, bonusSpawnMaxX);
        Vector3 spawnPos = new Vector3(spawnXPos, bonusSpawnY, 0);

        // Add drop force to the bonus
        GameObject bonus3X = Object.Instantiate(bonusTrippleBalls, spawnPos, Quaternion.identity);
        bonus3X.tag = bonusTag;
        bonus3X.GetComponent<Rigidbody2D>().velocity += dropForce;
    }
}
