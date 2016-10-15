using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{

    [SerializeField] private Texture2D Reticle;

    void OnGUI()
    {
        float xMin = (Screen.width - Input.mousePosition.x) - (Reticle.width/2);
        float yMin = (Screen.height - Input.mousePosition.y) - (Reticle.height/2);
        GUI.DrawTexture(new Rect(xMin, yMin, Reticle.width, Reticle.height), Reticle);
    }
}
