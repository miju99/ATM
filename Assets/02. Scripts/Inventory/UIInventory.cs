using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField]
    private GameObject Item; //���߿� �κ��丮�� �������� ���� �� ������Ʈ�� ��Ī�� ����

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
    }

    private void InitInventorySlot()
    {
        int slotCount = 11; //�κ��丮 ���� â 11�� (������ �ϳ� �־)

        for(int i = 0; i < slotCount; i++)
        {
            UISlot slots = Instantiate(slotPrefab, slotParent);
            itemSlots.Add(slots);
        }
    }

    public void SetInventory(List<Item> inventory)
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (i < inventory.Count)
            {
                itemSlots[i].SetItem(inventory[i]);
            }
            else
            {
                itemSlots[i].SetItem(null);
            }
        }
    }
}
