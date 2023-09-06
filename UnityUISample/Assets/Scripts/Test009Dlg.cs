using UnityEngine;
using UnityEngine.UI;

public class Test009Dlg : MonoBehaviour
{
    public Button m_btnOk = null;
    public Button m_btnClear = null;
    public Text m_txtResult = null;
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }
    private void OnClicked_Ok()
    {
        Actor m_master = new Actor();
        m_master.m_HP = 5000;
        m_master.m_Attack = 100;
        m_txtResult.text = $"[�⺻ HP={m_master.m_HP}, Attack={m_master.m_Attack}]\n";
        PrintMasterHP(m_master);
        m_txtResult.text += "[������ 50 ����]\n";
        m_master.SetDamage(50);
        PrintMasterHP(m_master);
        m_txtResult.text += "----------------------------\n";

        Actor m_enemy = new Actor();
        m_enemy.m_HP = 2000;
        m_enemy.m_Attack = 200;
        m_txtResult.text += $"[�� HP={m_enemy.m_HP}, Attack={m_enemy.m_Attack} ���� ����]\n";
        PrintEnemyHP(m_enemy);
        m_txtResult.text += "[���� �����Ϳ��� ���ݴ���]\n";
        m_enemy.SetDamage(m_master.m_Attack);
        PrintEnemyHP(m_enemy);
        m_txtResult.text += "----------------------------\n";

        m_txtResult.text += "[�������� HP 100��ŭ ������ ��]\n";
        m_master.SetHeal(100);
        PrintMasterHP(m_master);
        m_txtResult.text += "[���� HP 200��ŭ ������ ��]\n";
        m_enemy.SetHeal(200);
        PrintEnemyHP(m_enemy);
    }
    private void OnClicked_Clear()
    {
        m_txtResult.text = "Result";
    }
    void PrintMasterHP(Actor m_actor)
    {
        m_txtResult.text += $"Master HP = {m_actor.m_HP}\n";
    }
    void PrintEnemyHP(Actor m_actor)
    {
        m_txtResult.text += $"Enemy HP = {m_actor.m_HP}\n";
    }
}
