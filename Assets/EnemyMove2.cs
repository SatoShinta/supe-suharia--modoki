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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 0.5)
        {
            if(moveback == true)
            {
                MoveSide();
            }
            if(moveback == false && timer >= 6)
            {
                MoveBack();
            }
            
        }
    }

    private void MoveSide()
    {
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
        if( timer >= 5)
        {
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
        transform.Translate(Vector3.back * enemySpeed * 2 * Time.deltaTime);
    }
}

