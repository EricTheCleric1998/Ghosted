using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameObject winScreenUI;

    void OnTriggerEnter()
    {
        Debug.Log("level won!");
        winScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
