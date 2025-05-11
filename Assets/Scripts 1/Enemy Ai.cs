using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private GameObject Player;
    public int MoveSpeed;
  
    void Start()
    {
     Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, MoveSpeed*Time.deltaTime);
    }
}


