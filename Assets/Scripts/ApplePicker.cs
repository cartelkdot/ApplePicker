using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set In Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketlist;
    // Start is called before the first frame update
    void Start()
    {
        basketlist = new List<GameObject>();
        for (int i =0; i<numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketlist.Add(tBasketGO);
        }
    }

    public void AppleDestroyed()
    {
        //Destroy all of the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tGo in tAppleArray)
        {
            Destroy(tGo);
        }

        //Destroy one of the baskets
        //Get the index of the last Basket in basketList
        int basketIndex = basketlist.Count - 1;
        //Get a reference to that Basket GameObject
        GameObject tBasketGO = basketlist[basketIndex];
        //Remove the basket from the list and destroy the GameObject
        basketlist.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        //If there are no Baskets left, restart the game
        if(basketlist.Count == 0)
        {
            SceneManager.LoadScene("__Scene_0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
