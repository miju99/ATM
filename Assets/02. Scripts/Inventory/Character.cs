using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour //캐릭터의 정보를 담고있는 스크립트
{
    public string CharacterID { get; private set; }//캐릭터 이름
    public int level { get; private set; } //캐릭터 레벨
    public int money { get; private set; } //캐릭터 자금

    public int attack { get; private set; } //캐릭터 공격력
    public int defense { get; private set; } //캐릭터 방어력
    public int health { get; private set; } //캐릭터 체력
    public int critical { get; private set; } //캐릭터 치명타

    public List<Item> Inventory = new List<Item>();
    public Item EquippedItem { get; private set; } //장착중인 아이템

    public void Init(string id, int level, int money, int attack, int defense, int health, int critical, List<Item>inventory) //초기화
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

    public void Additem(Item item) //아이템을 인벤토리에 추가
    {
        if(item != null) //아이템이 있으면
        {
            Inventory.Add(item); //인벤토리에 아이템 추가
            Debug.Log($"{item.ItemName} 아이템이 인벤토리에 추가했습니당!");
        }
    }

    public void Equip(Item item) //장비 장착
    {
        if(item != null && Inventory.Contains(item)) //아이템이 있고, 인벤토리 
        {
            if(EquippedItem == item)
            {
                UnEquip(); //같은 아이템이면 장비 해제
                return;
            }

            EquippedItem = item; //아이템 장착
            ApplyItemStats(item);

            Debug.Log($"{item.ItemName} 아이템을 장착했습니당!");

            //InventoryGameManager.Instance.uiStatus.SetItemStats(item);
            InventoryGameManager.Instance.uiStatus.SetCharacterInfo(this);
        }
    }

    public void UnEquip() //장비 탈착
    {
        if(EquippedItem != null) //장착중인 아이템이 있다면
        {
            RemoveItemStats(EquippedItem);
            Debug.Log($"{EquippedItem.ItemName} 아이템을 해제했습니당!");
            EquippedItem = null; //장착 해제

            InventoryGameManager.Instance.uiStatus.SetCharacterInfo(this);
        }
    }

    private void ApplyItemStats(Item item)
    {
        Debug.Log("스탯 더하는 중");
        attack += item.AttackPower;
        defense += item.DefensePower;
        health += item.HpPower;
        critical += item.CriticalPower;
    }

    private void RemoveItemStats(Item item)
    {
        Debug.Log("스탯 빼는 중");
        attack -= item.AttackPower;
        defense -= item.DefensePower;
        health -= item.HpPower;
        critical -= item.CriticalPower;
    }
}
