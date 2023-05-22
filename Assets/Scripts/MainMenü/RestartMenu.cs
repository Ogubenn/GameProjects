using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    [SerializeField] GameObject rstmenu;
    public void RestartGame()
    {
        Time.timeScale = 1;
        rstmenu.SetActive(false);
        SceneManager.LoadScene("WarpedCity");
    }

    public void QuitGame()
    {
        Debug.Log("çıkış yapıldı");
        Application.Quit();
    }
}
