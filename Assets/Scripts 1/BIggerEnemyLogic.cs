using UnityEngine;
using System.Collections;

public class BIggerEnemyLogic : MonoBehaviour
{
       public StrongerEnemyStats stats;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashDuration = 0.3f;

    void Start()
    {
        stats.setbigStats();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    public void bigTakeDamage(float damage)
    {
        stats.bigHealth -= damage;
        Debug.Log("Enemy took damage! Remaining HP: " + stats.bigHealth);
        StartCoroutine(FlashWhite());
       

        if (stats.bigHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator FlashWhite()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(flashDuration*Time.deltaTime);
        spriteRenderer.color = originalColor;
    }

    public void Die()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GainXP(stats.bigExpYield);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChargeUlt(stats.bigUltChargeYield);
        Destroy(gameObject);
    }
}
