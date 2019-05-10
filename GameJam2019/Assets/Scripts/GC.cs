using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC : MonoBehaviour
{

    #region MEMBERS
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
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion
}
