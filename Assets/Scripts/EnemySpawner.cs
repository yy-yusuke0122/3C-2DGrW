using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // 敵のオブジェクト
    [SerializeField]
    GameObject enemy;

    // スポーン間隔
    [SerializeField]
    float Interval;

    // 経過時間
    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        IncrementCool();
        SpawnEnemy();
    }

    void IncrementCool()
    {
        time += Time.deltaTime;
    }

    void SpawnEnemy()
    {
        if (time > Interval)
        {
            Instantiate(enemy, this.transform);
            
            time = 0.0f;
        }
    }
}
