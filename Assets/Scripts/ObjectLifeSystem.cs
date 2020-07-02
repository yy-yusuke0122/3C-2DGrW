using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectLifeSystem : MonoBehaviour
{
    [SerializeField]
    public float HP = 100f;

    ObjectCreater system;

    // Start is called before the first frame update
    void Start()
    {
        system = GameObject.Find("GameSystem").GetComponent<ObjectCreater>();
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
