using UnityEngine;
using UnityEngine.UI;

public class Test002Dlg : MonoBehaviour
{
    public InputField m_inpScore = null;
    public Button m_btnOkIf = null;
    public Button m_btnOkSwitch = null;
    public Button m_btnClear = null;
    public Text m_txtResult = null;
    void Start()
    {
        m_btnOkIf.onClick.AddListener(() => OnClicked_OkIf());
        m_btnOkSwitch.onClick.AddListener(() => OnClicked_OkSwitch());
        m_btnClear.onClick.AddListener(() => OnClicked_Clear());
    }

    void OnClicked_OkIf()
    {
        int score = int.Parse(m_inpScore.text);
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
            m_txtResult.text = $"����� {rank}����Դϴ�.";
        }
    }
    void OnClicked_OkSwitch()
    {
        int score = int.Parse(m_inpScore.text);
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
            m_txtResult.text = $"����� {rank}����Դϴ�.";
        }
    }
    bool ScoreCheck(int value)
    {
        m_txtResult.text = $"������ 0 �̻�, 100 ���Ͽ����մϴ�.";
        return value > 100 || value < 0;
    }
    void OnClicked_Clear()
    {
        m_txtResult.text = "Result";
    }
}
