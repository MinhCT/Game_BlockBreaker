using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minClamp = 1f;
    [SerializeField] float maxClamp = 15f;

    void Update()
    {
        float mouseXPosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        mouseXPosInUnits = Mathf.Clamp(mouseXPosInUnits, minClamp, maxClamp);

        Vector2 paddlePos = new Vector2(mouseXPosInUnits, transform.position.y);
        transform.position = paddlePos;
    }
}
