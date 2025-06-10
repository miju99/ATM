using System.Collections.Generic;
using UnityEngine;

public class InventoryGameManager : MonoBehaviour
{
    [SerializeField]
    private Character character;
    [SerializeField]
    private UIMainMenu uiMainMenu;
    [SerializeField]
    private UIStatus uiStatus;

    public Character Player { get; private set; } //Player 프로퍼티 (캐릭터 정보)

    private void Start()
    {
        SetData();
    }

    public void SetData()
    {
        Player = new GameObject("PlayerData").AddComponent<Character>(); //플레이어 생성
        Player.Init("미주", 1, 1000, 10, 50, 100, 5, new List<Item>()); //플레이어 초기화 (시작 시 아이템을 장착하고 싶지 않으므로 빈 리스트를 넘겨준다.)

        uiMainMenu.SetCharacterInfo(Player); //캐릭터 정보를 세팅하는 메서드에 Player인자로 전달
        uiStatus.SetCharacterInfo(Player); 
    }
}
