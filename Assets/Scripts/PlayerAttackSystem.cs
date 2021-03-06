﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    [SerializeField]
    float Damage = 25f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject EnemyNest = GameObject.Find("Nest");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObjectLifeSystem comp = collision.gameObject.GetComponent<ObjectLifeSystem>();
        comp.Damage(Damage);
        Destroy(this.gameObject);
    }
}
