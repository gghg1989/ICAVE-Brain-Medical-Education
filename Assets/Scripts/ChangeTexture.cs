using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{

    public GameObject BrainComponent;
    private string ComponentTag;
    private Texture ComponentTexture;
    private Texture BasicTexture;
    private Renderer MRenderer;
    void Start()
    {
        ComponentTag = BrainComponent.tag;
        MRenderer = BrainComponent.GetComponent<Renderer>();
        ComponentTexture = (Texture)Resources.Load(ComponentTag);
        BasicTexture = (Texture)Resources.Load("basic");
        MRenderer.material.mainTexture = BasicTexture;
        MRenderer.material.SetTexture("_MainTex", BasicTexture);
    }

    // Update is called once per frameS
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        CancelInvoke();
        MRenderer.material.EnableKeyword("_NORMALMAP");
        MRenderer.material.EnableKeyword("_METALLICGLOSSMAP");
        MRenderer.material.SetTexture("_MainTex", ComponentTexture);
        MRenderer.material.SetTexture("_MetallicGlossMap", BasicTexture);
        MRenderer.material.SetTexture("_BumpMap", ComponentTexture);
    }

    private void OnCollisionExit(Collision collision)
    {
        Invoke("ReleaseTexture", 1f);
    }

    private void ReleaseTexture()
    {
        MRenderer.material.mainTexture = BasicTexture;
        MRenderer.material.DisableKeyword("_NORMALMAP");
        MRenderer.material.DisableKeyword("_METALLICGLOSSMAP");
    }
}
