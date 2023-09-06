using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test010Dlg : MonoBehaviour
{
    public InputField m_inpName = null;
    public InputField m_inpWeight = null;
    public Button m_btnOk = null;
    public Button m_btnClear = null;
    public Button m_btnAdd = null;
    public Text m_txtResult = null;
    List<Animal010> m_Animals = new List<Animal010>();
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_btnAdd.onClick.AddListener(OnClicked_Add);
    }

    private void OnClicked_Ok()
    {
        switch(m_Animals.Count)
        {
            case 0:
                m_txtResult.text = $"������ �������� �ʽ��ϴ�.";
                break;
            case 1:
                m_txtResult.text = $"{m_Animals[0].name}�� �����Դ� {m_Animals[0].weight}Kg �Դϴ�.";
                break;
            case 2:
                m_txtResult.text = $"{m_Animals[0].name}, {m_Animals[1].name}�� ������ �հ�� {m_Animals[0].weight + m_Animals[1].weight}Kg �Դϴ�.";
                break;
        }
    }

    private void OnClicked_Clear()
    {
        m_Animals.Clear();
        m_inpName.text = string.Empty;
        m_inpWeight.text = string.Empty;
        m_txtResult.text = "Result";
    }

    private void OnClicked_Add()
    {
        if (InpCheck())
        {
            Animal010 temp = new Animal010(m_inpName.text, int.Parse(m_inpWeight.text));
            m_Animals.Add(temp);
            m_txtResult.text = $"{temp.name} ({temp.weight}Kg) �߰�";
            m_inpName.text = string.Empty;
            m_inpWeight.text = string.Empty;
        }
    }

    bool InpCheck()
    {
        if (m_Animals.Count >= 2)
        {
            m_txtResult.text = "������ 2������ �Է¹��� �� �ֽ��ϴ�.";
            return false;
        }
        if (string.IsNullOrEmpty(m_inpName.text) || string.IsNullOrEmpty(m_inpWeight.text))
        {
            m_txtResult.text = "��� �׸��� �Է����ּ���.";
            return false;
        }
        if(int.Parse(m_inpWeight.text) < 0 || int.Parse(m_inpWeight.text) > 2000)
        {
            m_txtResult.text = "�����Դ� 0~2000 Kg ���̷� �Է����ּ���.";
            return false;
        }
        return true;
    }
}
public class Animal010
{
    public string name;
    public float weight;
    public Animal010(string name, float weight)
    {
        this.name = name;
        this.weight = weight;
    }
}
