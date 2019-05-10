﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GC : MonoBehaviour
{

    #region MEMBERS
    public FlashProManager FM;
    private TextMeshProUGUI GUItext1;
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
        
    }

    #endregion

    void SetUpGUI()
    {
        GameObject GUIItem1 = FM.AddGUIItem("Score : 0 - 0", 0.4f, 0.95f, 0.2f, Color.white);
        GUItext1 = GUIItem1.GetComponent<TextMeshProUGUI>();

    }

}
