using UnityEngine;
using System.Collections;
using Vuforia;
using System;
using TMPro;
public class AddTextAndSound : MonoBehaviour
{
    private GameObject textObj;

    private void showText()
    {
        // Create new GameObject
        textObj = new GameObject("AR_Label");
        textObj.transform.SetParent(this.transform);

        // Add TextMeshPro 3D component
        TextMeshPro tmp = textObj.AddComponent<TextMeshPro>();

        // Set label text
        tmp.text = "This is my label";
        tmp.fontSize = 0.12f;       // Adjust for world scale
        tmp.color = Color.cyan;

        // Position text beside the ImageTarget
        textObj.transform.localPosition = new Vector3(0.15f, 0f, 0f);
        textObj.transform.localRotation = Quaternion.identity;

        // Optional: make text always face camera
        textObj.AddComponent<Billboard>();
    }

    public void ShowData()
    {
        showText();
    }
    public void HideData()
    {
        Destroy(textObj);
    }
}