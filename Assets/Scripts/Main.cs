using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main : MonoBehaviour
{
    GameObject Base;
    ObjectLifeSystem Script;
    [SerializeField]
    float resultTime = 100;
    // Start is called before the first frame update
    void Start()
    {
        Base = GameObject.Find("Base");
        Script = Base.GetComponent<ObjectLifeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        float BaseHP = Script.HP;
        if (BaseHP <= 0f)
        {
            resultTime--;
        }
        if (resultTime <= 0)
        {
            SceneManager.LoadScene("Over");
        }

    }
}
