using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    [SerializeField, Header("移動速度")] float enemySpeed;
    [SerializeField, Header("移動速度縦")] float enemySpeed2;
    private float timer;
    public bool moveback = true;

    float elapsedTime = 0;
    // Start is called before the first frame update
    void OnEnable()
    {
        timer = 0;
        elapsedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        elapsedTime += Time.deltaTime;

        //スポーンしてから0.5秒たったら
        if (elapsedTime >= 0.5)
        {
            //movebackフラグが true だったら
            if(moveback == true)
            {
                //MoveSide メソッドを呼び出す
                MoveSide();
            }
            
            //movebackフラグが false で、6秒時間がたったら
            if(moveback == false && timer >= 6)
            {
                //MoveBackメソッドを呼び出す
                MoveBack();
            }
            
        }
    }

    private void MoveSide()
    {

        //x軸は10以上の値になったら反対の方向に力を加え、
        //y軸は上が10以上、下が0以下の値になったら反対の方向に力が加わるようにした

        transform.Translate(enemySpeed　* Time.deltaTime , enemySpeed2 * Time.deltaTime, 0);
        if (transform.position.x <= -10)
        {
            enemySpeed *= -1;
        }
        if (transform.position.x >= 10)
        {
            enemySpeed *= -1;
        }
        if (transform.position.y <= 0)
        {
            enemySpeed2 *= -1;
        }
        if(transform.position.y >= 10)
        {
            enemySpeed2 *= -1;
        }
        
        //スポーンしてから5秒たったら
        if( timer >= 5)
        {
            //movebackフラグをfalseにし、動きを止めて
            //MoveBackメソッドで使用するenemySpeed変数に値を代入する
            moveback = false;
            enemySpeed = 15;
            enemySpeed2 = 0;
        }
        var pos = transform.position;

        //x軸、y軸の限度を設定し
        pos.x = Mathf.Clamp(pos.x, -11, 11);
        pos.y = Mathf.Clamp(pos.y, -1, 10);
        pos.z = Mathf.Clamp(pos.z, 2, 8);

        //このオブジェクトのtransformpositionに代入する
        transform.position = pos;
    }


    private void MoveBack()
    {
        //player側に向かってくるようにする
        transform.Translate(Vector3.back * enemySpeed * 2 * Time.deltaTime);
    }
}

