using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test008Dlg : MonoBehaviour
{
    public Button m_BtnOk = null;
    public Button m_BtnClear = null;
    public Text m_TxtResult = null;
    Dictionary<int, string> dict = new Dictionary<int, string>();
    void Start()
    {
        m_BtnOk.onClick.AddListener(OnClicked_Ok);
        m_BtnClear.onClick.AddListener(OnClicked_Clear);
    }
    private void OnClicked_Ok()
    {
        dict.Add(1, "사과");
        dict.Add(2, "배");
        dict.Add(3, "수박");
        m_TxtResult.text = $"[ Dictionary - KeyValuePair ]---------------\n";
        PrintDict();
        m_TxtResult.text += $"\n\n[값 변경 - key1, key2의 값 변경]----------\n";
        dict[1] = "맛있는 사과";
        dict[2] = "맛있는 배";
        PrintDict();
        m_TxtResult.text += $"\n\n[삭제 - Key : 1 삭제 ]--------------------------\n";
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
        m_TxtResult.text += result;
    }
    private void OnClicked_Clear()
    {
        dict.Clear();
        m_TxtResult.text = "Result";
    }
}
