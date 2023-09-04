using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test011Dlg : MonoBehaviour
{
    public InputField m_InpName = null;
    public InputField m_InpHp = null;
    public Button m_BtnOk = null;
    public Button m_BtnClear = null;
    public Button m_BtnAdd = null;
    public Text m_TxtResult = null;
    public Text m_TxtAddResult = null;
    List<Enemy> m_Enemys = new List<Enemy>();
    void Start()
    {
        m_BtnOk.onClick.AddListener(OnClicked_Ok);
        m_BtnClear.onClick.AddListener(OnClicked_Clear);
        m_BtnAdd.onClick.AddListener(OnClicked_Add);
    }

    private void OnClicked_Ok()
    {
        m_TxtResult.text = string.Empty;
        m_Enemys.Sort((a, b) => a.Hp > b.Hp ? 1 : -1);
        for (int i = 0; i < m_Enemys.Count; i++)
        {
            m_Enemys[i].SetDamage(80);
            m_TxtResult.text += $"{i + 1}. Name={m_Enemys[i].name}, HP={m_Enemys[i].Hp}\n";
        }
    }

    private void OnClicked_Clear()
    {
        m_Enemys.Clear();
        m_InpName.text = string.Empty;
        m_InpHp.text = string.Empty;
        m_TxtResult.text = "Result";
        m_TxtAddResult.text = "Result";
    }

    private void OnClicked_Add()
    {
        if (InpCheck())
        {
            m_TxtAddResult.text = string.Empty;
            Enemy temp = new Enemy(m_InpName.text, int.Parse(m_InpHp.text));
            m_Enemys.Add(temp);
            for (int i = 0; i < m_Enemys.Count; i++)
            {
                m_TxtAddResult.text += $"({m_Enemys[i].name}:{m_Enemys[i].Hp}), ";
            }
            m_InpName.text = string.Empty;
            m_InpHp.text = string.Empty;
        }
    }

    bool InpCheck()
    {
        if (string.IsNullOrEmpty(m_InpName.text) || string.IsNullOrEmpty(m_InpHp.text))
        {
            m_TxtResult.text = "모든 항목을 입력해주세요.";
            return false;
        }
        if (int.Parse(m_InpHp.text) < 0 || int.Parse(m_InpHp.text) > 100)
        {
            m_TxtResult.text = "HP는 0~100 사이로 입력해주세요.";
            return false;
        }
        return true;
    }
}
public class Enemy
{
    public string name;
    public int Hp;
    public Enemy(string name, int Hp)
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
