using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
     public int maxHP = 5;
    private int currentHP;

    public Slider healthBar;
    public GameObject losePanel;

    void Start()
    {
        currentHP = maxHP;
        healthBar.maxValue = maxHP;
        healthBar.value = currentHP;

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
        }
        else if (other.CompareTag("Monster"))
        {
            TakeDamage(2);
        }
        else if (other.CompareTag("Boss"))
        {
            TakeDamage(3);
        }
    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        healthBar.value = currentHP;
        Debug.Log("Player HP: " + currentHP);

        if (currentHP <= 0)
        {
            ShowLoseScreen();
            Destroy(gameObject);
        }
    }

    void ShowLoseScreen()
    {
        if (losePanel != null)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0f; // หยุดเกมชั่วคราว
        }
    }

    // ฟังก์ชันนี้จะถูกเรียกตอนกดปุ่ม Retry
    public void RetryGame()
    {
        Time.timeScale = 1f; // คืนเวลา
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // โหลดฉากปัจจุบันใหม่
    }
}
