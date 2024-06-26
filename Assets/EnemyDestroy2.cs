using UnityEngine;

public class EnemyDestroy2 : MonoBehaviour

{
    [SerializeField] public float counter;
    private float timer;
    public GameObject effectPrefab;
    public AudioClip sound;


    // Start is called before the first frame update
    void OnEnable()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //一秒ごとにtimerに数値を入れていく
        timer = Time.deltaTime;

        //もしこのオブジェクトの位置（z軸）が－10よりも手前に来るか、timerが8より大きくなったとき
        if (transform.position.z <= -10 || timer >= 8)
        {
            //破壊する
            Destroy(gameObject);
        }
        //counterが5より大きくなったとき
        if (counter >= 4)
        {
            //破壊する
            Destroy(gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Bulletタグを持ったオブジェクトに当たった時
        if (collision.gameObject.tag == "Bullet")
        {
            //counterを1増やす
            Debug.LogWarning("球が当たりました");
            counter++;
        }


    }
}
