using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPlay : MonoBehaviour
{
    private Button _b;
    [SerializeField] private Animator _anim;

    private void Awake()
    {
        _b = GetComponent(typeof(Button)) as Button;
    }

    private void Start()
    {
        _b.onClick.AddListener(LoadSave);
    }

    private void LoadSave()
    {
        _anim.SetTrigger("levelLoad");
    }
}
