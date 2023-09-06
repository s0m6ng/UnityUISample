using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test011Dlg : MonoBehaviour
{
    public InputField m_inpName = null;
    public InputField m_inpHp = null;
    public Button m_btnOk = null;
    public Button m_btnClear = null;
    public Button m_btnAdd = null;
    public Text m_txtResult = null;
    public Text m_txtAddResult = null;
    List<Enemy011> m_Enemys = new List<Enemy011>();
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_btnAdd.onClick.AddListener(OnClicked_Add);
    }

    private void OnClicked_Ok()
    {
        m_txtResult.text = string.Empty;
        m_Enemys.Sort((a, b) => a.Hp > b.Hp ? 1 : -1);
        for (int i = 0; i < m_Enemys.Count; i++)
        {
            m_Enemys[i].SetDamage(80);
            m_txtResult.text += $"{i + 1}. Name={m_Enemys[i].name}, HP={m_Enemys[i].Hp}\n";
        }
    }

    private void OnClicked_Clear()
    {
        m_Enemys.Clear();
        m_inpName.text = string.Empty;
        m_inpHp.text = string.Empty;
        m_txtResult.text = "Result";
        m_txtAddResult.text = "Result";
    }

    private void OnClicked_Add()
    {
        if (InpCheck())
        {
            m_txtAddResult.text = string.Empty;
            Enemy011 temp = new Enemy011(m_inpName.text, int.Parse(m_inpHp.text));
            m_Enemys.Add(temp);
            for (int i = 0; i < m_Enemys.Count; i++)
            {
                m_txtAddResult.text += $"({m_Enemys[i].name}:{m_Enemys[i].Hp}), ";
            }
            m_inpName.text = string.Empty;
            m_inpHp.text = string.Empty;
        }
    }

    bool InpCheck()
    {
        if (string.IsNullOrEmpty(m_inpName.text) || string.IsNullOrEmpty(m_inpHp.text))
        {
            m_txtResult.text = "모든 항목을 입력해주세요.";
            return false;
        }
        if (int.Parse(m_inpHp.text) < 0 || int.Parse(m_inpHp.text) > 100)
        {
            m_txtResult.text = "HP는 0~100 사이로 입력해주세요.";
            return false;
        }
        return true;
    }
}
public class Enemy011
{
    public string name;
    public int Hp;
    public Enemy011(string name, int Hp)
    {
        this.name = name;
        this.Hp = Hp;
    }
    public void SetDamage(int damage)
    {
        Hp -= damage;
        if (Hp < 0) Hp = 0;
    }
}
