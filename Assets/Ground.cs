using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField, Header("�ړ��X�s�[�h")] float speed;
    //���̃X�N���v�g���A�^�b�`���Ă���I�u�W�F�N�g�̃}�e���A�����Q�Ƃ���
    private Material material;
    public GameObject player;

    private float elapsedTime = 0f;
    // Start is called before the first frame update
    void OnEnable()
    {
        elapsedTime = 0;

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
        elapsedTime += Time.deltaTime;

        if (player != null)
        {
            //�}�e���A����offset����ɍX�V��������
            //�i�Z�b�g����Ă���e�N�X�`���[�̓e�N�X�`���[�̐ݒ�̂ق��Ń��[�v����悤�ɂȂ��Ă���j
            material.mainTextureOffset += new Vector2(0, Time.deltaTime * speed);
            if(elapsedTime > 64f)
            {
                speed = -2f;
            }
        }
        
        
    }
}
