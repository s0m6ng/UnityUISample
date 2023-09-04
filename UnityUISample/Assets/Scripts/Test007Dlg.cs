using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test007Dlg : MonoBehaviour
{
    public Button m_BtnOk = null;
    public Button m_BtnClear = null;
    public Button m_BtnAdd = null;
    public InputField m_InpNum = null;
    public Text m_TxtAddNumber = null;
    public Text m_TxtResult = null;
    List<int> nums = new List<int>();
    void Start()
    {
        m_BtnOk.onClick.AddListener(OnClicked_Ok);
        m_BtnClear.onClick.AddListener(OnClicked_Clear);
        m_BtnAdd.onClick.AddListener(OnClicked_Add);
    }

    private void OnClicked_Add()
    {
        if (string.IsNullOrEmpty(m_InpNum.text) || nums.Count >= 5) return;
        int num = int.Parse(m_InpNum.text);
        if (num < 0 || num > 100) return;
        nums.Add(num);
        m_TxtAddNumber.text = PrintList();
    }
    private void OnClicked_Ok()
    {
        m_TxtResult.text = string.Empty;
        nums.Sort((a, b) => a > b ? 1 : -1);
        m_TxtResult.text = PrintList();
    }
    string PrintList()
    {
        string result = string.Empty;
        for (int i = 0; i < nums.Count; i++)
        {
            result += $"{nums[i]}{(i == nums.Count - 1 ? "" : ",")} ";
        }
        return result;
    }
    private void OnClicked_Clear()
    {
        nums.Clear();
        m_TxtResult.text = "Result";
        m_TxtAddNumber.text = "숫자 리스트";
    }
}
