using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectLifeSystem : MonoBehaviour
{
    public GameObject HP_Bar = null;
    float HP_Bar_MaxScale;

    [SerializeField]
    float MaxHP = 100f;
    public float currentHP = 1f;

    public bool isStart = false;
    [SerializeField]
    float healVal = 0.25f;

    ObjectCreater system;

    // Start is called before the first frame update
    void Start()
    {
        HP_Bar = Instantiate(HP_Bar, this.transform.position, Quaternion.identity);
        HP_Bar.transform.Translate(new Vector3(0f, 0.5f, 0f));
        HP_Bar_MaxScale = HP_Bar.transform.localScale.x;

        isStart = false;

        if (this.gameObject.tag != "Base") currentHP = 1f;
        else currentHP = MaxHP;

        system = GameObject.Find("GameSystem").GetComponent<ObjectCreater>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart) Damage(-healVal);
    }

    public void Damage(float _val)
    {
        currentHP -= _val;
        CheckHP();

        float HP_Scale = currentHP / MaxHP;
        HP_Bar.transform.localScale = new Vector3(HP_Scale * HP_Bar_MaxScale, HP_Bar.transform.localScale.y, HP_Bar.transform.localScale.z);
    }

    void CheckHP()
    {
        if (currentHP <= 0f)
        {
            Destroy(this.gameObject);
            Destroy(HP_Bar);
        }

        if (currentHP > MaxHP)
        {
            currentHP = MaxHP;
            isStart = true;
        }
    }
}
