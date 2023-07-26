using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlinkyManager : Singleton<SlinkyManager>
{
    public SlinkySpringMovement HeadRef;
    public SlinkySpringMovement TailRef;

    public GameObject levelCompletePanel;

    public void ToggleSlinkyParts()
    {
        SlinkySpringMovement tempRef = HeadRef;
        HeadRef = TailRef;
        TailRef = tempRef;

        HeadRef.headOrTail = HeadOrTail.Head;
        TailRef.headOrTail = HeadOrTail.Tail;
    }


    public void LevelComplete()
    {
        levelCompletePanel.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

}
