using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int Maxhealth = 100;
    public int currentHealth;
    public int attack = 10;

    public int level = 1;
    public int xp = 0;
    public int xpToNextLevel = 100;
    public int damagetaken = 20;

    public int speed = 5;
    public float UltCharge = 0f;
    public float UltChargeMax = 200f;
    public float UltDuration = 10.0f;

    public void ResetStats()

    {
        Maxhealth = 100;
        attack = 10;
        level = 1;
        xp = 0;
        xpToNextLevel = 100;
        damagetaken = 20;
        speed = 5;
        currentHealth = Maxhealth;
        UltCharge = 0;
        UltChargeMax = 200f;
    }

    public float passiveUltGain()
    {
        float UltPerSec=UltChargeMax/120;
          
        return UltPerSec;
    }

}


