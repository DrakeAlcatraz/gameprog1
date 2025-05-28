using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float Maxhealth = 100;
    public float currentHealth;
    public float attack = 10;

    public int level = 1;
    public float xp = 0;
    public float xpToNextLevel = 100;
    public float damagetaken = 20;

    public float speed;
    public float UltCharge = 0f;
    public float UltChargeMax = 200f;
    public float UltDuration = 4f;
   

    public void ResetStats()

    {
        Maxhealth = 100;
        attack = 20;
        level = 1;
        xp = 0;
        xpToNextLevel = 100;
        damagetaken = 20;
        speed = 7;
        currentHealth = Maxhealth;
        UltCharge = 0;
        UltChargeMax = 200f;
        UltDuration = 4f;
      
    }

    public float passiveUltGain()
    {
        float UltPerSec=UltChargeMax/120;
          
        return UltPerSec;
    }

}


