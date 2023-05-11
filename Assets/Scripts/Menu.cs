using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] float playLeanValue;
    [SerializeField] float settingsLeanValue;

    public void OpenSettings()
    {
        transform.LeanMoveLocal(new Vector2(settingsLeanValue, 0), 1).setEaseOutQuart();
    }

    public void CloseSettings()
    {
        transform.LeanMoveLocal(new Vector2(0, 0), 1).setEaseOutQuart();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenPlay()
    {
        transform.LeanMoveLocal(new Vector2(0, playLeanValue), 1).setEaseOutQuart();
    }

    public void ClosePlay()
    {
        transform.LeanMoveLocal(new Vector2(0, 0), 1).setEaseOutQuart();
    }

    public void PlayNormal()
    {
        SceneManager.LoadScene("Normal");
    }

    public void PlayPathless()
    {
        SceneManager.LoadScene("Pathless");
    }
}
