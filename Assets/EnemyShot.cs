using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField, Header("�G�̔��˂���e")] GameObject bullet;
    [SerializeField,Header("�_���I�u�W�F�N�g")]GameObject player;
    public float bulletSpeed = 10.0f;
    float time = 1.0f;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt���g�p��player�̈ʒu���擾����Ɍ����悤�ɂ���
        transform.LookAt(player.transform);

        //time�ϐ��ɃQ�[�����Ԃ������Ă���
        time -= Time.deltaTime;
        //1�b��������
        if(time <= 0f)
        {
            //BulletShot���\�b�h���Ăяo���Atime�ϐ��̒l��0�ɂ���
            BulletShot();
            time = 1.0f;
        }
    }

    private void BulletShot()
    {
        //gameobject�^��shootBullet�ϐ��ɒe�𐶐����鏈�����i�[���A
        GameObject shootBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody rb = shootBullet.GetComponent<Rigidbody>();
        //�e��RigidBody�R���|�[�l���g���擾���A�����x��ݒ肷��
        rb.velocity = new Vector3(0, 0, -1 * bulletSpeed);
        Debug.LogError("deta");
    }
}
