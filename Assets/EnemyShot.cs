using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField, Header("�G�̔��˂���e")] GameObject bullet;
    [SerializeField,Header("�_���I�u�W�F�N�g")]GameObject player;
    float bulletSpeed = 10f;
    float time = 0f;

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt���g�p��player�̈ʒu���擾����Ɍ����悤�ɂ���
        transform.LookAt(player.transform);

        //time�ϐ��ɃQ�[�����Ԃ������Ă���
        time += Time.deltaTime;
        //1�b��������
        if(time >= 1f)
        {
            //BulletShot���\�b�h���Ăяo���Atime�ϐ��̒l��0�ɂ���
            BulletShot();
            time = 0f;
        }
    }

    private void BulletShot()
    {
        //gameobject�^��shootBullet�ϐ��ɒe�𐶐����鏈�����i�[���A
        GameObject shootBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        //�e��RigidBody�R���|�[�l���g���擾���A�����x��ݒ肷��
        shootBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }
}
