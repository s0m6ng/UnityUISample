using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Test017_1Dlg : MonoBehaviour
{
    [Header("InputFiled")]
    [SerializeField] InputField m_inpNum = null;
    [SerializeField] InputField m_inpName = null;
    [SerializeField] InputField m_inpKor = null;
    [SerializeField] InputField m_inpMath = null;
    [SerializeField] InputField m_inpEng = null;
    [Header("Button")]
    [SerializeField] Button m_btnAdd = null;
    [SerializeField] Button m_btnEdit = null;
    [SerializeField] Button m_btnDel = null;
    [SerializeField] Button m_btnSave = null;
    [SerializeField] Button m_btnLoad = null;
    [SerializeField] Button m_btnClear = null;
    [Header("Scroll View")]
    [SerializeField] ScrollRect m_scrScore = null;
    [Header("Other")]
    [SerializeField] GameObject m_ItemPrefab = null;
    public List<Item017_1> m_ItemList = new List<Item017_1>();
    int m_SelectedIdx = -1;

    void Start()
    {
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnEdit.onClick.AddListener(OnClicked_Edit);
        m_btnDel.onClick.AddListener(OnClicked_Del);
        m_btnSave.onClick.AddListener(OnClicked_Save);
        m_btnLoad.onClick.AddListener(OnClicked_Load);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    private void OnClicked_Add()
    {
        if (InpCheck())
        {

            m_ItemList.Add(CreateItem());
            InpClear();
            ItemSort();
        }
    }
    Item017_1 CreateItem(int num = -1, string name = "", int kor = 0, int math = 0, int eng = 0, int idx = -1)
    {
        GameObject go = Instantiate(m_ItemPrefab, m_scrScore.content);
        Item017_1 kItem = go.GetComponent<Item017_1>();
        if (num == -1)
        {
            num = int.Parse(m_inpNum.text);
            name = m_inpName.text;
            kor = int.Parse(m_inpKor.text);
            math = int.Parse(m_inpMath.text);
            eng = int.Parse(m_inpEng.text);
        }
        kItem.Initialize(idx == -1 ? m_ItemList.Count : idx, num, name, kor, math, eng);
        ItemClickedClear();
        Button btn = kItem.GetComponent<Button>();
        btn.onClick.AddListener(() => OnSelected_Item(kItem.m_Score.m_idx));
        return kItem;
    }
    void ItemSort()
    {
        ItemClear();
        m_ItemList.Sort((a, b) => a.m_Score.m_sum < b.m_Score.m_sum ? 1 : -1);
        for (int i = 0; i < m_ItemList.Count; i++)
        {
            Item017_1 temp = m_ItemList[i];
            int idx = i;
            CreateItem(temp.m_Score.m_num, temp.m_Score.m_name, temp.m_Score.m_kor, temp.m_Score.m_math, temp.m_Score.m_eng, idx);
        }
    }
    void InpClear()
    {
        m_inpNum.text = string.Empty;
        m_inpName.text = string.Empty;
        m_inpKor.text = string.Empty;
        m_inpMath.text = string.Empty;
        m_inpEng.text = string.Empty;
    }
    void ItemClear()
    {

        Item017_1[] m_ItemGos = m_scrScore.content.GetComponentsInChildren<Item017_1>();
        for (int i = 0; i < m_ItemGos.Length; i++)
        {
            Destroy(m_ItemGos[i].gameObject);
        }
    }
    void OnSelected_Item(int idx)
    {
        ItemClickedClear();
        print(idx);
        m_SelectedIdx = idx;
        Item017_1 temp = m_ItemList[m_SelectedIdx];
        temp.SetSelectedItem(true);
        m_inpNum.text = temp.m_Score.m_num.ToString();
        m_inpName.text = temp.m_Score.m_name;
        m_inpKor.text = temp.m_Score.m_kor.ToString();
        m_inpMath.text = temp.m_Score.m_math.ToString();
        m_inpEng.text = temp.m_Score.m_eng.ToString();
    }
    void ItemClickedClear()
    {
        for (int i = 0; i < m_ItemList.Count; i++)
        {
            m_ItemList[i].SetSelectedItem(false);
        }
    }
    bool InpCheck()
    {
        if (string.IsNullOrEmpty(m_inpName.text) || string.IsNullOrEmpty(m_inpNum.text))
        {
            return false;
        }
        if (int.Parse(m_inpNum.text) < 1)
        {
            return false;
        }
        bool NumCheck(InputField inp)
        {
            if (string.IsNullOrEmpty(inp.text))
            {
                return false;
            }
            return (int.Parse(inp.text) >= 0 && int.Parse(inp.text) <= 100);
        }
        return NumCheck(m_inpKor) && NumCheck(m_inpMath) && NumCheck(m_inpEng);
    }
    private void OnClicked_Edit()
    {
        if (m_SelectedIdx != -1)
        {
            m_ItemList[m_SelectedIdx].Initialize(m_SelectedIdx, int.Parse(m_inpNum.text), m_inpName.text, int.Parse(m_inpKor.text), int.Parse(m_inpMath.text), int.Parse(m_inpEng.text));
        }
    }

    private void OnClicked_Del()
    {
        if (m_SelectedIdx != -1)
        {
            Destroy(m_ItemList[m_SelectedIdx].gameObject);
            m_ItemList.RemoveAt(m_SelectedIdx);

            Item017_1[] m_ItemGos = m_scrScore.content.GetComponentsInChildren<Item017_1>();
            for (int i = m_SelectedIdx; i < m_ItemGos.Length; i++)
            {
                m_ItemGos[i].m_Score.m_idx--;
            }
            InpClear();
        }
    }

    private void OnClicked_Save()
    {
        StreamWriter sw = new StreamWriter("Score017_1.txt");
        sw.WriteLine(m_ItemList.Count);
        for (int i = 0; i < m_ItemList.Count; i++)
        {
            Item017_1 temp = m_ItemList[i];
            sw.WriteLine(temp.m_Score.m_num);
            sw.WriteLine(temp.m_Score.m_name);
            sw.WriteLine(temp.m_Score.m_kor);
            sw.WriteLine(temp.m_Score.m_math);
            sw.WriteLine(temp.m_Score.m_eng);
        }
        sw.Close();
    }

    private void OnClicked_Load()
    {
        OnClicked_Clear();
        StreamReader sr = new StreamReader("Score017_1.txt");
        int count = int.Parse(sr.ReadLine());
        for (int i = 0; i < count; i++)
        {
            int num = int.Parse(sr.ReadLine());
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());
            int eng = int.Parse(sr.ReadLine());
            m_ItemList.Add(CreateItem(num, name, kor, math, eng));
        }
        sr.Close();
    }

    private void OnClicked_Clear()
    {
        m_ItemList.Clear();
        InpClear();
        ItemClear();
    }
}
