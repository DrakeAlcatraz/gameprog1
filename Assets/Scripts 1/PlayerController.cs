using System.Collections;
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

    public PanelController panelController;
    GameObject player;
     bool isUlting;

private bool isUltActive = false;
    private float ultTimer = 0f;
     [SerializeField] Weapons weapons;
       [SerializeField] Weapons Shooter;

    [SerializeField] Weapons Ultimate;


    void OnEnable()
    {
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    
    void Start()
    {
        Ultimate.ultimateLvl = 0;
        Shooter.shooterLevel = 0;
        weapons.weaponLevel = 0;
        gameObject.SetActive(true);
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
            ultTimer = PlayerStats.UltDuration+Ultimate.overdriveStats[Ultimate.ultimateLvl].additionalUltDuration; 
             PlayerStats.UltCharge = 0;
             UltBar.SetUltBarsize(PlayerStats.UltCharge);
            gameObject.GetComponent<CheckAllShooters>().ShooterOverdrive(true);
}

    }

    public void TakeDamage(float damage)
    {
        if (PlayerStats.currentHealth > 0)
        {
            PlayerStats.currentHealth -= damage;
            StartCoroutine(Iframe());
        }
       

        if (PlayerStats.currentHealth < 0) PlayerStats.currentHealth = 0;

        Healthbar.SetHealthBarSize(PlayerStats.currentHealth); 

        Debug.Log("Player Health: " + PlayerStats.currentHealth);
        if (PlayerStats.currentHealth <= 0)
        {
          gameObject.SetActive(false);
            panelController.GameOver();
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
    if (collision.CompareTag("Enemy"))
    {
            float Damage = collision.GetComponent<EnemyHItLogic>().stats.attack;
            TakeDamage(Damage);
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
        PlayerStats.xpToNextLevel += 30 * PlayerStats.level / 2;
        PlayerStats.attack += 5;
        PlayerStats.Maxhealth += 20;
        PlayerStats.speed += 1;

        EXPbar.SetXPtonextLVl(PlayerStats.xpToNextLevel);
        EXPbar.SetXPBarSize(PlayerStats.xp);
         panelController.levelUpButtons[0].ActivateButton(weapons);
        panelController.levelUpButtons2[0].ActivateButton(Shooter);
        

         if (PlayerStats.level % 5 == 0 && Ultimate.ultimateLvl < Ultimate.overdriveStats.Count - 1)
        {
            panelController.levelUpbutton3rd[0].gameObject.SetActive(true);
            panelController.levelUpbutton3rd[0].ActivateButton(Ultimate);
        }
        else
        {
            panelController.levelUpbutton3rd[0].gameObject.SetActive(false);
        }
        panelController.OpenLevelUpPanel();
       

    }

    void intitializeUIandStats()
    {
           PlayerStats.ResetStats();
        UltBar.SetUltCharge(PlayerStats.UltChargeMax);
        UltBar.SetUltBarsize(PlayerStats.UltCharge);
        EXPbar.SetXPtonextLVl(PlayerStats.xpToNextLevel);
        EXPbar.SetXPBarSize(PlayerStats.xp);
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
            isUlting = true;
        }
        else if (PlayerStats.UltDuration <=0)
        {
            Debug.Log("Not yet");
            isUlting = false;
        }
        return isUlting;
        
    }

    private IEnumerator Iframe()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSecondsRealtime(0.3f);
        Physics2D.IgnoreLayerCollision(6, 7, false);
  }
}