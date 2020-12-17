using System.Collections;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float secsToSelfDestruct = 2f;

    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    void Update()
    {
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(secsToSelfDestruct);
        Destroy(gameObject);
    }
}
