using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Test012Dlg : MonoBehaviour
{
    public InputField m_InpName = null;
    public InputField m_InpKor = null;
    public InputField m_InpEng = null;
    public InputField m_InpMath = null;
    public Button m_BtnOk = null;
    public Button m_BtnClear = null;
    public Text m_TxtResult = null;
    void Start()
    {
        m_BtnOk.onClick.AddListener(OnClicked_Ok);
        m_BtnClear.onClick.AddListener(OnClicked_Clear);
    }

    private void OnClicked_Ok()
    {
        if (InpCheck())
        {
            m_TxtResult.text = string.Empty;
            Score m_score = new Score(m_InpName.text, int.Parse(m_InpKor.text), int.Parse(m_InpEng.text), int.Parse(m_InpMath.text));

            m_TxtResult.text = $"이름: {m_score.Name}\n";
            m_TxtResult.text += $"국어: {m_score.Kor}\n";
            m_TxtResult.text += $"영어: {m_score.Eng}\n";
            m_TxtResult.text += $"수학: {m_score.Math}\n";
            m_TxtResult.text += $"합계: {m_score.Sum}\n";
            m_TxtResult.text += $"평균: {m_score.Avg:F2}\n";
        }
    }

    private void OnClicked_Clear()
    {
        m_InpName.text = string.Empty;
        m_InpKor.text = string.Empty;
        m_InpEng.text = string.Empty;
        m_InpMath.text = string.Empty;
        m_TxtResult.text = "Result";
    }


    bool InpCheck()
    {
        if (string.IsNullOrEmpty(m_InpName.text))
        {
            m_TxtResult.text = "이름을 입력해주세요.";
            return false;
        }
        bool ScoreCheck(InputField inp)
        {
            if (string.IsNullOrEmpty(inp.text))
            {
                m_TxtResult.text = "모든 항목을 입력해주세요.";
                return false;
            }
            if (int.Parse(inp.text) < 0 || int.Parse(inp.text) > 100)
            {
                m_TxtResult.text = "점수는 0~100 사이로 입력해주세요.";
                return false;
            }

            return true;
        }
        return ScoreCheck(m_InpKor) && ScoreCheck(m_InpEng) && ScoreCheck(m_InpMath);
    }
}
public class Score
{
    string m_Name;
    int m_Kor;
    int m_Eng;
    int m_Math;
    float m_Sum;
    float m_Avg;
    public string Name
    {
        get { return m_Name; }
        private set { m_Name = value; }
    }
    public int Kor
    {
        get { return m_Kor; }
        private set { m_Kor = value; }
    }
    public int Eng
    {
        get { return m_Eng; }
        private set { m_Eng = value; }
    }
    public int Math
    {
        get { return m_Math; }
        private set { m_Math = value; }
    }
    public float Sum
    {
        get { return m_Sum; }
        private set { m_Sum = value; }
    }
    public float Avg
    {
        get { return m_Avg; }
        private set { m_Avg = value; }
    }
    public Score(string name, int kor, int eng, int math)
    {
        m_Name = name;
        m_Kor = kor;
        m_Eng = eng;
        m_Math = math;
        m_Sum =GetSum();
        m_Avg = m_Sum / 3;
    }
    float GetSum()
    {
        return m_Kor + m_Eng + m_Math;
    }
}
