using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;             // เก็บตำแหน่งของ Player
    public float moveSpeed = 2f;          // ความเร็วของศัตรู
    public float detectionRange = 5f;     // ระยะตรวจจับ

    void Start()
    {
        GameObject playerObj = GameObject.Find("PlayerCharacter");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("PlayerCharacter not found in the scene.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance <= detectionRange)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
            }
        }
    }
}
