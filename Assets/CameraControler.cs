using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    [SerializeField, Header("player")] private GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤータグのついているオブジェクトを取得
        this.player = GameObject.FindGameObjectWithTag("Player");
        //自分とプレイヤーの位置の差を調べ、offset変数に取得する
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        if (this.player != null)
        {
            //playerの現在のポジションを取得し続ける
            Vector3 playerPosition = player.transform.position;
            //もともとplayerは画面の奥に向かって進み続ける予定だったため
            //カメラもそれにくっついていくようにした
            Vector3 newposition = new Vector3(transform.position.x, transform.position.y, playerPosition.z + offset.z);
            //カメラの位置を新しく取得した変数の位置にそろえる
            transform.position = newposition;
        }
        
    }
}
