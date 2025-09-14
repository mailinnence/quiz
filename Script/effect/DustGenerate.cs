using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustGenerate : MonoBehaviour
{

    float ran;
    int ran_O;

    // 먼지 생성 함수
    void Dust_Generate()
    {
        ran = Random.Range(-0.05f, 0.05f);
        ran_O = Random.Range(1, 6);

        GameObject runDustEffect = PoolManager.instance.Get(ran_O);
        runDustEffect.transform.position = new Vector3(
            transform.position.x + 0.02f,
            transform.position.y - 0.3f + ran,
            transform.position.z
        );
    }


}
