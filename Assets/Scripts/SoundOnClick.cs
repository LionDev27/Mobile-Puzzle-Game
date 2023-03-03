using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnClick : MonoBehaviour
{
    private Button _b;
    [SerializeField] private AudioClip _clip;

    private void Awake()
    {
        _b = GetComponent(typeof(Button)) as Button;
    }

    private void Start()
    {
        _b.onClick.AddListener(PlaySoundOnClick);
    }

    private void PlaySoundOnClick()
    {
        AudioController.instance.PlaySfx(_clip);
    }
}
