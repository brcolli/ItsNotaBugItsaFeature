using UnityEngine;
using System.Collections;

public class ReticleController : MonoBehaviour
{

    [SerializeField] private Texture2D reticle;

    void OnGUI()
    {
        float xMin = (Screen.width - Input.mousePosition.x) - (reticle.width/2);
        float yMin = (Screen.height - Input.mousePosition.y) - (reticle.height/2);
        GUI.DrawTexture(new Rect(xMin, yMin, reticle.width, reticle.height), reticle);
    }
}
