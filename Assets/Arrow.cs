using UnityEngine;

public class Arrow : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Destroy(gameObject); 
        }
        else if (other.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
