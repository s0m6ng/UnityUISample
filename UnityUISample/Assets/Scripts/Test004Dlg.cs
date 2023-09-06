using UnityEngine;
using UnityEngine.UI;

public class Test004Dlg : MonoBehaviour
{
    public Button m_btnOk = null;
    public Button m_btnClear = null;
    public InputField m_inpNum = null;
    public Text m_txtResult = null;
    int result;

    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    private void OnClicked_Ok()
    {
        result = 1;
        m_txtResult.text = "";
        int num = int.Parse(m_inpNum.text);
        if (num > 10 || num < 0)
        {
            m_txtResult.text = $"0~10 사이의 값을 입력해주세요.";
            return;
        }
        if(num == 0)
        {
            m_txtResult.text = $"0! = {result}";
            return;
        }
        FactorialFor(num);
        //Factorial(num);
        m_txtResult.text += $"{result}";
    }

    private void OnClicked_Clear()
    {
        m_txtResult.text = "Result";
    }
    void FactorialFor(int num)
    {
        result = 1;
        for (int i = num; i >= 1; i--)
        {
            result *= i;
            m_txtResult.text += $"{i}{(i <= 1 ? " = " : "*")}";
        }
    }
    int Factorial(int num)
    {
        m_txtResult.text += $"{num}{(num <= 1 ? " = " : "*")}";
        if (num <= 1)
            return 1;
        else
            result *= num;
        return Factorial(num - 1);
    }
}
