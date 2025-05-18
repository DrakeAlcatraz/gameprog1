using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public PlayerStats PlayerStats;
    [SerializeField] private HealthbarUI Healthbar;
    [SerializeField] private ExpbarUI EXPbar;
    [SerializeField] private UltBar UltBar;
    GameObject player;
  bool isActiveAndEnabled;

private bool isUltActive = false;
private float ultTimer = 0f;



    void Start()
    {
        intitializeUIandStats();
    }

    void Update()
    {
        if (isUltActive)
          {
              ultTimer -= Time.deltaTime;
                if (ultTimer <= 0)
                   {
                       isUltActive = false;
                       gameObject.GetComponent<CheckAllShooters>().ShooterOverdrive(false);
                       Debug.Log("Ult ended");
                 }
}

        float UltperSecgain = PlayerStats.passiveUltGain();
        PlayerStats.UltCharge += UltperSecgain * Time.deltaTime;
        UltBar.SetUltCharge(PlayerStats.UltChargeMax);
        UltBar.SetUltBarsize(PlayerStats.UltCharge);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(20); // Press D to take damage
            Healthbar.SetHealthBarSize(PlayerStats.currentHealth);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GainXP(30); // Press X to gain XP (for testing)
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ChargeUlt(PlayerStats.UltChargeMax);
        }
     if (Input.GetKeyDown(KeyCode.Space) && PlayerStats.UltCharge >= PlayerStats.UltChargeMax)
           {
             Debug.Log("Ult activated");
            isUltActive = true;
            ultTimer = PlayerStats.UltDuration; 
             PlayerStats.UltCharge = 0;
             UltBar.SetUltBarsize(PlayerStats.UltCharge);
            gameObject.GetComponent<CheckAllShooters>().ShooterOverdrive(true);
}

    }

    public void TakeDamage(int damage)
    {
        PlayerStats.currentHealth -= damage;

        if (PlayerStats.currentHealth < 0) PlayerStats.currentHealth = 0;

        Healthbar.SetHealthBarSize(PlayerStats.currentHealth); 

        Debug.Log("Player Health: " + PlayerStats.currentHealth);
        if (PlayerStats.currentHealth <= 0)
        {
            Destroy(player);
        }
    }


    // LEVEL SYSTEM STARTS HERE
    public void GainXP(float amount)
    {
        PlayerStats.xp += amount;
        float overflow = PlayerStats.xp - PlayerStats.xpToNextLevel;
        EXPbar.SetXPtonextLVl(PlayerStats.xpToNextLevel);
        EXPbar.SetXPBarSize(PlayerStats.xp);
        Debug.Log("Gained XP: " + amount + " | Total XP: " + PlayerStats.xp);

        if (PlayerStats.xp >= PlayerStats.xpToNextLevel)
        {

            LevelUp(overflow);

        }
    }

    public void LevelUp(float xpOverflow)
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

        PlayerStats.xpToNextLevel += 50 * PlayerStats.level / 2;

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
        UltBar.SetUltCharge(PlayerStats.UltChargeMax);
        UltBar.SetUltBarsize(PlayerStats.UltCharge);
        EXPbar.SetXPtonextLVl(PlayerStats.xpToNextLevel);
        EXPbar.SetXPBarSize(PlayerStats.xp);
        PlayerStats.ResetStats();
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerStats.currentHealth = PlayerStats.Maxhealth;
        Healthbar.SetMaxHealth(PlayerStats.Maxhealth);
        Healthbar.SetHealthBarSize(PlayerStats.currentHealth);

    }

    public bool ChargeUlt(float UltChargeGain)
    {
        bool UltCharged;

        PlayerStats.UltCharge += UltChargeGain;
        UltBar.SetUltCharge(PlayerStats.UltChargeMax);
        UltBar.SetUltBarsize(PlayerStats.UltCharge);
        if (PlayerStats.UltCharge >= PlayerStats.UltChargeMax)
        {
            PlayerStats.UltCharge = PlayerStats.UltChargeMax;
            UltCharged = true;
            Debug.Log("ult is charged.");
        }
        else
        {

            UltCharged = false;
        }
        return UltCharged;
    }

    public bool VaastUlt()
    {
      
        if (ChargeUlt(0) == true)
        {
            Debug.Log("Ult Used");
            isActiveAndEnabled = true;
        }
        else if (PlayerStats.UltDuration <=0)
        {
            Debug.Log("Not yet");
            isActiveAndEnabled = false;
        }
        return isActiveAndEnabled;
        
    }
    
    
}