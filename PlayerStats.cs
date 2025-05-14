using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private HealthbarUI Healthbar;
    public int Maxhealth = 100;
    public int currentHealth;
    public int attackPower = 10;

    public int level = 1;
    public int xp = 0;
    public int xpToNextLevel = 100;
    public int damagetaken = 20;

    private void Start()
    {
        currentHealth = Maxhealth;
        Healthbar.SetMaxHealth(Maxhealth);
        Healthbar.SetHealthBarSize(currentHealth); // Initialize bar size
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(20); // Press D to take damage
            Healthbar.SetHealthBarSize(currentHealth);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GainXP(50); // Press X to gain XP (for testing)
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        Healthbar.SetHealthBarSize(currentHealth); // Update health bar here

        Debug.Log("Player Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Attack()
    {
        Debug.Log("Player attacks with " + attackPower + " damage.");
    }

    private void Die()
    {
        Debug.Log("Player has died.");
    }

    // LEVEL SYSTEM STARTS HERE
    public void GainXP(int amount)
    {
        xp += amount;
        Debug.Log("Gained XP: " + amount + " | Total XP: " + xp);

        if (xp >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level++;
        xp = 0;
        xpToNextLevel += 50; // Increase XP needed next time
        attackPower += 5;
        Maxhealth += 20;

        Debug.Log("LEVEL UP! Now Level " + level);
        Debug.Log("New Attack Power: " + attackPower + ", New Health: " + Maxhealth);
    }

    public int getCurrenthealth()
    {
        return currentHealth;
    }
    void SetCurrentHealth(int newCurrentHealth)
    {
        currentHealth += newCurrentHealth;
    }
}