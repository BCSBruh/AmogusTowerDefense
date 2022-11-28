using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUI : MonoBehaviour
{
    public GameObject turret;
    public void selllvl1Turret()
    {
        PlayerStats.money += 50;
        Destroy(turret);
    }

    public void selllvl2Turret()
    {
        PlayerStats.money += 100;
        Destroy(turret);
    }

    public void selllvl3Turret()
    {
        PlayerStats.money += 200;
        Destroy(turret);
    }
}
