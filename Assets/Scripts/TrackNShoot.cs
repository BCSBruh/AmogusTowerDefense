using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackNShoot : MonoBehaviour
{
    [SerializeField] GameObject pylon;
    [SerializeField] GameObject radius;
    [SerializeField] GameObject enemy;

    [SerializeField] bool inCollider = false;
    // Start is called before the first frame update
    void Start()
    {
        pylon = transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        radius = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //pylon.transform.LookAt(enemy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
