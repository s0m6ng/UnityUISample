using UnityEngine;
using UnityEngine.UI;

public class Test012Dlg : MonoBehaviour
{
    public InputField m_inpName = null;
    public InputField m_inpKor = null;
    public InputField m_inpEng = null;
    public InputField m_inpMath = null;
    public Button m_btnOk = null;
    public Button m_btnClear = null;
    public Text m_txtResult = null;
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    private void OnClicked_Ok()
    {
        if (InpCheck())
        {
            m_txtResult.text = string.Empty;
            Score012 m_score = new Score012(m_inpName.text, int.Parse(m_inpKor.text), int.Parse(m_inpEng.text), int.Parse(m_inpMath.text));

            m_txtResult.text = $"이름: {m_score.Name}\n";
            m_txtResult.text += $"국어: {m_score.Kor}\n";
            m_txtResult.text += $"영어: {m_score.Eng}\n";
            m_txtResult.text += $"수학: {m_score.Math}\n";
            m_txtResult.text += $"합계: {m_score.Sum}\n";
            m_txtResult.text += $"평균: {m_score.Avg:F2}\n";
        }
    }

    private void OnClicked_Clear()
    {
        m_inpName.text = string.Empty;
        m_inpKor.text = string.Empty;
        m_inpEng.text = string.Empty;
        m_inpMath.text = string.Empty;
        m_txtResult.text = "Result";
    }


    bool InpCheck()
    {
        if (string.IsNullOrEmpty(m_inpName.text))
        {
            m_txtResult.text = "이름을 입력해주세요.";
            return false;
        }
        bool ScoreCheck(InputField inp)
        {
            if (string.IsNullOrEmpty(inp.text))
            {
                m_txtResult.text = "모든 항목을 입력해주세요.";
                return false;
            }
            if (int.Parse(inp.text) < 0 || int.Parse(inp.text) > 100)
            {
                m_txtResult.text = "점수는 0~100 사이로 입력해주세요.";
                return false;
            }

            return true;
        }
        return ScoreCheck(m_inpKor) && ScoreCheck(m_inpEng) && ScoreCheck(m_inpMath);
    }
}
public class Score012
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
    public Score012(string name, int kor, int eng, int math)
    {
        m_Name = name;
        m_Kor = kor;
        m_Eng = eng;
        m_Math = math;
        m_Sum = GetSum();
        m_Avg = m_Sum / 3;
    }
    float GetSum()
    {
        return m_Kor + m_Eng + m_Math;
    }
}
