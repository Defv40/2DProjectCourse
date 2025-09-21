using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour
{
    [SerializeField] private Image progressBar;

    private void Update()
    {
        progressBar.fillAmount = Loader.GetLoadingProgress();
    }
}