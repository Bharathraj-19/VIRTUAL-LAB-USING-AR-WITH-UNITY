using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
   public void quit()
    {
        Application.Quit();
    }
    public void openlink()
    {
        Application.OpenURL("https://github.com/Bharathraj-19/VIRTUAL-LAB-USING-AR-WITH-UNITY.git");
    }
    public void PlayDiodeScene()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayZenerScene()
    {
        SceneManager.LoadScene(2);
    }
    public void returnToList()
    {
        SceneManager.LoadScene(0);
    }
}
