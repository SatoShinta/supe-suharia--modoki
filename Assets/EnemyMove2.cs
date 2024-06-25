using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    [SerializeField, Header("�ړ����x")] float enemySpeed;
    [SerializeField, Header("�ړ����x�c")] float enemySpeed2;
    private float timer;
    public bool moveback = true;

    float elapsedTime = 0;
    // Start is called before the first frame update
    void OnEnable()
    {
        timer = 0;
        elapsedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        elapsedTime += Time.deltaTime;

        //�X�|�[�����Ă���0.5�b��������
        if (elapsedTime >= 0.5)
        {
            //moveback�t���O�� true ��������
            if(moveback == true)
            {
                //MoveSide ���\�b�h���Ăяo��
                MoveSide();
            }
            
            //moveback�t���O�� false �ŁA6�b���Ԃ���������
            if(moveback == false && timer >= 6)
            {
                //MoveBack���\�b�h���Ăяo��
                MoveBack();
            }
            
        }
    }

    private void MoveSide()
    {

        //x����10�ȏ�̒l�ɂȂ����甽�΂̕����ɗ͂������A
        //y���͏オ10�ȏ�A����0�ȉ��̒l�ɂȂ����甽�΂̕����ɗ͂������悤�ɂ���

        transform.Translate(enemySpeed�@* Time.deltaTime , enemySpeed2 * Time.deltaTime, 0);
        if (transform.position.x <= -10)
        {
            enemySpeed *= -1;
        }
        if (transform.position.x >= 10)
        {
            enemySpeed *= -1;
        }
        if (transform.position.y <= 0)
        {
            enemySpeed2 *= -1;
        }
        if(transform.position.y >= 10)
        {
            enemySpeed2 *= -1;
        }
        
        //�X�|�[�����Ă���5�b��������
        if( timer >= 5)
        {
            //moveback�t���O��false�ɂ��A�������~�߂�
            //MoveBack���\�b�h�Ŏg�p����enemySpeed�ϐ��ɒl��������
            moveback = false;
            enemySpeed = 15;
            enemySpeed2 = 0;
        }
        var pos = transform.position;

        //x���Ay���̌��x��ݒ肵
        pos.x = Mathf.Clamp(pos.x, -11, 11);
        pos.y = Mathf.Clamp(pos.y, -1, 10);
        pos.z = Mathf.Clamp(pos.z, 2, 8);

        //���̃I�u�W�F�N�g��transformposition�ɑ������
        transform.position = pos;
    }


    private void MoveBack()
    {
        //player���Ɍ������Ă���悤�ɂ���
        transform.Translate(Vector3.back * enemySpeed * 2 * Time.deltaTime);
    }
}

