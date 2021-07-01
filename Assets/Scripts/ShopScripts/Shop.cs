using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{

    #region Singleton:Shop
    public static Shop Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    [System.Serializable]
    public class ShopItem
    {
        public Sprite Image;
        public int Price;
        public bool IsPurchased = false;
    }

    public List<ShopItem> ShopItemsList;
    [SerializeField] Animator NoCoinsAnim;
    Button buyBtn;

    [SerializeField] GameObject ItemTemplate;
    GameObject g;
    [SerializeField] Transform ShopScrollView;
    [SerializeField] GameObject ShopPanel;

    public CoinScritableObject coinHolderObject;

    private void Start()
    {
        //Purchased item Check
        List<int> PurchasedItem = coinHolderObject.GetPurchasedItemNumsList();
        for (int i = 0; i < PurchasedItem.Count; i++)
        {
            ShopItemsList[PurchasedItem[i]].IsPurchased = true;
            Profile.Instance.AddAvatar(ShopItemsList[PurchasedItem[i]].Image);

        }



        int len = ShopItemsList.Count;
        for (int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].Image;
            g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ShopItemsList[i].Price.ToString();
            buyBtn = g.transform.GetChild(2).GetComponent<Button>();
            if (ShopItemsList[i].IsPurchased)
            {
                DisableBuyButton();
            }

            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
        }
    }

    void OnShopItemBtnClicked(int itemIndex)
    {
        if (coinHolderObject.HasEnoughCoins(ShopItemsList[itemIndex].Price))
        {
            coinHolderObject.UseCoins(ShopItemsList[itemIndex].Price);
            //purchase Item
            ShopItemsList[itemIndex].IsPurchased = true;
            //disable the button
            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            DisableBuyButton();


            //add avatar
            Profile.Instance.AddAvatar(ShopItemsList[itemIndex].Image);


            //add purchased item num to the list
            coinHolderObject.AddPurchasedItem(itemIndex);


        }
        else
        {
            NoCoinsAnim.SetTrigger("NoCoins");
            Debug.Log("You don't have enogh coins!!");
        }
    }

    void DisableBuyButton()
    {
        buyBtn.interactable = false;
        buyBtn.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
    }

    //-----------------------------------------Open and Close shop---------------------------------------------
    public void OpenShop()
    {
        ShopPanel.SetActive(true);
    }
    public void CloseShop()
    {
        ShopPanel.SetActive(false);
    }
}
