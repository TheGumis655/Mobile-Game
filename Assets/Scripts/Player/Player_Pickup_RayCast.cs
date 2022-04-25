using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Pickup_RayCast : MonoBehaviour
{
    public Rigidbody2D rb;

    //Raycast
    public float Raycast_Distance = 20f;
    public float Raycast_Offset = 0.12f;
    public float Raycast_Amount = 20;
    public new Collider2D collider;
    public Player_Stats Player_Stats;

    void FixedUpdate()
    {
        

        Vector2 RayStartPosition = rb.position;
        RayStartPosition.y = rb.position.y - Raycast_Offset;

        float angle = 0;
        for (float a = 0; a < Raycast_Amount; a++)
        {
            angle += 2 * Mathf.PI / Raycast_Amount;

            float x = Mathf.Sin(angle) ;
            float y = Mathf.Cos(angle) ;
            
            Vector3 dir = new Vector3(x ,  y , 0);

            RaycastHit2D hit = Physics2D.Raycast(RayStartPosition, dir, Raycast_Distance);
            Debug.DrawRay(RayStartPosition, dir * Raycast_Distance, Color.red);
            if (hit.collider != null)
            {
                if(hit.collider.name.Contains("Coin"))
                {
                    Coin coin;
                    coin = hit.collider.GetComponent<Coin>();
                    
                    hit.collider.attachedRigidbody.AddForce(-dir*10);
                    if (hit.collider.attachedRigidbody.IsTouching(collider)) 
                    {
                        Player_Stats.SetMoney(Player_Stats.GetMoney()+ coin.GetValue());
                        coin.Destroy();
                    }
                }
                
            }

        }
    }
}
