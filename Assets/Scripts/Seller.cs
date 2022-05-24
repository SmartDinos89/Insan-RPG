using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    public List<GameObject> itemsOnSale;
    public GameObject ShopUI;
    public DialogueUi dialogueUi;
    public GameObject ShopItemHolder;

    private void Awake() {
        dialogueUi = GameObject.FindGameObjectWithTag("Canvas").GetComponent<DialogueUi>();
    }
    public void OpenShop(){
        ShopUI.SetActive(true);
        dialogueUi.isOpen = true;
        foreach (GameObject item in itemsOnSale)
        {
            Instantiate(item, ShopItemHolder.transform);
        }
    }
}
