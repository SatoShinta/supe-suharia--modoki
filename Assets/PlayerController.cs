using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Header("���������̈ړ����x")] private float horizontalspeed = 0;
    [SerializeField, Header("���������̈ړ����x")] private float verticalspeed = 0;
    [SerializeField, Header("���������̏��")] private float xaxis;
    private float down = 0;
    [SerializeField,Header("���������̏��")] private float yaxis;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        float horizontalMovement = inputHorizontal * horizontalspeed * Time.deltaTime;
        float verticalMovement = inputVertical * verticalspeed * Time.deltaTime;
        //�ϐ��ɑ�����@�ƃX�s�[�h��������
        Vector3 playerMove = new Vector3(horizontalMovement, verticalMovement, 0);
        //������player�𓮂���
        transform.Translate(playerMove);

        //������pos�ϐ��ɂ��̃I�u�W�F�N�g�̈ʒu���擾����
        var pos = transform.position;

        //x���Ay���̌��x��ݒ肵
        pos.x = Mathf.Clamp(pos.x, -xaxis, xaxis);
        pos.y = Mathf.Clamp(pos.y, down, yaxis);

        //���̃I�u�W�F�N�g��transformposition�ɑ������
        transform.position = pos;
    }
}