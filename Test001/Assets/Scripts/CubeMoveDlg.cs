using UnityEngine;

public class CubeMoveDlg : MonoBehaviour
{
    [SerializeField] GameObject m_GoCube = null;

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

        m_GoCube.transform.position += new Vector3(vx, vy, 0) * Time.deltaTime * 10;
    }
    void OnRotate()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            m_GoCube.transform.Rotate(new Vector3(1, 0, 0) * (Input.GetKey(KeyCode.LeftShift) ? 1 : -1));

        if (Input.GetKey(KeyCode.Alpha2))
            m_GoCube.transform.Rotate(new Vector3(0, 1, 0) * (Input.GetKey(KeyCode.LeftShift) ? 1 : -1));

        if (Input.GetKey(KeyCode.Alpha3))
            m_GoCube.transform.Rotate(new Vector3(0, 0, 1) * (Input.GetKey(KeyCode.LeftShift) ? 1 : -1));
    }
    void OnScale()
    {
        if (Input.GetMouseButtonDown(0))
            m_GoCube.transform.localScale += Vector3.one * 0.1f;
        if (Input.GetMouseButtonDown(1))
            m_GoCube.transform.localScale -= Vector3.one * 0.1f;
    }
}
