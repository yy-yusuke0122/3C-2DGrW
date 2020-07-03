using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreater : MonoBehaviour
{
    [SerializeField]
    GameObject areaObj = null;
    GameObject area = null;

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

        area = Instantiate(areaObj, new Vector3(0,0,0), Quaternion.identity);
        area.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        mousePos = Input.mousePosition;
        Vector3 screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(mousePos);
        screenToWorldPointPosition.z = 0f;

        if (objNum == 1 || objNum == 2)
        {
            Debug.Log(area.transform.position);
            area.transform.position = screenToWorldPointPosition;
        }

        if (Input.GetMouseButtonDown(0) && IsInsideGameArea())
        {
            if (isCreateMode)
            {
                Instantiate(obj[objNum], screenToWorldPointPosition, Quaternion.identity);
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

            if (objNum == 1 || objNum == 2)
            {
                area.SetActive(true);
            }
            else
            {
                area.SetActive(false);
            }
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
            GameObject selectObj = collition2d.transform.gameObject;
            if (selectObj.tag != "Base" && selectObj.tag != "Nest" && selectObj.tag != "Enemy")
            {
                ObjectLifeSystem comp = selectObj.gameObject.GetComponent<ObjectLifeSystem>();
                Destroy(comp.HP_Bar);
                Destroy(selectObj.gameObject);
            }
        }
    }
}
