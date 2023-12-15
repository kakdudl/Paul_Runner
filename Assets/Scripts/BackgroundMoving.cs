using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    public static BackgroundMoving Instance;
    [Range(-1f,1f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;
    private bool gameHasStarted;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameHasStarted){
            offset += (Time.deltaTime * scrollSpeed) / 10f;
            mat.SetTextureOffset("_MainTex", new Vector2(0, offset));
        }
    }

    public void StartScript(){
        mat = GetComponent<Renderer>().material;
        gameHasStarted = true;
    }
}
