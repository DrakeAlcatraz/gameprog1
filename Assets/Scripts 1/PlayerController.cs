using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public PlayerStats PlayerStats;
    [SerializeField] private HealthbarUI Healthbar;
    [SerializeField] private ExpbarUI EXPbar;
    GameObject player;

   



     void Start()
    {
        intitializeUIandStats();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(20); // Press D to take damage
            Healthbar.SetHealthBarSize(PlayerStats.currentHealth);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GainXP(30); // Press X to gain XP (for testing)
        }
    }

    public void TakeDamage(int damage)
    {
        PlayerStats.currentHealth -= damage;
       
        if (PlayerStats.currentHealth < 0) PlayerStats.currentHealth = 0;

        Healthbar.SetHealthBarSize( PlayerStats.currentHealth); // Update health bar here

        Debug.Log("Player Health: " +  PlayerStats.currentHealth);
        if ( PlayerStats.currentHealth <= 0)
        {
        Destroy(player);
        }
    }


    // LEVEL SYSTEM STARTS HERE
    public void GainXP(int amount)
    {
        PlayerStats.xp += amount;
        int overflow = PlayerStats.xp-PlayerStats.xpToNextLevel;
         EXPbar.SetXPtonextLVl(PlayerStats.xpToNextLevel);
        EXPbar.SetXPBarSize(PlayerStats.xp);
        Debug.Log("Gained XP: " + amount + " | Total XP: " + PlayerStats.xp);

        if (PlayerStats.xp >= PlayerStats.xpToNextLevel)
        {
            
            LevelUp(overflow);
           
        }
    }

    public void LevelUp(int xpOverflow)
    {
        if (xpOverflow <= 0)
        {
            PlayerStats.xp = 0;
        }
        else
        {
            PlayerStats.xp = xpOverflow;
        }
  
           PlayerStats.level++;
        
          PlayerStats.xpToNextLevel += 50 * PlayerStats.level / 2; // Increase XP needed next time
    
      
        PlayerStats.attack += 5;
        PlayerStats.Maxhealth += 20;
        PlayerStats.speed += 1;

        EXPbar.SetXPtonextLVl(PlayerStats.xpToNextLevel);
        EXPbar.SetXPBarSize(PlayerStats.xp);
        Debug.Log("LEVEL UP! Now Level " + PlayerStats.level);
        Debug.Log("New Attack Power: " + PlayerStats.attack + ", New Health: " + PlayerStats.Maxhealth);
        

    }

    void intitializeUIandStats()
    {
        EXPbar.SetXPtonextLVl(PlayerStats.xpToNextLevel);
        EXPbar.SetXPBarSize(PlayerStats.xp);
        PlayerStats.ResetStats();
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerStats.currentHealth = PlayerStats.Maxhealth;
        Healthbar.SetMaxHealth(PlayerStats.Maxhealth);
        Healthbar.SetHealthBarSize(PlayerStats.currentHealth);
       
    }

    public int getCurrenthealth()
    {
        return PlayerStats.currentHealth;
    }
    
}