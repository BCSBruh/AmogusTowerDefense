using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackNShoot : MonoBehaviour
{
    [SerializeField] Transform[] enemy = new Transform[10];

    [SerializeField] bool inCollider = false;

    [SerializeField] int i = 0;
    [SerializeField] int j = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inCollider)
        {
            transform.LookAt(enemy[0]);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Here");
        inCollider = true;
        enemy[i] = collision.gameObject.transform;
        i++;
        if (j > 0)
        {
            j--;
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        enemy[j] = null;
        j++;
        i--;

        if (i == 0)
        {
            inCollider = false;
        }
    }
}
