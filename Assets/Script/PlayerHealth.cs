using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 5;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP; 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            TakeDamage(1); //ลดเลือด
        }

        else if (other.CompareTag("Monster"))
        {
            TakeDamage(2); //ลดเลือด
        }
    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Player HP: " + currentHP);

        if (currentHP <= 0)
        {
            Destroy(gameObject); // ทำลายผู้เล่น
        }
    }
}
