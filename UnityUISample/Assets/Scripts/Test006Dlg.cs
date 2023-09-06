using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test006Dlg : MonoBehaviour
{
    public Button m_btnOk = null;
    public Button m_btnClear = null;
    public Text m_txtResult = null;
    List<int> m_List1 = new List<int>();
    List<int> m_List2 = new List<int>();
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }
    void Initialize()
    {
        m_txtResult.text = string.Empty;
        m_List1.Clear();
        m_List2.Clear();
        m_List1.Add(10); m_List1.Add(20); m_List1.Add(30);
        m_List2.Add(10); m_List2.Add(20); m_List2.Add(30); m_List2.Add(40); m_List2.Add(50);
    }
    private void OnClicked_Ok()
    {
        Initialize();
        PrintFor(m_List1);
        m_txtResult.text += "[List: foreach문]\n";
        PrintForeach(m_List2);
        m_txtResult.text += "\n[리스트 삭제 - foreach]\n";
        m_List2.Remove(10);
        m_List2.Remove(40);
        PrintForeach(m_List2);
        m_txtResult.text += "\n========================================\n";
    }
    void PrintFor(List<int> list)
    {
        m_txtResult.text += "[List: for문]\n";
        for (int i = 0; i < list.Count; i++)
        {
            m_txtResult.text += $"[{i}]: {list[i]}{(i == list.Count - 1 ? "" : ", ")}";
        }
        m_txtResult.text += "\n========================================\n";
    }
    void PrintForeach(List<int> list)
    {
        foreach (int i in list)
        {
            m_txtResult.text += $"{i}{(i == list[list.Count - 1] ? "" : ",")}";
        }
        m_txtResult.text += "\n";
    }


    private void OnClicked_Clear()
    {
        m_txtResult.text = "Result";
    }
}
