using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    [SerializeField] public float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        if (counter >= 3)
        {
            //破壊する
            Destroy(gameObject);
        }
    }
}
