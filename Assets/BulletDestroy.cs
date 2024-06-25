using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //もしこのオブジェクトがz軸の座標が80を超えたら
        if(transform.position.z >= 80)
        {
            //破壊する
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //もしEnemyタグかTreeタグを持ったオブジェクトに当たったら
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Tree" || collision.gameObject.tag == "Boss")
        {
            //破壊する
            Destroy(gameObject);
        }
    }
}
