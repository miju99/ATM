using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    /*[SerializeField]
    private GameObject Item; //나중에 인벤토리에 아이템이 들어가면 그 오브젝트를 지칭할 예정*/

    [SerializeField]
    private Button BackToMainButton; //인벤토리 -> 메인화면 이동버튼

    [SerializeField]
    private UISlot slotPrefab; //UISlot 타입의 필드 추가

    [SerializeField]
    private Transform slotParent; //Transform 타입의 slot 부모 추가

    private List<UISlot> itemSlots = new List<UISlot>(); //UISlot 타입의 리스트 추가

    private void Start() //인벤토리 -> 메인화면으로 이동
    {
        BackToMainButton.onClick.AddListener(() =>
        {
            UIManager.Instance.MainMenu.OpenMainMenu();
        });

        InitInventorySlot();
        SetInventory(InventoryGameManager.Instance.Player.Inventory);
    }

    private void InitInventorySlot()
    {
        Debug.Log("InitInventorySlot 호출");
        int slotCount = 11; //인벤토리 슬롯 창 11개 (프리팹 하나 있어서) => 프리팹 삭제

        for (int i = 0; i < slotCount; i++)
        {
            UISlot slots = Instantiate(slotPrefab, slotParent);
            itemSlots.Add(slots);
            Debug.Log($"슬롯 {i} 생성");
        }
        Debug.Log($"총 {itemSlots.Count}개 슬롯 생성 완료");
    }

    public void SetInventory(List<Item> inventory)
    {
        Debug.Log($"SetInventory 호출됨! 아이템 개수: {inventory.Count}");
        Debug.Log($"슬롯 개수: {itemSlots.Count}");
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (i < inventory.Count)
            {
                Debug.Log($"슬롯 {i}에 아이템 설정: {inventory[i].ItemName}");
                itemSlots[i].SetItem(inventory[i]);
            }
            else
            {
                itemSlots[i].SetItem(null);
            }
        }
    }

    public void RefreshInventory()
    {
        List<Item> PlayerItems = InventoryGameManager.Instance.Player.Inventory;

        for(int i = 0; i < itemSlots.Count; i++)
        {
            if (i < PlayerItems.Count)
            {
            itemSlots[i].SetItem(PlayerItems[i]);
            }
            else
            {
                itemSlots[i].SetItem(null);
            }
        }
    }
}