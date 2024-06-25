using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField, Header("���˂���ʂ̃v���n�u")] private GameObject bullet;
    [SerializeField, Header("�ʂ̑��x")] private float bulletSpeed;
    [SerializeField, Header("���ˊԊu")] private float shootTimer;
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
        //timer�Ɉ�b�����l��ǉ�����
        timer += Time.deltaTime;

        //timer�̒l��shootTimer�����傫���Ȃ�����
        if(timer >= shootTimer)
        {
            //shootBullet���\�b�h���g�p���Atimer�̒l��0�ɂ���
            shootBullet();
            timer = 0;
        }
        
    }

    void shootBullet()
    {
        //�X�y�[�X�L�[�������ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.Space))
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);

            //GameObject�^��shootBullet�ϐ��ɐ�������e���Z�b�g����
            GameObject shootBullet = Instantiate(bullet, transform.position, Quaternion.identity);

            //�Z�b�g�����e��RigidBody���擾��
            Rigidbody bulletRigitbody = shootBullet.GetComponent<Rigidbody>();

            if (bulletRigitbody != null )
            {
                //�e�̉����x�i�����j��bulletSpeed���|����
                bulletRigitbody.velocity =new Vector3(0, 0, 1 * bulletSpeed);
            }
     
        }
    }
}
