using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Clone : MonoBehaviour
{
    public GameObject clone;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
        Instantiate(clone, position, clone.transform.rotation);
    }

    private void OnCollisionExit(Collision collision)
    {
        Instantiate(clone, position, clone.transform.rotation);
    }
}
