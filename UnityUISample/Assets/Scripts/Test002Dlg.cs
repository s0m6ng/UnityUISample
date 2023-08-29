using UnityEngine;
using UnityEngine.UI;

public class Test002Dlg : MonoBehaviour
{
    public InputField m_InpScore = null;
    public Button m_BtnOkIf = null;
    public Button m_BtnOkSwitch = null;
    public Button m_BtnClear = null;
    public Text m_TxtResult = null;
    void Start()
    {
        m_BtnOkIf.onClick.AddListener(() => OnClicked_OkIf());
        m_BtnOkSwitch.onClick.AddListener(() => OnClicked_OkSwitch());
        m_BtnClear.onClick.AddListener(() => OnClicked_Clear());
    }

    void OnClicked_OkIf()
    {
        int score = int.Parse(m_InpScore.text);
        if (ScoreCheck(score))
        {
            string rank = "";
            if (score >= 90)
                rank = "A";
            else if (score >= 80)
                rank = "B";
            else if (score >= 70)
                rank = "C";
            else if (score >= 60)
                rank = "D";
            else
                rank = "E";
            m_TxtResult.text = $"당신은 {rank}등급입니다.";
        }
    }
    void OnClicked_OkSwitch()
    {
        int score = int.Parse(m_InpScore.text);
        if (ScoreCheck(score))
        {
            string rank = "";
            switch (score)
            {
                case >= 90:
                    rank = "A";
                    break;
                case >= 80:
                    rank = "B";
                    break;
                case >= 70:
                    rank = "C";
                    break;
                case >= 60:
                    rank = "D";
                    break;
                default:
                    rank = "E";
                    break;
            }
            m_TxtResult.text = $"당신은 {rank}등급입니다.";
        }
    }
    bool ScoreCheck(int value)
    {
        m_TxtResult.text = $"점수는 0 이상, 100 이하여야합니다.";
        return value > 100 || value < 0;
    }
    void OnClicked_Clear()
    {
        m_TxtResult.text = "Result";
    }
}
