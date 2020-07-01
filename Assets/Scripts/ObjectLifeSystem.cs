using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectLifeSystem : MonoBehaviour
{
    [SerializeField]
    public float HP = 100f;

    //GameSystem system;

    // Start is called before the first frame update
    void Start()
    {
        system = Find("GameSystem").GetComponent<GameSystem>();
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
    
    void CheckDestroy()
    {
        if (!system.isCreateMode && this.gameObject.tag != "Base")
            Destroy(this.gameObject);
    }
}
