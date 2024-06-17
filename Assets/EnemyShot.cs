using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField, Header("敵の発射する弾")] GameObject bullet;
    [SerializeField,Header("狙うオブジェクト")]GameObject player;
    public float bulletSpeed = 10.0f;
    float time = 1.0f;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAtを使用しplayerの位置を取得し常に向くようにする
        transform.LookAt(player.transform);

        //time変数にゲーム時間を代入していき
        time -= Time.deltaTime;
        //1秒たったら
        if(time <= 0f)
        {
            //BulletShotメソッドを呼び出し、time変数の値を0にする
            BulletShot();
            time = 1.0f;
        }
    }

    private void BulletShot()
    {
        //gameobject型のshootBullet変数に弾を生成する処理を格納し、
        GameObject shootBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody rb = shootBullet.GetComponent<Rigidbody>();
        //弾のRigidBodyコンポーネントを取得し、加速度を設定する
        rb.velocity = new Vector3(0, 0, -1 * bulletSpeed);
        Debug.LogError("deta");
    }
}
