using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WinCon : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image fadeImage; // La imagen negra para el efecto de fade
    [SerializeField] float fadeDuration = 1f; // Duraci�n del fade
    [SerializeField] int targetSceneIndex = 3; // �ndice de la escena a cargar
    [SerializeField] float delayBeforeTransition = 55f; // Tiempo antes de iniciar la transici�n

    private void Start()
    {
        // Inicia la transici�n despu�s del tiempo indicado
        StartCoroutine(TransitionAfterDelay());
    }

    private IEnumerator TransitionAfterDelay()
    {
        // Espera el tiempo definido antes de iniciar la transici�n
        yield return new WaitForSeconds(delayBeforeTransition);

        // Comienza el fade hacia negro
        yield return StartCoroutine(FadeToBlack());

        // Cambia a la escena objetivo
        SceneManager.LoadScene(targetSceneIndex);
    }

    private IEnumerator FadeToBlack()
    {
        // Aseg�rate de que la imagen est� completamente transparente al inicio
        fadeImage.color = new Color(0, 0, 0, 0);

        float elapsedTime = 0f;

        // Incrementa el alpha de la imagen gradualmente
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null; // Espera un frame
        }

        // Aseg�rate de que la imagen sea completamente negra al final
        fadeImage.color = new Color(0, 0, 0, 1);
    }
}
