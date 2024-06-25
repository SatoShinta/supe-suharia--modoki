using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField, Header("�G�̔��˂���e")] GameObject bullet;
    [SerializeField,Header("�_���I�u�W�F�N�g")]GameObject player;
    [SerializeField,Header("���ˏꏊ")]GameObject mazzle;
    public float bulletSpeed = 10.0f;
    float time = 1;


    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //time�ϐ��ɃQ�[�����Ԃ������Ă���
        time -= Time.deltaTime;

        if (player != null)
        {
            //transform.LookAt���g�p��player�̈ʒu���擾����Ɍ����悤�ɂ���
            transform.LookAt(player.transform);
        }

       
        //1�b��������
        if(time <= 0f)
        {
            //BulletShot���\�b�h���Ăяo���Atime�ϐ��̒l��0�ɂ���
            BulletShot();
            time = 0.6f;
        }
    }

    private void BulletShot()
    {
        //gameobject�^��shootBullet�ϐ��ɒe�𐶐����鏈�����i�[���A
        GameObject shootBullet = Instantiate(bullet, mazzle.transform.position,Quaternion.identity);
        shootBullet.GetComponent<Rigidbody>().velocity = transform.forward  * bulletSpeed ;
        //Debug.LogError("aaa");
    }
}
