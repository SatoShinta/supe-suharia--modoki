using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDestroy : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //���̃I�u�W�F�N�g�̍��W�iz���j���]10�����������
        if (transform.position.z <= -10)
        {
            //�j�󂷂�
            Destroy(gameObject);
        }
    }
}
