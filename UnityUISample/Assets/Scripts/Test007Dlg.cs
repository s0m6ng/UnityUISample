using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test007Dlg : MonoBehaviour
{
    public Button m_btnOk = null;
    public Button m_btnClear = null;
    public Button m_btnAdd = null;
    public InputField m_inpNum = null;
    public Text m_txtAddNumber = null;
    public Text m_txtResult = null;
    List<int> nums = new List<int>();
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_btnAdd.onClick.AddListener(OnClicked_Add);
    }

    private void OnClicked_Add()
    {
        if (string.IsNullOrEmpty(m_inpNum.text) || nums.Count >= 5) return;
        int num = int.Parse(m_inpNum.text);
        if (num < 0 || num > 100) return;
        nums.Add(num);
        m_txtAddNumber.text = PrintList();
    }
    private void OnClicked_Ok()
    {
        m_txtResult.text = string.Empty;
        nums.Sort((a, b) => a > b ? 1 : -1);
        m_txtResult.text = PrintList();
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
        m_txtResult.text = "Result";
        m_txtAddNumber.text = "숫자 리스트";
    }
}
