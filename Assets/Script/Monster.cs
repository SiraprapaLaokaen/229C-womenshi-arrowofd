using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Monster : MonoBehaviour
{
    
    public int maxHP = 2;
    private int currentHP;

    public float flashDuration = 0.1f;

    private SpriteRenderer[] spriteRenderers;
    private Color[] originalColors;

    private HashSet<Collider2D> arrowsInside = new HashSet<Collider2D>();

    void Start()
    {
        currentHP = maxHP;

        // ดึง SpriteRenderer ทุกตัว (รวมลูกๆ)
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        originalColors = new Color[spriteRenderers.Length];
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            originalColors[i] = spriteRenderers[i].color;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow") && !arrowsInside.Contains(other))
        {
            TakeDamage(1);
            arrowsInside.Add(other);
            StartCoroutine(FlashRed()); // แค่กระพริบสีแดง
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
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

    IEnumerator FlashRed()
    {
        // เปลี่ยนทุก SpriteRenderer เป็นสีแดง
        foreach (var sr in spriteRenderers)
        {
            sr.color = Color.red;
        }

        yield return new WaitForSeconds(flashDuration);

        // คืนค่าสีเดิม
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].color = originalColors[i];
        }
    }
}
