using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Header("水平方向の移動速度")] private float horizontalspeed = 0;
    [SerializeField, Header("垂直方向の移動速度")] private float verticalspeed = 0;
    [SerializeField, Header("水平方向の上限")] private float xaxis;
    private float down = 0;
    [SerializeField,Header("垂直条項の上限")] private float yaxis;
    
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
        //変数に操作方法とスピードを代入して
        Vector3 playerMove = new Vector3(horizontalMovement, verticalMovement, 0);
        //ここでplayerを動かす
        transform.Translate(playerMove);

        //ここでpos変数にこのオブジェクトの位置を取得する
        var pos = transform.position;

        //x軸、y軸の限度を設定し
        pos.x = Mathf.Clamp(pos.x, -xaxis, xaxis);
        pos.y = Mathf.Clamp(pos.y, down, yaxis);

        //このオブジェクトのtransformpositionに代入する
        transform.position = pos;
    }
}