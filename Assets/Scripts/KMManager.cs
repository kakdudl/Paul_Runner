using UnityEngine;
using TMPro;

public class KMManager : MonoBehaviour
{
    public static KMManager Instance;
    public const string prefKM = "prefKM";
    [SerializeField] private TextMeshProUGUI kmText;
    private float kmTraveled;
    private bool isTraveling;

    [SerializeField] private float kmTraveledSpeedMultiplierMultiplier;
    [SerializeField] private float kmTraveledSpeedMultiplier;
    [SerializeField] private float kmTraveledSpeedMultiplierMax;
    private bool isSpeedingUp;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (!isTraveling)
            return;
        
        kmTraveled += Time.deltaTime * kmTraveledSpeedMultiplier;
        kmText.text = (int)kmTraveled + "KM";

        if (isSpeedingUp)
            SpeedUp();
        
    }

    public void StartScript()
    {
        isTraveling = true;
        isSpeedingUp = true;
    }

    public void SpeedUp()
    {
        if (Time.timeScale == 0)
            return;
        
        kmTraveledSpeedMultiplier *= kmTraveledSpeedMultiplierMultiplier;

        if (kmTraveledSpeedMultiplier >= kmTraveledSpeedMultiplierMax)
        {
            kmTraveledSpeedMultiplier = kmTraveledSpeedMultiplierMax;
            isSpeedingUp = false;
        }
    }

    public bool CheckNewHighscore()
    {
        if ((int)kmTraveled > PlayerPrefs.GetInt(prefKM))
        {
            //new highscore
            PlayerPrefs.SetInt(prefKM, (int)kmTraveled);
            Debug.Log("New Highscore: " + (int)kmTraveled);
            return true;
        }
        else
        {
            //no new highscore
            Debug.Log("No new highscore");
            return false;
        }
    }
}
