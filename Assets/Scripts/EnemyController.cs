using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float MoveSpeed = 1f;
    float Rad = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //進方向をここに書く
        GameObject baseObject = GetNearObject(this.gameObject, "Base");
        if (baseObject != null)
        {
            Rad = Mathf.Atan2(
                baseObject.transform.position.y - transform.position.y,
                baseObject.transform.position.x - transform.position.x);
        }
        else Rad = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Position = transform.position;
        Position.x += MoveSpeed * Mathf.Cos(Rad) * Time.deltaTime;
        Position.y += MoveSpeed * Mathf.Sin(Rad) * Time.deltaTime;
        transform.position = Position;
        //transform.Translate(new Vector3(-MoveSpeed * Time.deltaTime, 0.0f, 0.0f));
    }
    GameObject GetNearObject(GameObject nowObj, string tagName) {
        float tmpDis = 0;
        float nearDis = 0;

        GameObject baseObj = null;

        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);
            if (nearDis == 0 || nearDis < tmpDis)
            {
                nearDis = tmpDis;
                baseObj = obs;
            }
        }
        return baseObj;
    }
}
