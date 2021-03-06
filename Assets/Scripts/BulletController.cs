﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float MoveSpeed = 5f;
    float rad = 0f;

    [SerializeField]
    float DestroyTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        // 飛ぶ方向をセット
        GameObject targetObject = GetNearObject(this.gameObject, "Enemy");
        if(targetObject == null)
        {
            targetObject = GetNearObject(this.gameObject, "Nest");
        }
        if (targetObject != null)
        {
            rad = Mathf.Atan2(
            targetObject.transform.position.y - transform.position.y,
            targetObject.transform.position.x - transform.position.x);
        }
        else Destroy(this.gameObject);

        // 一定時間後、自機を破壊
        Destroy(this.gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        // 現在位置をPositionに代入
        Vector3 Position = transform.position;
        // これで特定の方向へ向かって進んでいく。
        Position.x += MoveSpeed * Mathf.Cos(rad) * Time.deltaTime;
        Position.y += MoveSpeed * Mathf.Sin(rad) * Time.deltaTime;
        // 現在の位置に加算減算を行ったPositionを代入する
        transform.position = Position;
    }

    [SerializeField]
    float MaxSearchDistance = 10f;
    //指定されたタグの中で最も近いものを取得
    GameObject GetNearObject(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
                                    //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            // 最大探索距離を超えたら終了
            if (tmpDis > MaxSearchDistance)
                return targetObj;

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        return targetObj;
    }
}
