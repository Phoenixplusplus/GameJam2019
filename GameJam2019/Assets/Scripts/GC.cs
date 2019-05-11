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

    private string[] gratz = new string[] { "Brill", "Magic", "Super", "Great", "Gratz" };

    private FlashProTemplate p11;
    private FlashProTemplate p12;
    private FlashProTemplate p21;
    private FlashProTemplate p22;


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
        SetFlashes();
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
        if (player == 1)
        {
            Score1++;
            if (Random.Range(0, 1) < 0.5) FM.CustomFlash(p11, "Great");
            else { FM.CustomFlash(p12, "Super"); }
        }
        if (player == 2)
        {
            Score2++;
            if (Random.Range(0, 1) < 0.5) FM.CustomFlash(p21, "Magic");
            else { FM.CustomFlash(p22, "Class"); }
        }
    }

    void SetFlashes()
    {
        p11 = new FlashProTemplate();
        p11.StartPos = new Vector2(0.3f, 0.8f);
        p11.FinishPos = new Vector2(0.1f, 0.8f);
        p11.StartWidth = 0.1f;
        p11.FinishWidth = 0.19f;
        p11.TextColor1 = Color.green;
        p11.AnimTime = 1.5f;

        p12 = p11.Copy();
        p12.StartPos = new Vector2(0.7f, 0.8f);
        p12.FinishPos = new Vector2(0.9f, 0.8f);

        p21 = p12.Copy();
        p21.StartPos = new Vector2(0.7f, 0.2f);
        p21.FinishPos = new Vector2(0.9f, 0.2f);

        p22 = p21.Copy();
        p22.StartPos = new Vector2(0.3f, 0.2f);
        p22.FinishPos = new Vector2(0.1f, 0.2f);

    }




}
