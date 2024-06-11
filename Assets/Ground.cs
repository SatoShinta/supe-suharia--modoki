using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField, Header("移動スピード")] float speed;
    //このスクリプトをアタッチしているオブジェクトのマテリアルを参照する
    private Material material;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //このオブジェクトにアタッチされたRendereコンポーネントを取得する
      Renderer renderer = GetComponent<Renderer>();
        //もしRendererコンポーネントが見つかったばあい
        if (renderer != null)
        {
            //このオブジェクトのマテリアルを変数に取得する
            material = renderer.material;
        }
        //もし見つからなかった場合（null）
        else
        {
            //debuglogをだす
            Debug.LogError("レンダラーコンポーネントが見つかりません");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            //マテリアルのoffsetを常に更新し続ける
            //（セットされているテクスチャーはテクスチャーの設定のほうでループするようになっている）
            material.mainTextureOffset += new Vector2(0, Time.deltaTime * speed);
        }
        
        if(player == null)
        {
            material.mainTextureOffset += new Vector2(0, 0);
        }
    }
}
