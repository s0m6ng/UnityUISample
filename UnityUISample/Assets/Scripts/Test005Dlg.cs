using UnityEngine;
using UnityEngine.UI;

public class Test005Dlg : MonoBehaviour
{
    public Button m_btnOk = null;
    public Button m_btnClear = null;
    public Text m_txtResult = null;
    int[] Temp = { 100, 200, 300 };
    int[,] array1 = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
    int[,] array2 = new int[2, 2];

    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        array2[0, 0] = 6;
        array2[0, 1] = 8;
        array2[1, 0] = 3;
        array2[1, 1] = 4;
    }

    private void OnClicked_Ok()
    {
        m_txtResult.text = string.Empty;
        /*Test_For();
        Test_While();
        Test_DoWhile();*/
        PrintArr(array1);
        PrintArr(array2);
    }
    void PrintArr(int[,] arr)
    {
        m_txtResult.text += "===============\n";
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                m_txtResult.text += $"arr[{i},{j}] {arr[i, j]}\n";
            }
        }
    }
    void Test_For()
    {
        m_txtResult.text += "===========for¹®===========\n";
        for (int i = 0; i < Temp.Length; i++)
        {
            m_txtResult.text += $"Temp[{i}] = {Temp[i]}{(i == Temp.Length - 1 ? "" : ",")} ";
        }

    }
    void Test_While()
    {
        m_txtResult.text += "\n\n==========while¹®==========\n";
        int i = 0;
        while (i < Temp.Length)
        {
            m_txtResult.text += $"Temp[{i}] = {Temp[i]}{(i == Temp.Length - 1 ? "" : ",")} ";
            i++;
        }
    }
    void Test_DoWhile()
    {
        int i = 0;
        m_txtResult.text += "\n\n=========do-while¹®=========\n";
        do
        {
            m_txtResult.text += $"Temp[{i}] = {Temp[i]}{(i == Temp.Length - 1 ? "" : ",")} ";
            i++;
        }
        while (i < Temp.Length);
    }
    private void OnClicked_Clear()
    {
        m_txtResult.text = "Result";
    }
}
