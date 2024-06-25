using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxmaneger : MonoBehaviour
{



    [SerializeField] ItemSO itemSO;
    public int getItem;
    private int[] itemQtyAry;//各アイテムの所持数を格納する配列


    // Start is called before the first frame update
    void Start()
    {
        itemQtyAry = new int[itemSO.itemList.Count];
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
