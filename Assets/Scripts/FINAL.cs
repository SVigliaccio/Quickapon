using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FINAL : MonoBehaviour
{
    public SceneChanger Manager;
    public GameObject Panel;
    public Button btn;
    private void Start()
    {
        btn.onClick.AddListener(FIN);
    }
    public void FIN()
    {
        Manager.ChangeScene("Menu");
    }

}
