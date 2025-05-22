using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class LevelUpButton1 : MonoBehaviour
{
    public TMP_Text weaponDescription;


    private Weapons dagger;

    public void ActivateButton(Weapons weapons)
    {
        weaponDescription.text = weapons.stats[weapons.weaponLevel].weaponDescription;
        dagger = weapons;
    }

    public void SelectedUpgrade()
    {
        if (dagger.weaponLevel >= dagger.stats.Count - 1)
        {
            Debug.Log("level up shhoter");
            dagger.DaggerLevelup();
            gameObject.SetActive(false);
            PanelController.instance.closeLevelUpPanel();
        }
        else
        {
                Debug.Log("level up shhoter");
            dagger.DaggerLevelup();
            PanelController.instance.closeLevelUpPanel();
        }
    }



}
