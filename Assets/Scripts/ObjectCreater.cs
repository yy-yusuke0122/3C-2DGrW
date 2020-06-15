using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreater : MonoBehaviour
{
    [SerializeField]
    GameObject obj1 = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // マウス位置座標をスクリーン座標からワールド座標に変換する
            Vector3 mousePos = Input.mousePosition;
            Vector3 screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(mousePos);
            screenToWorldPointPosition.z = 0f;
            GameObject obj = Instantiate(obj1, screenToWorldPointPosition, Quaternion.identity);
        }
    }
}
