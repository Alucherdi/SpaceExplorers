﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherWorldEffect : MonoBehaviour {

    public Shader currentShader;
    public float grayScaleAmount = 1.0f;
    private Material currentMaterial;

    Material material
    {
        get
        {
            if (currentMaterial == null)
            {
                currentMaterial = new Material(currentShader);
                currentMaterial.hideFlags = HideFlags.HideAndDontSave;
            }
            return currentMaterial;
        }
    }

    void Start()
    {
        if (!SystemInfo.supportsImageEffects)
        {
            enabled = false;
            return;
        }
        if (!currentShader && !currentShader.isSupported)
            enabled = false;
    }

    void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)//Debe ir siempre en la cámara
    {
        if (currentShader != null)
        {
            material.SetFloat("_LuminosityAmount", grayScaleAmount);
            Graphics.Blit(sourceTexture, destTexture, material);
        }
        else
        {
            Graphics.Blit(sourceTexture, destTexture);
        }
    }

    void Update()
    {
        grayScaleAmount = Mathf.Clamp(grayScaleAmount, 0.0f, 1.0f); //Acota el valor de la escala
    }

    void OnDisable()
    {
        if (currentMaterial)
            DestroyImmediate(currentMaterial);
    }
}
