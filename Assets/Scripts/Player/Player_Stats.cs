using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{

    float MaxHP = 200;
    float HP = 40;
    float Attack = 1;
    float Defense = 0;
    int money=0;
    void Update()
    {
        if (Input.GetKey("t")) { HP++; }
        if (Input.GetKey("g")) { HP--; }
        if (HP > MaxHP) { HP = MaxHP; }
        if (HP < 0) { HP = 0; }
    }

    public float GetHP()
    {
        
        return HP;
    } 
    public float GetMaxHP()
    {
        return MaxHP;
    }

    public float GetAttack()
    {
        return Attack;
    }
    public float GetDefense()
    {
        return Defense;
    }

    public int GetMoney() { return money; }
    public void SetMoney(int amount) { money = amount; }

}  
