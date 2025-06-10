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

    public Character Player { get; private set; } //Player 프로퍼티 (캐릭터 정보)

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
        Player = new GameObject("PlayerData").AddComponent<Character>(); //플레이어 생성
        Player.Init("미주", 1, 1000, 10, 50, 100, 5, new List<Item>()); //플레이어 초기화 (시작 시 아이템을 장착하고 싶지 않으므로 빈 리스트를 넘겨준다.)

        /*List<Item> weapon = new List<Item>();
        Item stamp = new Item("마법소녀 스탬프", 5, 15, 2, 3);
        Item sword = new Item("흑색 대검", 15, 5, 2, 5);
        Item shield = new Item("나무 방패", 1, 10, 5, 0);
        weapon.Add(stamp);
        weapon.Add(sword);
        weapon.Add(shield);*/

        Player.Additem(stamp);
        Player.Additem(sword);
        Player.Additem(shield);

        uiMainMenu.SetCharacterInfo(Player); //캐릭터 정보를 세팅하는 메서드에 Player인자로 전달
        uiStatus.SetCharacterInfo(Player);
        uiinventory.SetInventory(Player.Inventory);
    }
}
