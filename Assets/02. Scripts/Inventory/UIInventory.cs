using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    /*[SerializeField]
    private GameObject Item; //���߿� �κ��丮�� �������� ���� �� ������Ʈ�� ��Ī�� ����*/

    [SerializeField]
    private Button BackToMainButton; //�κ��丮 -> ����ȭ�� �̵���ư

    [SerializeField]
    private UISlot slotPrefab; //UISlot Ÿ���� �ʵ� �߰�

    [SerializeField]
    private Transform slotParent; //Transform Ÿ���� slot �θ� �߰�

    private List<UISlot> itemSlots = new List<UISlot>(); //UISlot Ÿ���� ����Ʈ �߰�

    private void Start() //�κ��丮 -> ����ȭ������ �̵�
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
        Debug.Log("InitInventorySlot ȣ��");
        int slotCount = 11; //�κ��丮 ���� â 11�� (������ �ϳ� �־) => ������ ����

        for (int i = 0; i < slotCount; i++)
        {
            UISlot slots = Instantiate(slotPrefab, slotParent);
            itemSlots.Add(slots);
            Debug.Log($"���� {i} ����");
        }
        Debug.Log($"�� {itemSlots.Count}�� ���� ���� �Ϸ�");
    }

    public void SetInventory(List<Item> inventory)
    {
        Debug.Log($"SetInventory ȣ���! ������ ����: {inventory.Count}");
        Debug.Log($"���� ����: {itemSlots.Count}");
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (i < inventory.Count)
            {
                Debug.Log($"���� {i}�� ������ ����: {inventory[i].ItemName}");
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