using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Stats_UI : MonoBehaviour
{

    public Player_Stats Player_Stats;
    public Canvas InGame;
    public Canvas Stats;
    public Player_Keyboard Player_Keyboard;

    public TextMeshProUGUI Mesh_Attack;
    public TextMeshProUGUI Mesh_Defense;
    public TextMeshProUGUI Mesh_Money;

    public Button ToggleInv;

    bool toggling_blockade = false;

    void Start()
    {
        Stats.enabled = false;
        Button btn = ToggleInv.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {

        Mesh_Attack.text = "Attack: " + Player_Stats.GetAttack().ToString();
        Mesh_Defense.text = "Defense: " + Player_Stats.GetDefense().ToString();
        Mesh_Money.text = "Money: " + Player_Stats.GetMoney().ToString();
    }

    void TaskOnClick()
    {
        if (toggling_blockade == false)
        {
            Player_Keyboard.SetKeyboard(!Player_Keyboard.GetKeyboard());
            StartCoroutine(ExampleCoroutine());
            InGame.enabled = !InGame.enabled;
            Stats.enabled = !Stats.enabled;
            toggling_blockade = true;
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        toggling_blockade = false;
    }

}
