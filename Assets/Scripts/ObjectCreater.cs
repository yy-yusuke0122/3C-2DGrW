﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreater : MonoBehaviour
{
    [SerializeField]
    GameObject[] obj = null;
    int objNum;

    public bool isCreateMode;

    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        objNum = 0;
        isCreateMode = true;
    }

    // Update is called once per frame
    void Update()
    {
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        mousePos = Input.mousePosition;
        Vector3 screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(mousePos);
        screenToWorldPointPosition.z = 0f;

        if (Input.GetMouseButtonDown(0) && IsInsideGameArea())
        {
            if (isCreateMode)
            {
                GameObject newObj = Instantiate(obj[objNum], screenToWorldPointPosition, Quaternion.identity);
            }
            else
            {
                DestroyObject();
            }
        }
    }

    public void SetObjNum(int _num)
    {
        if (_num >= 0)
        {
            objNum = _num;
            if (objNum == 3) isCreateMode = false;
            else isCreateMode = true;
        }
    }

    bool IsInsideGameArea()
    {
        if (mousePos.x > 0f && mousePos.x < (1920.0f - 480.0f) &&
            mousePos.y > 0f && mousePos.y < 1080.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void DestroyObject()
    {
        // 左クリックされた場所のオブジェクトを取得
        Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
        if (collition2d)
        {
            GameObject obj = collition2d.transform.gameObject;
            if (obj.tag != "Base")
            {
                Destroy(obj.gameObject);
            }
        }
    }
}
