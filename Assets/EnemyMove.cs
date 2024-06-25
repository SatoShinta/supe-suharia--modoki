using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField, Header("�ړ����x")] float enemySpeed;

    float elapsedTime = 0;
    // Start is called before the first frame update
    void OnEnable()
    {
        elapsedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //�o�ߎ��Ԃ��擾����
        elapsedTime += Time.deltaTime;

        //�o�ߎ��Ԃ�0.5�b�ȏソ������
        if (elapsedTime >= 0.5)
        {
            //MoveBack���\�b�h���Ăяo��
            MoveBack();
        } 
    }


    private void MoveBack()
    {
        //�I�u�W�F�N�g�̈ʒu��z���̌������Ɂ@enemySpeed�@�̑����œ����悤�ɂ���
        transform.Translate(Vector3.back * enemySpeed * Time.deltaTime);
    }
}
