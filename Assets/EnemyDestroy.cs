using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    [SerializeField] public float counter = 0;
    float timer = 0;
    public GameObject effectPrefab;
    public AudioClip sound;

    // Start is called before the first frame update
    void OnEnable()
    {
        timer = 0;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //このオブジェクトのz軸の位置が‐10に以下になったら
        if (transform.position.z <= -20 || timer >= 8f)
        {
            //破壊する
            Destroy(gameObject);
        }
       
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Bulletタグを持ったオブジェクトに当たったら
        if (collision.gameObject.tag == "Bullet")
        {
            //counterを1増やす
            Debug.LogWarning("球が当たりました");
            counter++;
        }

        //counterが4以上になったら
        if (counter >= 3)
        {
            //破壊する
            Destroy(gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
    }
}
