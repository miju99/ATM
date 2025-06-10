using System.Collections.Generic;
using UnityEngine;

public class InventoryGameManager : MonoBehaviour
{
    public static InventoryGameManager Instance {  get; private set; }

    [SerializeField]
    private Character character;
    [SerializeField]
    private UIMainMenu uiMainMenu;
    [SerializeField]
    public UIStatus uiStatus;
    [SerializeField]
    private UIInventory uiinventory;

    [SerializeField]
    private Item stamp;
    [SerializeField]
    private Item sword;
    [SerializeField]
    private Item shield;

    public Character Player { get; private set; } //Player ������Ƽ (ĳ���� ����)

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SetData();
    }

    public void SetData()
    {
        Player = new GameObject("PlayerData").AddComponent<Character>(); //�÷��̾� ����
        Player.Init("����", 1, 1000, 10, 50, 100, 5, new List<Item>()); //�÷��̾� �ʱ�ȭ (���� �� �������� �����ϰ� ���� �����Ƿ� �� ����Ʈ�� �Ѱ��ش�.)

        /*List<Item> weapon = new List<Item>();
        Item stamp = new Item("�����ҳ� ������", 5, 15, 2, 3);
        Item sword = new Item("��� ���", 15, 5, 2, 5);
        Item shield = new Item("���� ����", 1, 10, 5, 0);
        weapon.Add(stamp);
        weapon.Add(sword);
        weapon.Add(shield);*/

        Player.Additem(stamp);
        Player.Additem(sword);
        Player.Additem(shield);

        uiMainMenu.SetCharacterInfo(Player); //ĳ���� ������ �����ϴ� �޼��忡 Player���ڷ� ����
        uiStatus.SetCharacterInfo(Player);
        uiinventory.SetInventory(Player.Inventory);
    }
}
