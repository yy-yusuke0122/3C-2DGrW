using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField]
    bool isBase = false;
    bool energy;
    [SerializeField]
    float START_GIVE_ENETGY = 100f;

    [SerializeField]
    float needEnergy = 5f;

    ObjectLifeSystem lifeSystem;

    // Start is called before the first frame update
    void Start()
    {
        energy = isBase;
        lifeSystem = this.GetComponent<ObjectLifeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!lifeSystem.isStart) return;

        if (isBase)
        {
            BaseEnergy comp = this.gameObject.GetComponent<BaseEnergy>();
            if (comp.GetEnergyVal() < 0f) energy = false;
            if (comp.GetEnergyVal() > START_GIVE_ENETGY) energy = true;
        }
        else
        {
            energy = CanGetEnergy();
        }

        if (energy)
        {
            this.transform.Rotate(new Vector3(0, 0, 10f));
        }
    }

    public bool HaveEnergy()
    {
        return energy;
    }

    [SerializeField]
    float MaxSearchDistance = 3f;
    // 範囲内にEnergyを持つBaseかTowerがあるか取得
    bool CanGetEnergy()
    {
        bool canGetEnergy = false;

        //Baseオブジェクトを取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag("Base"))
        {
            // Baseのエネルギーが無かったら終了
            Energy comp = obs.GetComponent<Energy>();
            if (!comp.HaveEnergy()) return canGetEnergy;

            //自身と取得したオブジェクトの距離を取得
            float dis = Vector3.Distance(obs.transform.position, this.transform.position);

            // 最大探索距離以内ならエネルギー取得
            if (dis < MaxSearchDistance)
            {
                canGetEnergy = comp.HaveEnergy();
                return canGetEnergy;
            }
        }

        //Towerオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag("Tower"))
        {
            // 自分自身は取得対象外なので次へ
            if (obs == this.gameObject) continue;

            //自身と取得したオブジェクトの距離を取得
            float dis = Vector3.Distance(obs.transform.position, this.transform.position);

            // 最大探索距離を超えたら次へ
            if (dis > MaxSearchDistance)
                continue;

            canGetEnergy |= obs.GetComponent<Energy>().HaveEnergy();
        }

        return canGetEnergy;
    }

    public float GetNeedVal()
    {
        return needEnergy;
    }
}
