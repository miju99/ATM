using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI AttackPercent; //�÷��̾� ���ݷ�
    [SerializeField]
    private TextMeshProUGUI DefensePercent; //�÷��̾� ����
    [SerializeField]
    private TextMeshProUGUI HealthPercent; //�÷��̾� ü��
    [SerializeField]
    private TextMeshProUGUI CriticalPercent; //�÷��̾� ġ��Ÿ

    [SerializeField]
    private Button BackToMainButton; //�������ͽ� -> ����ȭ�� �̵���ư

    private void Start() //�������ͽ� -> ����ȭ������ �̵�
    {
        BackToMainButton.onClick.AddListener(() =>
        {
            UIManager.Instance.MainMenu.OpenMainMenu();
        });
    }

    public void SetCharacterInfo(Character character) //�������ͽ� �ݿ�
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
