using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet = null;   // 撃つ弾のオブジェクト

    [SerializeField]
    float Interval = 1f;        // 撃つ間隔
    float time;                 // 経過時間

    Energy energy;              // エネルギーを管理するコンポーネント

    // Start is called before the first frame update
    void Start()
    {
        energy = this.GetComponent<Energy>();
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // エネルギーがある時に
        if (energy.HaveEnergy())
        {
            // 一定間隔でショットを撃つ
            time += Time.deltaTime;
            if (time > Interval)
            {
                time = 0f;
                GameObject newBullet = Instantiate(bullet);
                newBullet.transform.position = this.transform.position;
            }
        }
    }
}
