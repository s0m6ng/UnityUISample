using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Test018 : MonoBehaviour
{
    [Header("InputField")]
    [SerializeField] InputField m_inpName = null;
    [SerializeField] InputField m_inpNum = null;
    [SerializeField] InputField m_inpCity = null;
    [Space]
    [SerializeField] InputField m_inpSearch = null;
    [Header("Button")]
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] Button m_btnSave = null;
    [SerializeField] Button m_btnLoad = null;
    [SerializeField] Button m_btnAdd = null;
    [SerializeField] Button m_btnSearch = null;
    [Header("Toggle")]
    [SerializeField] Toggle m_tglName = null;
    [SerializeField] Toggle m_tglNum = null;
    [SerializeField] Toggle m_tglCity = null;
    [Header("Other")]
    [SerializeField] Text m_txtResult = null;
    public List<address018> m_AdrList = new List<address018>();
    string line = "--------------------------------------------------------------\n";
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_btnSave.onClick.AddListener(OnClicked_Save);
        m_btnLoad.onClick.AddListener(OnClicked_Load);
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnSearch.onClick.AddListener(OnClicked_Search);
    }

    private void OnClicked_Ok()
    {
        PrintResult(m_AdrList);
    }

    private void OnClicked_Clear()
    {
        m_AdrList.Clear();
        InpClear();
        m_txtResult.text = "Result";
    }

    private void OnClicked_Save()
    {
        StreamWriter sw = new StreamWriter("address018.txt");
        sw.WriteLine(m_AdrList.Count);
        for (int i = 0; i < m_AdrList.Count; i++)
        {
            address018 temp = m_AdrList[i];
            sw.WriteLine(temp.name);
            sw.WriteLine(temp.num);
            sw.WriteLine(temp.city);
        }
        sw.Close();
    }

    private void OnClicked_Load()
    {
        OnClicked_Clear();
        StreamReader sr = new StreamReader("address018.txt");
        int count = int.Parse(sr.ReadLine());
        for (int i = 0; i < count; i++)
        {
            string name = sr.ReadLine();
            string num = sr.ReadLine();
            string city = sr.ReadLine();
            address018 temp = new address018(name,num,city);
            m_AdrList.Add(temp);
        }
        PrintResult(m_AdrList);
    }

    private void OnClicked_Add()
    {
        if (InpCheck())
        {
            address018 temp = new address018(m_inpName.text, m_inpNum.text, m_inpCity.text);
            m_AdrList.Add(temp);
            InpClear();
        }
    }

    private void OnClicked_Search()
    {
        List<address018> tempList = new List<address018>();
        for (int i = 0; i < m_AdrList.Count; i++)
        {
            if ((m_tglName.isOn && m_AdrList[i].name.Contains(m_inpSearch.text)) || (m_tglNum.isOn && m_AdrList[i].num.Contains(m_inpSearch.text)) || (m_tglCity.isOn && m_AdrList[i].city.Contains(m_inpSearch.text)))
            {
                tempList.Add(m_AdrList[i]);
            }
        }
        PrintResult(tempList);
    }
    void PrintResult(List<address018> templist)
    {
        templist = templist.OrderBy(x => x.name).ToList();
        m_txtResult.text = line;
        m_txtResult.text += "순번  이름      전화                  도시\n";
        m_txtResult.text += line;
        for (int i = 0; i < templist.Count; i++)
        {
            address018 temp = templist[i];
            m_txtResult.text += $"{i + 1}.     {temp.name}  {temp.num}  {temp.city}\n";
            m_txtResult.text += line;
        }
    }
    void InpClear()
    {
        m_inpName.text = string.Empty;
        m_inpNum.text = string.Empty;
        m_inpCity.text = string.Empty;
        m_inpSearch.text = string.Empty;
    }
    bool InpCheck()
    {
        if (string.IsNullOrEmpty(m_inpName.text) || string.IsNullOrEmpty(m_inpNum.text) || string.IsNullOrEmpty(m_inpCity.text))
            return false;
        /*if (m_inpNum.text.Length != 13)
            return false;*/
        return true;
    }
}
public class address018
{
    public string name;
    public string num;
    public string city;
    public address018(string name, string num, string city)
    {
        this.name = name;
        this.num = num;
        this.city = city;
    }
}
