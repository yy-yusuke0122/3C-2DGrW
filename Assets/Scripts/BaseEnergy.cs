using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnergy : MonoBehaviour
{
    [SerializeField]
    float energy = 1000f;
    [SerializeField]
    float Charg = 20f;
    float useEneVal = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 回復
        if (energy > 1000f)
        {
            energy = 1000f;
        }
        else if (energy < 0f)
        {
            energy = 0f;
        }
        else
        {
            energy += Charg * Time.deltaTime;
        }


        // 必要使用電気量を更新
        UpdateUseEneVal();

        // 使用
        energy -= useEneVal * Time.deltaTime;
    }

    void UpdateUseEneVal()
    {
        // 必要使用電気量を初期化
        useEneVal = 0f;

        // 必要使用電気量を加算
        useEneVal += GetNeedEneVal("Tower");
        useEneVal += GetNeedEneVal("Turret");
    }

    float GetNeedEneVal(string str)
    {
        float val = 0.0f;

        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(str))
        {
            Energy comp = obs.GetComponent<Energy>();

            // 通電していないなら次へ
            if (!comp.HaveEnergy()) continue;

            // 必要使用電気量を加算
            val += comp.GetNeedVal();
        }

        return val;
    }

    public float GetEnergyVal()
    {
        return energy;
    }
}
