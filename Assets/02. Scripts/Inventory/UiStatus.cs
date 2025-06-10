using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI AttackPercent; //플레이어 공격력
    [SerializeField]
    private TextMeshProUGUI DefensePercent; //플레이어 방어력
    [SerializeField]
    private TextMeshProUGUI HealthPercent; //플레이어 체력
    [SerializeField]
    private TextMeshProUGUI CriticalPercent; //플레이어 치명타

    [SerializeField]
    private Button BackToMainButton; //스테이터스 -> 메인화면 이동버튼

    private void Start() //스테이터스 -> 메인화면으로 이동
    {
        BackToMainButton.onClick.AddListener(() =>
        {
            UIManager.Instance.MainMenu.OpenMainMenu();
        });
    }

    public void SetCharacterInfo(Character character) //스테이터스 반영
    {
        AttackPercent.text = character.attack.ToString();
        DefensePercent.text = character.defense.ToString();
        HealthPercent.text = character.health.ToString();
        CriticalPercent.text = character.critical.ToString();
    }

    /*public void SetItemStats(Item item)
    {
        AttackPercent.text = item.AttackPower.ToString();
        DefensePercent.text = item.DefensePower.ToString();
        HealthPercent.text = item.HpPower.ToString();
        CriticalPercent.text = item.CriticalPower.ToString();
    }*/
}
