using UnityEngine;

public class ShooterCheck : MonoBehaviour

{

    public virtual void Shooter(){
        Debug.Log("Working1");        
    }

}

public class ShooterCheckSub : ShooterCheck{
    public override void Shooter()
    {
        Debug.Log("Wokring2");
    }

    void Update()
    {
        base.Shooter();
        Shooter();
    }
}
