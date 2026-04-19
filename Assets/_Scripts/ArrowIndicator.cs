using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distanceFromPlayer = 1.2f;

    void Update()
    {
        GameObject currentCandy = GameObject.FindGameObjectWithTag("Coletavel");

        if (player == null || currentCandy == null)
        {
            return;
        }

        Vector3 direction = (currentCandy.transform.position - player.position).normalized;

        transform.position = player.position + direction * distanceFromPlayer;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}