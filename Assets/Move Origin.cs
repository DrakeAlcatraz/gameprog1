using UnityEngine;

public class Move : MonoBehaviour
{
    Transform origin;
    float OriginMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
        private void SetFlip(){
         Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
        if(mousePos.x<=origin.position.x)
        {
           float originInitial= origin.position.x;
            OriginMove = origin.position.x-(origin.position.x *2);
            origin.transform.Translate(originInitial-OriginMove,0,0);
        } else if(mousePos.x>transform.position.x)

        {
            OriginMove=0;
        }
    }
    
    }


