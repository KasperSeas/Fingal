using UnityEngine;

[ExecuteInEditMode]
public class CameraEffect : MonoBehaviour {

    public Material EffectMat;

    private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, EffectMat);
    }
}
