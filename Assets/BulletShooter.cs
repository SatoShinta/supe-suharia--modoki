using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField, Header("発射する玉のプレハブ")] private GameObject bullet;
    [SerializeField, Header("玉の速度")] private float bulletSpeed;
    [SerializeField, Header("発射間隔")] private float shootTimer;
    private float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= shootTimer)
        {
            shootBullet();
            timer = 0;
        }
        
    }

    void shootBullet()
    {
        //スペースキーが押されたとき
        if (Input.GetKey(KeyCode.Space))
        {
           GameObject shootBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody bulletRigitbody = shootBullet.GetComponent<Rigidbody>();
            if (bulletRigitbody != null )
            {
                bulletRigitbody.velocity =new Vector3(0, 0, 1 * bulletSpeed);
            }
     
        }
    }
}
