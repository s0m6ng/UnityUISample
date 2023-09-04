using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test010Dlg : MonoBehaviour
{
    public InputField m_InpName = null;
    public InputField m_InpWeight = null;
    public Button m_BtnOk = null;
    public Button m_BtnClear = null;
    public Button m_BtnAdd = null;
    public Text m_TxtResult = null;
    List<Animal> m_Animals = new List<Animal>();
    void Start()
    {
        m_BtnOk.onClick.AddListener(OnClicked_Ok);
        m_BtnClear.onClick.AddListener(OnClicked_Clear);
        m_BtnAdd.onClick.AddListener(OnClicked_Add);
    }

    private void OnClicked_Ok()
    {
        switch(m_Animals.Count)
        {
            case 0:
                m_TxtResult.text = $"������ �������� �ʽ��ϴ�.";
                break;
            case 1:
                m_TxtResult.text = $"{m_Animals[0].name}�� �����Դ� {m_Animals[0].weight}Kg �Դϴ�.";
                break;
            case 2:
                m_TxtResult.text = $"{m_Animals[0].name}, {m_Animals[1].name}�� ������ �հ�� {m_Animals[0].weight + m_Animals[1].weight}Kg �Դϴ�.";
                break;
        }
    }

    private void OnClicked_Clear()
    {
        m_Animals.Clear();
        m_InpName.text = string.Empty;
        m_InpWeight.text = string.Empty;
        m_TxtResult.text = "Result";
    }

    private void OnClicked_Add()
    {
        if (InpCheck())
        {
            Animal temp = new Animal(m_InpName.text, int.Parse(m_InpWeight.text));
            m_Animals.Add(temp);
            m_TxtResult.text = $"{temp.name} ({temp.weight}Kg) �߰�";
            m_InpName.text = string.Empty;
            m_InpWeight.text = string.Empty;
        }
    }

    bool InpCheck()
    {
        if (m_Animals.Count >= 2)
        {
            m_TxtResult.text = "������ 2������ �Է¹��� �� �ֽ��ϴ�.";
            return false;
        }
        if (string.IsNullOrEmpty(m_InpName.text) || string.IsNullOrEmpty(m_InpWeight.text))
        {
            m_TxtResult.text = "��� �׸��� �Է����ּ���.";
            return false;
        }
        if(int.Parse(m_InpWeight.text) < 0 || int.Parse(m_InpWeight.text) > 2000)
        {
            m_TxtResult.text = "�����Դ� 0~2000 Kg ���̷� �Է����ּ���.";
            return false;
        }
        return true;
    }
}
public class Animal
{
    public string name;
    public float weight;
    public Animal(string name, float weight)
    {
        this.name = name;
        this.weight = weight;
    }
}
