using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kuttuku : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�e�I�u�W�F�N�g�ƂȂ�Player�^�O���������I�u�W�F�N�g�̍��W���擾
        transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
