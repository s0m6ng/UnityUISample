using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Test015Dlg : MonoBehaviour
{
    public Button m_btnOk = null, m_btnClear = null, m_btnAdd = null, m_btnFileSave = null, m_btnFileLoad = null;
    public Text m_txtResult = null, m_txtAddResult = null;
    public InputField m_inpName = null, m_inpKor = null, m_inpEng = null, m_inpMath = null;
    List<Score015> m_ScoreList = new List<Score015>();
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnFileSave.onClick.AddListener(OnClicked_FileSave);
        m_btnFileLoad.onClick.AddListener(OnClicked_FileLoad);
    }

    private void OnClicked_Ok()
    {
        m_txtResult.text = "값이 존재하지 않습니다.";
        if (m_ScoreList.Count > 0)
        {
            List<Score015> tempList = m_ScoreList;
            tempList.Sort((a,b) => a.sum < b.sum ? 1 : -1);
            m_txtResult.text = "이름: 국어, 영어, 수학, 합계, 평균\n";
            m_txtResult.text += "====================================\n";
            float korsum = 0;
            float engsum = 0;
            float mathsum = 0;
            float count = tempList.Count;
            for (int i = 0; i < count; i++)
            {
                Score015 temp = tempList[i];
                korsum += temp.kor;
                engsum += temp.eng;
                mathsum += temp.math;
                m_txtResult.text += $"{i+1}. {temp.name}: {temp.kor}, {temp.eng}, {temp.math}, 합계: {temp.sum}, 평균: {temp.avg:F2}\n";
            }
            m_txtResult.text += "====================================\n";
            m_txtResult.text += "과목별 합계:\n";
            m_txtResult.text += $"국어: 합계={korsum}, 평균: {korsum / count:F2}\n";
            m_txtResult.text += $"영어: 합계={engsum}, 평균: {engsum / count:F2}\n";
            m_txtResult.text += $"수학: 합계={mathsum}, 평균: {mathsum / count:F2}\n";
        }
    }

    private void OnClicked_Clear()
    {
        m_txtResult.text = string.Empty;
        m_txtAddResult.text = "Result";
        m_ScoreList.Clear();
        InpClear();
    }

    private void OnClicked_Add()
    {
        if (InpCheck())
        {
            Score015 temp = new Score015(m_inpName.text, int.Parse(m_inpKor.text), int.Parse(m_inpEng.text), int.Parse(m_inpMath.text));
            m_ScoreList.Add(temp);
            AddResult();
            InpClear();
        }
    }
    void AddResult()
    {
        m_txtAddResult.text = $"이름: 국어, 영어, 수학\n";
        if (m_ScoreList.Count > 0)
        {
            for (int i = 0; i < m_ScoreList.Count; i++)
            {
                Score015 temp = m_ScoreList[i];
                m_txtAddResult.text += $"{temp.name}: {temp.kor}, {temp.eng}, {temp.math}\n";
            }
        }
    }

    private void OnClicked_FileSave()
    {
        StreamWriter sw = new StreamWriter("score015.txt");
        sw.WriteLine(m_ScoreList.Count);
        for (int i = 0; i < m_ScoreList.Count; i++)
        {
            Score015 temp = m_ScoreList[i];
            sw.WriteLine(temp.name);
            sw.WriteLine(temp.kor);
            sw.WriteLine(temp.eng);
            sw.WriteLine(temp.math);
        }
        sw.Close();
    }

    private void OnClicked_FileLoad()
    {
        m_ScoreList.Clear();
        StreamReader sr = new StreamReader("score015.txt");
        int count = int.Parse(sr.ReadLine());
        for (int i = 0; i < count; i++)
        {
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine());
            int eng = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());
            Score015 temp = new Score015(name, kor, eng, math);
            m_ScoreList.Add(temp);
        }
        sr.Close();
        AddResult();
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
                m_txtResult.text = "점수를 0~100사이의 값으로 입력해주세요.";
                return false;
            }
            return true;
        }
        return NumCheck(m_inpKor) && NumCheck(m_inpEng) && NumCheck(m_inpMath);
    }
    void InpClear()
    {
        m_inpName.text = string.Empty;
        m_inpKor.text = string.Empty;
        m_inpEng.text = string.Empty;
        m_inpMath.text = string.Empty;
    }
}
public class Score015
{
    public string name;
    public int kor;
    public int eng;
    public int math;
    public float sum;
    public float avg;
    public Score015(string name, int kor, int eng, int math)
    {
        this.name = name;
        this.kor = kor;
        this.eng = eng;
        this.math = math;
        sum = kor + eng + math;
        avg = sum / 3;
    }
}
