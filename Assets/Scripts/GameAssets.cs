using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null)
                _i = Instantiate(Resources.Load<GameAssets>("Game Assets"));
            return _i;
        }
    }

    public Transform Laser;
}
