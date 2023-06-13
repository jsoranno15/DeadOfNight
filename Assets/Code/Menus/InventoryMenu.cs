using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryMenu : MonoBehaviour
{
    public GameObject inventoryMenu;
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(!inventoryMenu.activeSelf){
                Time.timeScale = 0f;
                inventoryMenu.SetActive(true);
                Cursor.visible = true;
            }
            else{
                Time.timeScale = 1f;
                inventoryMenu.SetActive(false);
                Cursor.visible = false;
            }
        }
    }
}