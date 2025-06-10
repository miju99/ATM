using UnityEngine;

public class Item : MonoBehaviour
{
    private string itemName; //필드

    private int attackPower;
    private int defensePower;
    private int hpPower;
    private int criticalPower;

    public string ItemName => itemName; //프로퍼티
    public int AttackPower => attackPower;
    public int DefensePower => defensePower;
    public int HpPower => hpPower;
    public int CriticalPower => criticalPower;

    public Item(string itemName, int attackPower, int defensePower, int hpPower, int criticalPower) //생성자
    {
        this.itemName = itemName;
        this.attackPower = attackPower;
        this.defensePower = defensePower;
        this.hpPower = hpPower;
        this.criticalPower = criticalPower;
    }
}
