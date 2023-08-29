using UnityEngine;
using UnityEngine.UI;

public class Test004Dlg : MonoBehaviour
{
    public Button m_BtnOk = null;
    public Button m_BtnClear = null;
    public InputField m_InpNum = null;
    public Text m_TxtResult = null;
    int result;

    void Start()
    {
        m_BtnOk.onClick.AddListener(OnClicked_Ok);
        m_BtnClear.onClick.AddListener(OnClicked_Clear);
    }

    private void OnClicked_Ok()
    {
        result = 1;
        m_TxtResult.text = "";
        int num = int.Parse(m_InpNum.text);
        if (num > 10 || num < 0)
        {
            m_TxtResult.text = $"0~10 사이의 값을 입력해주세요.";
            return;
        }
        if(num == 0)
        {
            m_TxtResult.text = $"0! = {result}";
            return;
        }
        FactorialFor(num);
        //Factorial(num);
        m_TxtResult.text += $"{result}";
    }

    private void OnClicked_Clear()
    {
        m_TxtResult.text = "Result";
    }
    void FactorialFor(int num)
    {
        result = 1;
        for (int i = num; i >= 1; i--)
        {
            result *= i;
            m_TxtResult.text += $"{i}{(i <= 1 ? " = " : "*")}";
        }
    }
    int Factorial(int num)
    {
        m_TxtResult.text += $"{num}{(num <= 1 ? " = " : "*")}";
        if (num <= 1)
            return 1;
        else
            result *= num;
        return Factorial(num - 1);
    }
}
