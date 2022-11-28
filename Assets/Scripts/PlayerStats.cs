using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 250;
    public static int lives = 100;

    public static int rounds;

    private void Start()
    {
        money = startMoney;
        rounds = 0;
    }


}
