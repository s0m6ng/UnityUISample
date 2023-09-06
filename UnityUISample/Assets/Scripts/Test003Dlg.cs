using UnityEngine;
using UnityEngine.UI;

public class Test003Dlg : MonoBehaviour
{
    public InputField[] m_inpArray = new InputField[3];
    int[] num = new int[3];

    public Text m_txtResult = null;
    public Button m_btnOk = null;
    public Button m_btnClear = null;
    private void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }


    private void OnClicked_Ok()
    {
        if (InpCheck())
        {
            for (int i = 0; i < m_inpArray.Length; i++)
            {
                num[i] = int.Parse(m_inpArray[i].text);
            }
            IfSort();
            m_txtResult.text = $"가장 큰 값: {num[0]}\n";
            for (int i = 0; i < num.Length; i++)
            {
                m_txtResult.text += $"{num[i]}{(i == num.Length - 1 ? "" : ",")}";
            }
        }
    }
    void ForSort()
    {
        for (int i = 0; i < num.Length - 1; i++)
        {
            for (int j = i; j < num.Length; j++)
            {
                if (num[i] < num[j])
                    Swap(ref num[i], ref num[j]);
            }
        }
    }
    void IfSort()
    {
        if (num[0] < num[1])
            Swap(ref num[0], ref num[1]);
        if (num[0] < num[2])
            Swap(ref num[0], ref num[2]);
        if (num[1] < num[2])
            Swap(ref num[1], ref num[2]);
    }
    void Swap(ref int num1, ref int num2)
    {
        int temp;
        temp = num1;
        num1 = num2;
        num2 = temp;
    }
    bool InpCheck()
    {
        for (int i = 0; i < m_inpArray.Length; i++)
        {
            if (string.IsNullOrEmpty(m_inpArray[i].text) || int.Parse(m_inpArray[i].text) < 0 || int.Parse(m_inpArray[i].text) > 100)
            {
                m_txtResult.text = "0 ~ 100 값을 입력해주세요.";
                return false;
            }
        }
        return true;
    }
    private void OnClicked_Clear()
    {
        for (int i = 0; i < m_inpArray.Length; i++)
        {
            m_inpArray[i].text = string.Empty;
        }
        for (int i = 0; i < num.Length; i++)
        {
            num[i] = 0;
        }
        m_txtResult.text = "Result";
    }
}
