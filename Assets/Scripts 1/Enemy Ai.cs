
using UnityEngine;

public class AIController : MonoBehaviour
{
    private GameObject Player;
    public float MoveSpeed;
    public EnemyStats stats;
    void Start()
    {
        stats.setstats();
        MoveSpeed = stats.Speed;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, MoveSpeed * Time.deltaTime);
    }
    
    
}


