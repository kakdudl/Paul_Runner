using UnityEngine;
using TMPro;

public class PaulLife : MonoBehaviour
{
    public static PaulLife Instance;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private int currentLives = 3;
    //private bool isDrinkingAndDriving;
    private float totalLives;

    public int GetLives()
    {
        return currentLives;
    }

    public void RemoveLife()
    {
        currentLives -= 1;
    }

    public void Awake()
    {
        Instance = this;
        currentLives = 3;
    }

    public void Update()
    {
        if (GetLives() == 1)
            livesText.text = GetLives() + " LIFE";
        else
            livesText.text = GetLives() + " LIVES";
    }

    /*public void StartScript()
    {
        isDrinkingAndDriving = true;
    }*/
}
