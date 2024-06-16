using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDestroy : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //このオブジェクトの座標（z軸）が‐10を下回ったら
        if (transform.position.z <= -10)
        {
            //破壊する
            Destroy(gameObject);
        }
    }
}
