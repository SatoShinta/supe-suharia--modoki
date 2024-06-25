using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBulletDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //もしこのオブジェクトがz軸の座標が80を超えたら
        if(transform.position.z <= -10)
        {
            //破壊する
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //もしPlayerタグかTreeタグかBulletタグを持ったオブジェクトに当たったら
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Tree" || collision.gameObject.tag == "Bullet" )
        {
            //破壊する
            Destroy(gameObject);
        }
    }
}
