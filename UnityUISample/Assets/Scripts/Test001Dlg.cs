using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test001Dlg : MonoBehaviour
{
    public Button m_btnOk;
    public Button m_btnClear;
    public Text m_Result;
    int A;
    int B;
    private void Start()
    {
        m_btnOk.onClick.AddListener(() => OnClicked_Ok());
        m_btnClear.onClick.AddListener(() => OnClicked_Clear());
    }
    void Swap(ref int n1, ref int n2)
    {
        int temp = n1;
        n1 = n2;
        n2 = temp;
    }
    int Sum(int n1, int n2)
    {
        return n1 + n2;
    }
    void OnClicked_Ok()
    {
        A = 100;
        B = 200;
        m_Result.text = $"--------------------------------";
        m_Result.text += $"гу╟Х: {A+B}\n";
        m_Result.text += $"A: {A} B: {B}\n";
        PrintText();
        Swap(ref A, ref B);
        PrintText();
        m_Result.text += $"--------------------------------";
    }
    void PrintText()
    {
        m_Result.text += $"A: {A} B: {B}\n";
    }
    void OnClicked_Clear()
    {
        m_Result.text = "Result";
    }
}
