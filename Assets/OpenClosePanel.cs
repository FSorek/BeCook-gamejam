using UnityEngine;

public abstract class OpenClosePanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void OpenUIPanel()
    {
        _panel.SetActive(true);
    }

    public void CloseUIPanel()
    {
        _panel.SetActive(false);
    }
    
    public void EnableDisablePanel()
    {
        _panel.SetActive(!_panel.activeSelf);
    }
}