using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�������̃I�u�W�F�N�g��z���̍��W��80�𒴂�����
        if(transform.position.z >= 80)
        {
            //�j�󂷂�
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //����Enemy�^�O��Tree�^�O���������I�u�W�F�N�g�ɓ���������
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Tree" || collision.gameObject.tag == "Boss")
        {
            //�j�󂷂�
            Destroy(gameObject);
        }
    }
}
