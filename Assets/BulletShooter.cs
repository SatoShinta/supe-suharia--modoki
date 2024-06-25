using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField, Header("発射する玉のプレハブ")] private GameObject bullet;
    [SerializeField, Header("玉の速度")] private float bulletSpeed;
    [SerializeField, Header("発射間隔")] private float shootTimer;
    private float timer = 0;
    public AudioClip sound;


    // Start is called before the first frame update
    void OnEnable()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //timerに一秒ずつ数値を追加する
        timer += Time.deltaTime;

        //timerの値がshootTimerよりも大きくなったら
        if(timer >= shootTimer)
        {
            //shootBulletメソッドを使用し、timerの値を0にする
            shootBullet();
            timer = 0;
        }
        
    }

    void shootBullet()
    {
        //スペースキーが押されたとき
        if (Input.GetKey(KeyCode.Space))
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);

            //GameObject型のshootBullet変数に生成する弾をセットする
            GameObject shootBullet = Instantiate(bullet, transform.position, Quaternion.identity);

            //セットした弾のRigidBodyを取得し
            Rigidbody bulletRigitbody = shootBullet.GetComponent<Rigidbody>();

            if (bulletRigitbody != null )
            {
                //弾の加速度（ｚ軸）にbulletSpeedを掛ける
                bulletRigitbody.velocity =new Vector3(0, 0, 1 * bulletSpeed);
            }
     
        }
    }
}
