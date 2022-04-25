using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_UI : MonoBehaviour
{
    public Image HealthImageFill;
    public TextMeshProUGUI HealthText;
    public Player_Stats player_stats;

    void Update()
    {
        HealthImageFill.fillAmount = (player_stats.GetHP() / player_stats.GetMaxHP());
        HealthText.text = player_stats.GetHP().ToString() + "/" + player_stats.GetMaxHP().ToString();
    }

}  
  