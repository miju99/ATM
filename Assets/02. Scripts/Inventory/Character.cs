using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Character : MonoBehaviour //ĳ������ ������ ����ִ� ��ũ��Ʈ
{
    public string CharacterID { get; private set; }//ĳ���� �̸�
    public int level { get; private set; } //ĳ���� ����
    public int money { get; private set; } //ĳ���� �ڱ�

    public int attack { get; private set; } //ĳ���� ���ݷ�
    public int defense { get; private set; } //ĳ���� ����
    public int health { get; private set; } //ĳ���� ü��
    public int critical { get; private set; } //ĳ���� ġ��Ÿ

    public List<Item> Inventory = new List<Item>();
    public Item EquippedItem { get; private set; } //�������� ������

    public void Init(string id, int level, int money, int attack, int defense, int health, int critical, List<Item>inventory) //�ʱ�ȭ
    {
        this.CharacterID = id;
        this.level = level;
        this.money = money;
        this.attack = attack;
        this.defense = defense;
        this.health = health;
        this.critical = critical;
        this.Inventory = inventory;
    }

    public void GetExperience(int amount)
    {

    }

    public void LevelUP()
    {

    }

    public void Additem(Item item) //�������� �κ��丮�� �߰�
    {
        if(item != null) //�������� ������
        {
            Inventory.Add(item); //�κ��丮�� ������ �߰�
            Debug.Log($"{item.ItemName} �������� �κ��丮�� �߰��߽��ϴ�!");
        }
    }

    public void Equip(Item item) //��� ����
    {
        if(item != null && Inventory.Contains(item)) //�������� �ְ�, �κ��丮 
        {
            EquippedItem = item; //������ ����
            //���� ȿ�� ���� ====================================================================================
            Debug.Log($"{item.ItemName} �������� �����߽��ϴ�!");
        }
    }

    public void UnEquip() //��� Ż��
    {
        if(EquippedItem != null) //�������� �������� �ִٸ�
        {
            EquippedItem = null; //���� ����
            Debug.Log($"{EquippedItem.ItemName} �������� �����߽��ϴ�!");
        }
    }
}
