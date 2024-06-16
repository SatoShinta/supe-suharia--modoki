using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kuttuku : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //親オブジェクトとなるPlayerタグを持ったオブジェクトの座標を取得
        transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
