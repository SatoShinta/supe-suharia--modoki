using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField, Header("�ړ��X�s�[�h")] float speed;
    //���̃X�N���v�g���A�^�b�`���Ă���I�u�W�F�N�g�̃}�e���A�����Q�Ƃ���
    private Material material;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //���̃I�u�W�F�N�g�ɃA�^�b�`���ꂽRendere�R���|�[�l���g���擾����
      Renderer renderer = GetComponent<Renderer>();
        //����Renderer�R���|�[�l���g�����������΂���
        if (renderer != null)
        {
            //���̃I�u�W�F�N�g�̃}�e���A����ϐ��Ɏ擾����
            material = renderer.material;
        }
        //����������Ȃ������ꍇ�inull�j
        else
        {
            //debuglog������
            Debug.LogError("�����_���[�R���|�[�l���g��������܂���");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            //�}�e���A����offset����ɍX�V��������
            //�i�Z�b�g����Ă���e�N�X�`���[�̓e�N�X�`���[�̐ݒ�̂ق��Ń��[�v����悤�ɂȂ��Ă���j
            material.mainTextureOffset += new Vector2(0, Time.deltaTime * speed);
        }
        
        if(player == null)
        {
            material.mainTextureOffset += new Vector2(0, 0);
        }
    }
}
