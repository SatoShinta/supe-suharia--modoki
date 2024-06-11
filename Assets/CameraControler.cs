using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    [SerializeField, Header("player")] private GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�^�O�̂��Ă���I�u�W�F�N�g���擾
        this.player = GameObject.FindGameObjectWithTag("Player");
        //�����ƃv���C���[�̈ʒu�̍��𒲂ׁAoffset�ϐ��Ɏ擾����
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        if (this.player != null)
        {
            //player�̌��݂̃|�W�V�������擾��������
            Vector3 playerPosition = player.transform.position;
            //���Ƃ���player�͉�ʂ̉��Ɍ������Đi�ݑ�����\�肾��������
            //�J����������ɂ������Ă����悤�ɂ���
            Vector3 newposition = new Vector3(transform.position.x, transform.position.y, playerPosition.z + offset.z);
            //�J�����̈ʒu��V�����擾�����ϐ��̈ʒu�ɂ��낦��
            transform.position = newposition;
        }
        
    }
}
