using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickHidePanel : MonoBehaviour
{
    public GameObject Panel;
    public Button btn;
    private void Start()
    {
        btn.onClick.AddListener(Hide);
    }
    public void Hide()
    {
        Panel.SetActive(false);
    }
    
}
