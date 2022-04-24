using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Core.GameManagement;
using TMPro;
using Zenject;

public class InGameUIComponent : MonoBehaviour
{

    [SerializeField]
    TMP_Text levelName;

    [SerializeField]
    Button winButton;

    [Inject]
    private LevelManager levelManager;

    private bool allowInput = false;

    // Start is called before the first frame update
    void Start()
    {
        allowInput = true;
        winButton.onClick.AddListener(WinLevel);
        levelName.text = $"Level {levelManager.CurrentLevelIndex}";
    }

    private void WinLevel()
    {
        if (!allowInput) return;
        GameManagerComponent.Instance.WinLevel();

        allowInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
