using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnergy : MonoBehaviour
{
    [SerializeField]
    float energy = 1000f;
    [SerializeField]
    float Charg = 0.1f;
    float cut = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Energy comp = GetComponent<Energy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (energy < 1000)
        {
            energy += Charg;
            //Debug.Log("回復中です");
        }
        if (energy > 1000)
        {
            energy = 1000;
            Debug.Log("満タンだよ");
        }
    }
}
