using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSystem : MonoBehaviour
{
    [SerializeField]
    float Damage = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        bool isEnemy = collision.gameObject.tag == "Enemy";
        bool isNest = collision.gameObject.tag == "Nest";
        if (!isEnemy && !isNest)
        {
            ObjectLifeSystem comp = collision.gameObject.GetComponent<ObjectLifeSystem>();
            comp.Damage(Damage);
        }
    }
}
