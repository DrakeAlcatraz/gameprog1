using UnityEngine;
using System.Collections;
public class EnemyHItLogic : MonoBehaviour
{
    public EnemyStats stats;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashDuration = 0.3f;

    void Start()
    {
        stats.setstats();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    public void TakeDamage(float damage)
    {
        stats.Health -= damage;
        Debug.Log("Enemy took damage! Remaining HP: " + stats.Health);

       
            StartCoroutine(FlashWhite());
        

        if (stats.Health <= 0)
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
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GainXP(stats.ExpYield);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChargeUlt(stats.UltChargeYield);
        Destroy(gameObject);
    }
}
