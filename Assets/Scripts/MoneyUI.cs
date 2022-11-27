using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI lifeText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = PlayerStats.money.ToString();
        lifeText.text = PlayerStats.lives.ToString();
    }
}
