using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 5;
    private int currentHP;

    public Slider healthBar;
    public GameObject losePanel;
    public GameObject winPanel;

    private SpriteRenderer[] spriteRenderers;
    private Color[] originalColors;
    public float flashDuration = 0.1f;

    void Start()
    {
        currentHP = maxHP;
        healthBar.maxValue = maxHP;
        healthBar.value = currentHP;

        // หาทุก SpriteRenderer และเก็บสีดั้งเดิมของแต่ละตัว
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        originalColors = new Color[spriteRenderers.Length];

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            originalColors[i] = spriteRenderers[i].color;
        }

        if (losePanel != null)
        {
            losePanel.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            TakeDamage(1);
            StartCoroutine(FlashRed());
        }
        else if (other.CompareTag("Monster"))
        {
            TakeDamage(2);
            StartCoroutine(FlashRed());
        }
        else if (other.CompareTag("Boss"))
        {
            TakeDamage(3);
            StartCoroutine(FlashRed());
        }
        else if (other.CompareTag("Princess"))
        {
            ShowWinScreen();
        }
    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        healthBar.value = currentHP;

        if (currentHP <= 0)
        {
            ShowLoseScreen();
        }
    }

    void ShowLoseScreen()
    {
        if (losePanel != null)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ShowWinScreen()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    IEnumerator FlashRed()
    {
        // เปลี่ยนทุกชิ้นเป็นสีแดง
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].color = Color.red;
        }

        yield return new WaitForSeconds(flashDuration);

        // คืนค่าทุกชิ้นเป็นสีเดิมของมัน
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].color = originalColors[i];
        }
    }
}
