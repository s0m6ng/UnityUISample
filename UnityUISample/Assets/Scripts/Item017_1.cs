using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item017_1 : MonoBehaviour
{
    [SerializeField] Text m_txtNum = null;
    [SerializeField] Text m_txtName = null;
    [SerializeField] Text m_txtKor = null;
    [SerializeField] Text m_txtMath = null;
    [SerializeField] Text m_txtEng = null;
    [SerializeField] Text m_txtSum = null;
    [SerializeField] Text m_txtAvg = null;
    public Score017_1 m_Score;
    Image m_imgBG = null;
    private void Awake()
    {
        m_imgBG = GetComponent<Image>();
    }
    public void Initialize(int idx, int num, string name, int kor, int math, int eng)
    {
        Score017_1 temp = new Score017_1(idx, num, name, kor, math, eng);
        m_Score = temp;
        m_txtNum.text = temp.m_num.ToString();
        m_txtName.text = temp.m_name;
        m_txtKor.text = temp.m_kor.ToString();
        m_txtMath.text = temp.m_math.ToString();
        m_txtEng.text = temp.m_eng.ToString();
        m_txtSum.text = temp.m_sum.ToString();
        m_txtAvg.text = temp.m_avg.ToString("F2");
    }
    public void SetSelectedItem(bool bValue)
    {
        if (bValue)
        {
            m_imgBG.color = Color.green;
        }
        else
            m_imgBG.color = Color.white;
    }
}
public class Score017_1
{
    public int m_idx;
    public int m_num;
    public string m_name;
    public int m_kor;
    public int m_math;
    public int m_eng;
    public float m_sum;
    public float m_avg;
    public Score017_1(int idx, int num, string name, int kor, int math, int eng)
    {
        m_idx = idx;
        m_num = num;
        m_name = name;
        m_kor = kor;
        m_math = math;
        m_eng = eng;
        m_sum = kor + eng + math;
        m_avg = m_sum / 3;
    }
}