using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Enemy : MonoBehaviour
{
    public GameObject coin;
    public Rigidbody2D rb;
    public int MoneyValueMin = 1;
    public int MoneyValueMax = 10;
    public int CoinsAmountMin = 1;
    public int CoinsAmountMax = 5;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.name.Contains("Player"))
        {
            SpawnMonets(Random.Range(CoinsAmountMin, CoinsAmountMax));
            Destroy(gameObject);
        }
    }

    void SpawnMonets(int amount)
    {
        for (int a = 0; a < amount; a++)
        {
            GameObject CoinTMP = Instantiate(coin, rb.position, Quaternion.identity) as GameObject;
            CoinTMP.GetComponent<Coin>().SetValue(Random.Range(MoneyValueMin, MoneyValueMax));
        }
    }



}
