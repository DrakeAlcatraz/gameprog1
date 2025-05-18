using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CheckAllShooters : MonoBehaviour
{
    Transform upgrade1;
    Transform upgrade2;
    Transform upgrade3;
    Transform upgrade4;
    Transform baseShooter;
    bool OverdriveIsActive = false;

    [SerializeField] PlayerStats Islevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindAllShooters();
        disableAllShooters();
    }

    // Update is called once per frame
    void Update()
    {
        checkShooterLvlReq();
    }

    void FindAllShooters()
    {
        baseShooter = transform.Find("Shooter");
        upgrade1 = transform.Find("ShooterUpgrade1");
        upgrade2 = transform.Find("ShooterUpgrade2");
        upgrade3 = transform.Find("ShooterUpgrade3");
        upgrade4 = transform.Find("ShooterUpgrade4");
    }

    void disableAllShooters()
    {
        upgrade1.gameObject.SetActive(false);
        upgrade2.gameObject.SetActive(false);
        upgrade3.gameObject.SetActive(false);
        upgrade4.gameObject.SetActive(false);
    }

    void checkShooterLvlReq()
    {
        upgrade1.gameObject.SetActive(Islevel.level >= 2);
        upgrade2.gameObject.SetActive(Islevel.level >= 5);
        upgrade3.gameObject.SetActive(Islevel.level >= 8);
        upgrade4.gameObject.SetActive(Islevel.level >= 11);
    }

   public void ShooterOverdrive(bool enable)
{
    if (enable)
    {
        if (!OverdriveIsActive)
        {
            OverdriveIsActive = true;
            Debug.Log("Shooter Overdrive Activated");
            baseShooter.gameObject.GetComponent<Playershoot>().nextfire = 0.05f;
            upgrade1.gameObject.GetComponent<ShooterTiming>().customFireDelay = 0.05f;
            upgrade2.gameObject.GetComponent<ShooterTiming>().customFireDelay = 0.05f;
            upgrade3.gameObject.GetComponent<ShooterTiming>().customFireDelay = 0.05f;
            upgrade4.gameObject.GetComponent<ShooterTiming>().customFireDelay = 0.05f;
        }
    }
    else
    {
        if (OverdriveIsActive)
        {
            OverdriveIsActive = false;
            Debug.Log("Shooter Overdrive Ended");
            baseShooter.gameObject.GetComponent<Playershoot>().nextfire = baseShooter.gameObject.GetComponent<Playershoot>().defaultFireDelay;
            upgrade1.gameObject.GetComponent<ShooterTiming>().customFireDelay = upgrade1.gameObject.GetComponent<ShooterTiming>().customDefault;
            upgrade2.gameObject.GetComponent<ShooterTiming>().customFireDelay = upgrade2.gameObject.GetComponent<ShooterTiming>().customDefault;
            upgrade3.gameObject.GetComponent<ShooterTiming>().customFireDelay = upgrade3.gameObject.GetComponent<ShooterTiming>().customDefault;
            upgrade4.gameObject.GetComponent<ShooterTiming>().customFireDelay = upgrade4.gameObject.GetComponent<ShooterTiming>().customDefault;
        }
    }
}

   
}
