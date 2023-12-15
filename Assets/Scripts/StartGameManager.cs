using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    [SerializeField] private MoveTowards[] movingBackgrounds;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) || (Input.touchCount > 0))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        SpawnManager.Instance.StartScript();
        KMManager.Instance.StartScript();
        BackgroundMoving.Instance.StartScript();

        foreach (MoveTowards m in movingBackgrounds)
        {
            m.StartScript();
        }
        
        enabled = false;
    }
}
