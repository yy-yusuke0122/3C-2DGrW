using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool IsLive(string str)
    {
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(str))
        {
            return true;
        }
        return false;
    }
}
