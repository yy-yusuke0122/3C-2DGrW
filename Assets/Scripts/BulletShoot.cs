using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet = null;
    [SerializeField]
    float Interval = 1f;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > Interval)
        {
            time = 0f;
            GameObject newBullet = Instantiate(bullet, this.transform);
        }
    }
}
