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

    public Character Player { get; private set; } //Player ������Ƽ (ĳ���� ����)

    private void Start()
    {
        SetData();
    }

    public void SetData()
    {
        Player = new GameObject("PlayerData").AddComponent<Character>(); //�÷��̾� ����
        Player.Init("����", 1, 1000, 10, 50, 100, 5, new List<Item>()); //�÷��̾� �ʱ�ȭ (���� �� �������� �����ϰ� ���� �����Ƿ� �� ����Ʈ�� �Ѱ��ش�.)

        uiMainMenu.SetCharacterInfo(Player); //ĳ���� ������ �����ϴ� �޼��忡 Player���ڷ� ����
        uiStatus.SetCharacterInfo(Player); 
    }
}
