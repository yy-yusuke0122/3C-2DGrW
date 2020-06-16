﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLifeSystem : MonoBehaviour
{
    [SerializeField]
    float HP = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float _val)
    {
        HP -= _val;
        CheckHP();
    }

    void CheckHP()
    {
        if (HP <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}