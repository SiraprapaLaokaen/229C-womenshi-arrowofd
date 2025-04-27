using UnityEngine;

public class Monster : MonoBehaviour
{
    public int maxHP = 2;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP; 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            TakeDamage(1); //ลดเลือด
        }
    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Monster HP: " + currentHP);

        if (currentHP <= 0)
        {
            Destroy(gameObject); // ทำลายMonster
        }
    }
}
