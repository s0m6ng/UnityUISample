using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test008Dlg : MonoBehaviour
{
    public Button m_btnOk = null;
    public Button m_btnClear = null;
    public Text m_txtResult = null;
    Dictionary<int, string> dict = new Dictionary<int, string>();
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }
    private void OnClicked_Ok()
    {
        dict.Add(1, "���");
        dict.Add(2, "��");
        dict.Add(3, "����");
        m_txtResult.text = $"[ Dictionary - KeyValuePair ]---------------\n";
        PrintDict();
        m_txtResult.text += $"\n\n[�� ���� - key1, key2�� �� ����]----------\n";
        dict[1] = "���ִ� ���";
        dict[2] = "���ִ� ��";
        PrintDict();
        m_txtResult.text += $"\n\n[���� - Key : 1 ���� ]--------------------------\n";
        dict.Remove(1);
        PrintDict();
    }
    void PrintDict()
    {
        string result = string.Empty;
        foreach (KeyValuePair<int, string> kvp in dict)
        {
            result += $"{kvp.Key} : {kvp.Value}, ";
        }
        m_txtResult.text += result;
    }
    private void OnClicked_Clear()
    {
        dict.Clear();
        m_txtResult.text = "Result";
    }
}
