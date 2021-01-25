using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonApplications : Button
{
    protected override void OnEnable()
    {
        base.OnEnable();
        onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); } );
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        onClick.RemoveListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); } );
    }
}
