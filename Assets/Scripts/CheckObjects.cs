using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CheckObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool LiveNest = IsLive("Nest");
        if (LiveNest == false)
        {
            SceneManager.LoadScene("Clear");
        }
        bool LiveBase = IsLive("Base");
        if (LiveBase == false)
        {
            SceneManager.LoadScene("Over");
        }
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
