using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Test016Dlg : MonoBehaviour
{
    [SerializeField] Button m_BtnOk = null;
    [SerializeField] Button m_BtnClear = null;
    [SerializeField] Button m_BtnAdd = null;
    [SerializeField] Button m_BtnFileSave = null;
    [SerializeField] Button m_BtnFileLoad = null;
    [SerializeField] Text m_TxtResult = null;
    [SerializeField] Text m_TxtAddResult = null;
    [SerializeField] InputField m_InpName = null;
    [SerializeField] InputField m_InpKor = null;
    [SerializeField] InputField m_InpEng = null;
    [SerializeField] InputField m_InpMath = null;
    List<Score016> m_ScoreList = new List<Score016>();
    void Start()
    {
        m_BtnOk.onClick.AddListener(OnClicked_Ok);
        m_BtnClear.onClick.AddListener(OnClicked_Clear);
        m_BtnAdd.onClick.AddListener(OnClicked_Add);
        m_BtnFileSave.onClick.AddListener(OnClicked_FileSave);
        m_BtnFileLoad.onClick.AddListener(OnClicked_FileLoad);
        PrintAddResult();
    }

    private void OnClicked_Ok()
    {
        m_TxtResult.text = "값이 존재하지 않습니다.";
        if (m_ScoreList.Count > 0)
        {
            m_TxtResult.text = "[성적관리]\n";
            m_TxtResult.text += "==============================\n";
            List<Score016> tempList = m_ScoreList;
            tempList.Sort((a, b) => a.sum < b.sum ? 1 : -1);
            float korsum = 0;
            float engsum = 0;
            float mathsum = 0;
            float listCount = tempList.Count;
            for (int i = 0; i < listCount; i++)
            {
                Score016 temp = tempList[i];
                korsum += temp.kor;
                engsum += temp.eng;
                mathsum += temp.math;
                m_TxtResult.text += $"{i + 1}. {temp.name}: {temp.kor}, {temp.eng}, {temp.math}, 합계={temp.sum}, 평균={temp.avg:F2}\n";
            }
            m_TxtResult.text += "==============================\n";
            m_TxtResult.text += "[과목별 합계]\n";
            m_TxtResult.text += $"국어({korsum}, {korsum / listCount:F2}), 영어({engsum}, {engsum / listCount:F2}), 수학({mathsum}, {mathsum / listCount:F2})\n";
        }
    }

    private void OnClicked_Clear()
    {
        InpClear();
        m_TxtResult.text = string.Empty;
        m_TxtAddResult.text = string.Empty;
        m_ScoreList.Clear();
    }

    private void OnClicked_Add()
    {
        if (InpCheck())
        {
            Score016 temp = new Score016(m_InpName.text, int.Parse(m_InpKor.text), int.Parse(m_InpEng.text), int.Parse(m_InpMath.text));
            m_ScoreList.Add(temp);
            InpClear();
            PrintAddResult();
        }
    }

    private void OnClicked_FileSave()
    {
        StreamWriter sw = new StreamWriter("Score016.txt");
        sw.WriteLine(m_ScoreList.Count);
        for (int i = 0; i < m_ScoreList.Count; i++)
        {
            Score016 temp = m_ScoreList[i];
            sw.WriteLine(temp.name);
            sw.WriteLine(temp.kor);
            sw.WriteLine(temp.eng);
            sw.WriteLine(temp.math);
        }
        m_TxtResult.text = "파일이 저장되었습니다.";
        sw.Close();
    }

    private void OnClicked_FileLoad()
    {
        m_ScoreList.Clear();
        StreamReader sr = new StreamReader("Score016.txt");
        int count = int.Parse(sr.ReadLine());
        for (int i = 0; i < count; i++)
        {
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine());
            int eng = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());
            Score016 temp = new Score016(name, kor, eng, math);
            m_ScoreList.Add(temp);
        }
        PrintAddResult();
        m_TxtResult.text = "파일을 불러왔습니다.";
        sr.Close();

    }
    void InpClear()
    {
        m_InpName.text = string.Empty;
        m_InpKor.text = string.Empty;
        m_InpEng.text = string.Empty;
        m_InpMath.text = string.Empty;
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
                m_TxtResult.text = "점수를 모두 입력해주세요.";
                return false;
            }
            if (int.Parse(inp.text) < 0 || int.Parse(inp.text) > 100)
            {
                m_TxtResult.text = "점수는 0~100 사이의 값을 입력해주세요.";
                return false;
            }
            return true;
        }
        return ScoreCheck(m_InpKor) && ScoreCheck(m_InpEng) && ScoreCheck(m_InpMath);
    }
    void PrintAddResult()
    {
        m_TxtAddResult.text = "이름: 국어, 영어, 수학\n";
        for (int i = 0; i < m_ScoreList.Count; i++)
        {
            Score016 temp = m_ScoreList[i];
            m_TxtAddResult.text += $"{temp.name}: {temp.kor}, {temp.eng}, {temp.math}\n";
        }
    }
}
public class Score016
{
    public string name;
    public int kor;
    public int eng;
    public int math;
    public float sum;
    public float avg;

    public Score016(string vname, int vkor, int veng, int vmath)
    {
        name = vname;
        kor = vkor;
        eng = veng;
        math = vmath;
        sum = kor + eng + math;
        avg = sum / 3;
    }
}