using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    [SerializeField] public float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���̃I�u�W�F�N�g��z���̈ʒu���]10�Ɉȉ��ɂȂ�����
        if (transform.position.z <= -10)
        {
            //�j�󂷂�
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Bullet�^�O���������I�u�W�F�N�g�ɓ���������
        if (collision.gameObject.tag == "Bullet")
        {
            //counter��1���₷
            Debug.LogWarning("����������܂���");
            counter++;
        }

        //counter��4�ȏ�ɂȂ�����
        if (counter >= 3)
        {
            //�j�󂷂�
            Destroy(gameObject);
        }
    }
}
