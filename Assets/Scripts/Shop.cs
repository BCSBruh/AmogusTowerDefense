using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint turret1;
    public TurretBlueprint turret2;
    public TurretBlueprint turret3;

    public Vector3 spawnPos = new Vector3(0.93f, 0.19f, -9.18f);
    public void PurchaseLvl1Turret()
    {
        Debug.Log("Standard Turret Purchased");
        bool canBuy = checkPurchasable(turret1);
        if (canBuy)
            Instantiate(turret1.prefab, spawnPos, Quaternion.identity);

        Debug.Log("Money left = " + PlayerStats.money);
    }

    public void PurchaseLvl2Turret()
    {
        Debug.Log("Level 2 Turret Purchased");
    }

    public void PurchaseLvl3Turret()
    {
        Debug.Log("Level 3 Turret Purchased");
    }

    private bool checkPurchasable(TurretBlueprint turret)
    {
        if (PlayerStats.money < turret.cost)
        {
            return false;
        } else
        {
            PlayerStats.money -= turret.cost;
            return true;
        }
    }
}
