using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField, Header("���˂���ʂ̃v���n�u")] private GameObject bullet;
    [SerializeField, Header("�ʂ̑��x")] private float bulletSpeed;
    [SerializeField, Header("���ˊԊu")] private float shootTimer;
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
        //�X�y�[�X�L�[�������ꂽ�Ƃ�
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
