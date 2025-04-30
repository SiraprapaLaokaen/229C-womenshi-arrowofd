using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Monster : MonoBehaviour
{
    public int maxHP = 2;
    private int currentHP;

    // เก็บลูกศรที่กำลังอยู่ใน Trigger ตอนนี้
    private HashSet<Collider2D> arrowsInside = new HashSet<Collider2D>();

    void Start()
    {
        currentHP = maxHP;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow") && !arrowsInside.Contains(other))
        {
            TakeDamage(1);
            arrowsInside.Add(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Arrow") && arrowsInside.Contains(other))
        {
            arrowsInside.Remove(other);
        }
    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Monster HP: " + currentHP);

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
