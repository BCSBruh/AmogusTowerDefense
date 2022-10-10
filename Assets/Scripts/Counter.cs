using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    
    public TextMeshProUGUI CounterText;

    public int Count = 0;

    // Start is called before the first frame update
    private void Start()
    {
        Count = 0;
    }
    // Update is called once per frame
    void Update()
    {
        CounterText.text = "Popped: " + Count;
    }
}
