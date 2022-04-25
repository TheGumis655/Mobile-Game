using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float StartVelocity=30;
    public Rigidbody2D rb;

    int value=1;
    public void SetValue(int Value){ value = Value;}
    public int GetValue(){ return value;}
    public void Destroy() { Destroy(gameObject); } 

    private void Update()
    {
        rb.velocity += -rb.velocity/5;
    }

    private void Start()
    {
        rb.AddForce(new Vector2(Random.Range(StartVelocity*-1, StartVelocity), Random.Range(StartVelocity*-1, StartVelocity)));
        StartCoroutine(WaitToRay());
    }

    IEnumerator WaitToRay()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.layer = 20;
       
    }

}
