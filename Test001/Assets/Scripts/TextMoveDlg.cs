using UnityEngine;

public class TextMoveDlg : MonoBehaviour
{
    [SerializeField] GameObject m_TxtResult = null;

    void Update()
    {
        OnMove();
        OnRotate();
        OnScale();
    }
    void OnMove()
    {
        float vx = Input.GetAxis("Horizontal");
        float vy = Input.GetAxis("Vertical");

        m_TxtResult.transform.position += new Vector3(vx, vy, 0);
    }
    void OnRotate()
    {
        if (Input.GetKey(KeyCode.Q))
            m_TxtResult.transform.Rotate(new Vector3(0, 0, 1));

        if (Input.GetKey(KeyCode.E))
            m_TxtResult.transform.Rotate(new Vector3(0, 0, -1));
    }
    void OnScale()
    {
        if (Input.GetMouseButtonDown(0))
            m_TxtResult.transform.localScale += Vector3.one * 0.1f;
        if (Input.GetMouseButtonDown(1))
            m_TxtResult.transform.localScale -= Vector3.one * 0.1f;
    }
}
