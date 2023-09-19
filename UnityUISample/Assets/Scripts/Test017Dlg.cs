using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Test017Dlg : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] Button m_btnAdd = null;
    [SerializeField] Button m_btnFileSave = null;
    [SerializeField] Button m_btnFileLoad = null;
    [Header("InputField")]
    [SerializeField] InputField m_inpName = null;
    [SerializeField] InputField m_inpKor = null;
    [SerializeField] InputField m_inpEng = null;
    [SerializeField] InputField m_inpMath = null;
    [Header("Text")]
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Text m_txtAddResult = null;
    List<Score017> m_ScoreList = new List<Score017>();
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnFileSave.onClick.AddListener(OnClicked_Save);
        m_btnFileLoad.onClick.AddListener(OnClicked_Load);
    }

    private void OnClicked_Ok()
    {
        m_txtResult.text = "값이 존재하지 않습니다.";
        if (m_ScoreList.Count > 0)
        {
            m_txtResult.text = "순위  이름  국어  영어  수학  평균\n";
            m_txtResult.text += "===============================\n";
            List<Score017> tempList = m_ScoreList;
            m_ScoreList.Sort((a, b) => a.sum < b.sum ? 1 : -1);
            for (int i = 0; i < tempList.Count; i++)
            {
                Score017 temp = tempList[i];
                m_txtResult.text += $"{i + 1}등: {temp.name}         {Rank(temp.kor)}    {Rank(temp.eng)}    {Rank(temp.math)}   < {Rank(temp.avg)} >\n";
            }
        }
    }
    string Rank(int num)
    {
        switch (num)
        {
            case >= 90:
                return "A";
            case >= 80:
                return "B";
            case >= 70:
                return "C";
            case >= 60:
                return "D";
            default:
                return "F";
        }
    }
    private void OnClicked_Clear()
    {
        m_txtAddResult.text = string.Empty;
        m_txtResult.text = string.Empty;
        m_ScoreList.Clear();
        InpClear();
    }
    void InpClear()
    {
        m_inpName.text = string.Empty;
        m_inpKor.text = string.Empty;
        m_inpEng.text = string.Empty;
        m_inpMath.text = string.Empty;
    }
    bool InpCheck()
    {
        if (string.IsNullOrEmpty(m_inpName.text))
        {
            m_txtResult.text = "이름을 입력해주세요.";
            return false;
        }
        bool NumCheck(InputField inp)
        {
            if (string.IsNullOrEmpty(inp.text))
            {
                m_txtResult.text = "점수를 모두 입력해주세요.";
                return false;
            }
            if (int.Parse(inp.text) < 0 || int.Parse(inp.text) > 100)
            {
                m_txtResult.text = "점수는 0~100 사이의 값을 입력해주세요.";
                return false;
            }
            return true;
        }
        return NumCheck(m_inpKor) && NumCheck(m_inpEng) && NumCheck(m_inpMath);
    }
    private void OnClicked_Add()
    {
        if (InpCheck())
        {
            Score017 temp = new Score017(m_inpName.text, int.Parse(m_inpKor.text), int.Parse(m_inpEng.text), int.Parse(m_inpMath.text));
            m_ScoreList.Add(temp);
            PrintAddResult();
            InpClear();
        }
    }
    void PrintAddResult()
    {
        m_txtAddResult.text = "이름: 국어, 영어, 수학\n";
        for (int i = 0; i < m_ScoreList.Count; i++)
        {
            Score017 temp = m_ScoreList[i];
            m_txtAddResult.text += $"{temp.name}: {temp.kor}, {temp.eng}, {temp.math}\n";
        }
    }
    private void OnClicked_Save()
    {
        StreamWriter sw = new StreamWriter("Score017.txt");
        sw.WriteLine(m_ScoreList.Count);
        for (int i = 0; i < m_ScoreList.Count; i++)
        {
            Score017 temp = m_ScoreList[i];
            sw.WriteLine(temp.name);
            sw.WriteLine(temp.kor);
            sw.WriteLine(temp.eng);
            sw.WriteLine(temp.math);
        }
        sw.Close();
    }

    private void OnClicked_Load()
    {
        m_ScoreList.Clear();
        StreamReader sr = new StreamReader("Score017.txt");
        int count = int.Parse(sr.ReadLine());
        for (int i = 0; i < count; i++)
        {
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine());
            int eng = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());
            Score017 temp = new Score017(name, kor, eng, math);
            m_ScoreList.Add(temp);
        }
        PrintAddResult();
        sr.Close();
    }
}
public class Score017
{
    public string name;
    public int kor;
    public int eng;
    public int math;
    public int sum;
    public int avg;

    public Score017(string name, int kor, int eng, int math)
    {
        this.name = name;
        this.kor = kor;
        this.eng = eng;
        this.math = math;
        this.sum = kor + eng + math;
        this.avg = sum / 3;
    }
}
