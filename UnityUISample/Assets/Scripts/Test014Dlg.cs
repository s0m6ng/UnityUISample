using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Test014Dlg : MonoBehaviour
{
    public Button m_btnOk = null;
    public Button m_btnClear = null;
    public Button m_btnAdd = null;
    public Button m_btnOpen = null;
    public Text m_txtAddResult = null;
    public Text m_txtResult = null;
    public InputField m_inpName = null;
    public InputField m_inpKor = null;
    public InputField m_inpEng = null;
    public InputField m_inpMath = null;
    List<Score014> m_scoreList = new List<Score014>();
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnOpen.onClick.AddListener(FileLoad);
    }

    private void OnClicked_Ok()
    {
        if (m_scoreList.Count > 0)
        {
            List<Score014> tempList = m_scoreList;
            tempList.Sort((a, b) => a.sum < b.sum ? 1 : -1);
            float korsum = 0;
            float engsum = 0;
            float mathsum = 0;
            m_txtResult.text = "[성적 관리]\n";
            m_txtResult.text += "======================================\n";
            for (int i = 0; i < tempList.Count; i++)
            {
                Score014 temp = tempList[i];
                korsum += temp.kor;
                engsum += temp.eng;
                mathsum += temp.math;
                m_txtResult.text += $"{i+1}. {temp.name}: {temp.kor}, {temp.eng}, {temp.math} 합계: {temp.sum}, 평균: {temp.avg:F2}\n";
            }
            m_txtResult.text += "======================================\n";
            m_txtResult.text += $"[과목별 합계]\n국어:({korsum}, {korsum / tempList.Count:F2}) 수학:({mathsum}, {mathsum / tempList.Count:F2}) 영어:({engsum}, {engsum / tempList.Count:F2})\n";
            FileSave();
        }
        else
            m_txtResult.text = "값이 존재하지 않습니다.";
    }

    private void OnClicked_Clear()
    {
        InpClear();
        m_txtAddResult.text = string.Empty;
        m_txtResult.text = string.Empty;
        m_scoreList.Clear();
    }
    void InpClear()
    {
        m_inpName.text = string.Empty;
        m_inpKor.text = string.Empty;
        m_inpEng.text = string.Empty;
        m_inpMath.text = string.Empty;
    }
    private void OnClicked_Add()
    {
        if (InpCheck())
        {
            if (m_scoreList.Count == 0)
                m_txtAddResult.text = string.Empty;
            Score014 temp = new Score014(m_inpName.text, int.Parse(m_inpKor.text), int.Parse(m_inpEng.text), int.Parse(m_inpMath.text));
            m_scoreList.Add(temp);
            m_txtAddResult.text += $"{temp.name}: {temp.kor}, {temp.eng}, {temp.math}\n";
            InpClear();
        }
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
                m_txtResult.text = "점수를 모두 입력해주세요.";
                return false;
            }
            if (int.Parse(inp.text) < 0 || int.Parse(inp.text) > 100)
            {
                m_txtResult.text = "점수는 0~100사이의 값을 입력해주세요.";
                return false;
            }
            return true;
        }
        return ScoreCheck(m_inpKor) && ScoreCheck(m_inpEng) && ScoreCheck(m_inpMath);
    }
    void FileSave()
    {
        StreamWriter sw = new StreamWriter("score014.txt");
        sw.WriteLine(m_scoreList.Count);
        for (int i = 0; i < m_scoreList.Count; i++)
        {
            Score014 temp = m_scoreList[i];
            sw.WriteLine(temp.name);
            sw.WriteLine(temp.kor);
            sw.WriteLine(temp.eng);
            sw.WriteLine(temp.math);
        }
        sw.Close();
    }
    void FileLoad()
    {
        OnClicked_Clear();
        StreamReader sr = new StreamReader("score014.txt");
        int count = int.Parse(sr.ReadLine());
        for (int i = 0; i < count; i++)
        {
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine());
            int eng = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());
            Score014 temp = new Score014(name, kor, eng, math);
            m_scoreList.Add(temp);
            m_txtAddResult.text += $"{name}: {kor}, {eng}, {math}\n";
        }
        sr.Close();
    }
}
public class Score014
{
    public string name;
    public int kor;
    public int eng;
    public int math;
    public float sum;
    public float avg;

    public Score014(string name, int kor, int eng, int math)
    {
        this.name = name;
        this.kor = kor;
        this.eng = eng;
        this.math = math;
        sum = kor + eng + math;
        avg = sum / 3;
    }
}
