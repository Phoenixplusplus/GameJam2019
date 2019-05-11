using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GC : MonoBehaviour
{

    #region MEMBERS
    public FlashProManager FM;

    private int Score1 = 0;
    private int Score2 = 0;

    private float time = 180;

    private TextMeshProUGUI Timer;
    private TextMeshProUGUI P1Score;
    private TextMeshProUGUI P2Score;

    #endregion

    #region Set Singelton
    // --------------------//
    // establish Singelton //
    // ------------------- //
    public static GC Instance
    {
        get
        {
            return instance;
        }
    }
    private static GC instance = null;
    //---------------------------//
    // Finished Singelton set up //
    // --------------------------//
    #endregion


    #region Unity API
    void Awake()
    {
        if (instance)
        {
            Debug.Log("Already a GameController - going to die now .....");
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // As the GC is a pre-fab ... best make it a "hacky - find"
        if (FM == null) FM = FindObjectOfType<FlashProManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUpGUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer != null) Timer.text = "Time Remaining: " + time.ToString();
        if (P1Score != null) P1Score.text = "Score: " + Score1.ToString();
        if (P2Score != null) P2Score.text = "Score: " + Score2.ToString();
    }

    #endregion

    void SetUpGUI()
    {
        GameObject GUIItem1 = FM.AddGUIItem("Score : 0 - 0", 0.5f, 0.5f, 0.25f, Color.white);
        Timer = GUIItem1.GetComponent<TextMeshProUGUI>();

        GameObject GUIItem2 = FM.AddGUIItem("Score : 0", 0.15f, 0.4f, 0.2f, Color.red);
        P1Score = GUIItem2.GetComponent<TextMeshProUGUI>();

        GameObject GUIItem3 = FM.AddGUIItem("Score : 0", 0.85f, 0.6f, 0.2f, Color.blue);
        P2Score = GUIItem3.GetComponent<TextMeshProUGUI>();


    }

    public void score (int player)
    {
        if (player == 1) Score1++;
        if (player == 2) Score2++;
    }

}
