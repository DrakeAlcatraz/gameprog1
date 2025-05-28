using System.Collections.Generic;
using UnityEngine;


public class Weapons : MonoBehaviour
{
    public int weaponLevel;
    public int shooterLevel;
    public int ultimateLvl;
    public List<Dagger> stats;
    public List<Shooter> ShooterStats;
    public List<Overdrive> overdriveStats;

    public void DaggerLevelup()
    {
        if (weaponLevel < stats.Count - 1) { weaponLevel++; }
    }

    public void ShooterLevelUP()
    {
        if (shooterLevel < ShooterStats.Count - 1)
        {
            shooterLevel++;

            foreach (var shooter in shooterScripts)
            {
                shooter.UpdateAdjustedNextfire();
            }
        }
    }

    public void UltimateLevelUp()
    {
        if (ultimateLvl < overdriveStats.Count)
        {
            ultimateLvl++;
        }
    }



    void Awake()
    {
        weaponLevel = 0;
        shooterLevel = 0;
    }


public List<ShooterTiming> shooterScripts = new List<ShooterTiming>();

public void RegisterShooter(ShooterTiming shooter)
{
    if (!shooterScripts.Contains(shooter))
        shooterScripts.Add(shooter);
}

}

[System.Serializable]
public class Dagger
{

    public float baseAttack = 2;
    public float pierceCount = 2;
    public string weaponDescription;
      

}

[System.Serializable]
public class Shooter
{

    public float nextfire;
    public string weaponDescription;


}

[System.Serializable]
public class Overdrive {
    public int additionalUltDuration;
    public string description;
}