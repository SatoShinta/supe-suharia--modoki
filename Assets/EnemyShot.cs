using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField, Header("敵の発射する弾")] GameObject bullet;
    [SerializeField,Header("狙うオブジェクト")]GameObject player;
    [SerializeField,Header("発射場所")]GameObject mazzle;
    public float bulletSpeed = 10.0f;
    float time = 1;


    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //time変数にゲーム時間を代入していき
        time -= Time.deltaTime;

        if (player != null)
        {
            //transform.LookAtを使用しplayerの位置を取得し常に向くようにする
            transform.LookAt(player.transform);
        }

       
        //1秒たったら
        if(time <= 0f)
        {
            //BulletShotメソッドを呼び出し、time変数の値を0にする
            BulletShot();
            time = 0.6f;
        }
    }

    private void BulletShot()
    {
        //gameobject型のshootBullet変数に弾を生成する処理を格納し、
        GameObject shootBullet = Instantiate(bullet, mazzle.transform.position,Quaternion.identity);
        shootBullet.GetComponent<Rigidbody>().velocity = transform.forward  * bulletSpeed ;
        //Debug.LogError("aaa");
    }
}
