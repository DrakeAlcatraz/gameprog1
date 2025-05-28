using System;

using UnityEngine;

public class Move : MonoBehaviour

{
    public PlayerStats stats;
   private SpriteRenderer _spriteRenderer;
       private Animator animator;

         void Awake()
    {
        animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }



    void Update()
    {
      Movement();
    }

    void FixedUpdate()
    {
        SetFlip();
        animator.SetFloat("Movex", Input.GetAxis("Horizontal"));
        animator.SetFloat("Movey", Input.GetAxis("Vertical"));
    }

    private float testHor(Vector2 dir) {
        Vector2 origin = transform.position;
        float offset;
        if (dir.Equals(Vector2.left)) {
            offset = -0.125f; // Offset for left side of character
        } else {
            offset = 0.125f; // Offset for right side of character
        }
            origin.x += offset;
        RaycastHit2D raycast = Physics2D.Raycast(origin, dir, stats.speed * Time.deltaTime);

        if(raycast.collider != null && raycast.collider.gameObject.tag == "Collidable") { // If raycast hits something tagged "Collidable"
            float distance = Math.Abs(raycast.point.x - origin.x);
            return distance;
        }

        return stats.speed * Time.deltaTime;
    }

    private float testVert(Vector2 dir) {
        Vector2 origin = transform.position;
        float offset;
        if (dir.Equals(Vector2.up)) {
            offset = .1f; // Offset for top side of character
        } else {
            offset = -0.5f; // Offset for bottom side of character
        }
        origin.y += offset;
        RaycastHit2D raycast = Physics2D.Raycast(origin, dir, stats.speed * Time.deltaTime);

        if (raycast.collider != null && raycast.collider.gameObject.tag == "Collidable") { // If raycast hits something tagged "Collidable"
            float distance = Math.Abs(raycast.point.y - origin.y);
            return distance;
        }

        return stats.speed * Time.deltaTime;
    }
private void SetFlip(){
         Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
        if(mousePos.x<transform.position.x){
            _spriteRenderer.flipX=true;
        }else if(mousePos.x>transform.position.x){
         _spriteRenderer.flipX=false;
        }
    }

    void Movement(){
         if(Input.GetKey(KeyCode.W)) { // Controls movements in all four directions
            transform.Translate(Vector2.up * testVert(Vector2.up));
        }
        if(Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector2.left * testHor(Vector2.left));
        
        }
        if(Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector2.down * testVert(Vector2.down));
        } 
        if(Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector2.right * testHor(Vector2.right));
            
        }

    }
    
}