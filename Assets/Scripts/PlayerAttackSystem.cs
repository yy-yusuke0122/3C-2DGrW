using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    [SerializeField]
    float Damage = 25f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject nest = GameObject.FindGameObjectWithTag("Nest");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObjectLifeSystem comp = collision.gameObject.GetComponent<ObjectLifeSystem>();
        comp.Damage(Damage);
        Destroy(this.gameObject);
    }
}
