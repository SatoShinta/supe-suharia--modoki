using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDestroy : MonoBehaviour
{
    [SerializeField] public float counter = 0;


    // Update is called once per frame
    void Update()
    {
        //このオブジェクトのz軸の位置が‐10に以下になったら
        if (transform.position.z <= -10)
        {
            //破壊する
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Bulletタグを持ったオブジェクトに当たったら
        if (collision.gameObject.tag == "Bullet")
        {
            //counterを1増やす
            Debug.LogWarning("球が当たりました");
            counter++;
        }

        //counterが4以上になったら
        if (counter >= 100)
        {
            //破壊する
            Destroy(gameObject);
        }
    }
}
