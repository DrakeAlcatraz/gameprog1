using UnityEngine;

public class BigEnemyAI : MonoBehaviour
{
   private GameObject Player;
    public float MoveSpeed;
    public StrongerEnemyStats stats;
    void Start()
    {
        stats.setbigStats();
        MoveSpeed = stats.bigSpeed;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, MoveSpeed * Time.deltaTime);
    }
    
}
