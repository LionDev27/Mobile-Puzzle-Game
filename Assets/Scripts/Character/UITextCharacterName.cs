using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITextCharacterName : MonoBehaviour
{
    private Button _b;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] CharacterSolver _solver;

    private void Awake()
    {
        _b = GetComponent(typeof(Button)) as Button;
    }

    private void Start()
    {
        _b.onClick.AddListener(SolveName);
    }

    void SolveName()
    {
        _solver.TryToSolveName(_inputField.text);
    }
}
