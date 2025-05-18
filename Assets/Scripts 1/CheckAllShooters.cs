using System.Runtime.CompilerServices;
using UnityEngine;

public class CheckAllShooters : MonoBehaviour
{
    Transform upgrade1;
    Transform upgrade2;
    Transform upgrade3;
    Transform upgrade4;
    Transform baseShooter;

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
        upgrade3.gameObject.SetActive(Islevel.level >= 11);
    }

   public void ShooterOverdrive()
    {
        if (gameObject.GetComponent<PlayerController>().VaastUlt() == true)
        {
            baseShooter.gameObject.GetComponent<Playershoot>().FireRate = 3;
            upgrade1.gameObject.GetComponent<ShooterTiming>().customFireRate = 3;
            upgrade2.gameObject.GetComponent<ShooterTiming>().customFireRate = 3;
            upgrade3.gameObject.GetComponent<ShooterTiming>().customFireRate = 3;
                upgrade4.gameObject.GetComponent<ShooterTiming>().customFireRate=3;
        }
    }
    
        
   
}
