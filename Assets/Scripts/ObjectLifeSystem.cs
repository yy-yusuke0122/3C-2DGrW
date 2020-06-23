using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLifeSystem : MonoBehaviour
{
    [SerializeField]
    float HP = 100f;
    float Enegy = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        Enegy++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Enegy > 1000)
        {
            Enegy = 1000;
            Debug.Log("満タンだよ");
        }
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
