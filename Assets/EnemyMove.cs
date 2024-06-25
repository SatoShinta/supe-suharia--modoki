using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField, Header("移動速度")] float enemySpeed;

    float elapsedTime = 0;
    // Start is called before the first frame update
    void OnEnable()
    {
        elapsedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //経過時間を取得する
        elapsedTime += Time.deltaTime;

        //経過時間が0.5秒以上たったら
        if (elapsedTime >= 0.5)
        {
            //MoveBackメソッドを呼び出す
            MoveBack();
        } 
    }


    private void MoveBack()
    {
        //オブジェクトの位置をz軸の後ろ向きに　enemySpeed　の速さで動くようにする
        transform.Translate(Vector3.back * enemySpeed * Time.deltaTime);
    }
}
