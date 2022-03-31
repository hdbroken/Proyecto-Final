using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GlobalPPController : MonoBehaviour
{
    private PostProcessVolume _globalPPVolume;
    private DepthOfField _dof;
    private ColorGrading _colorGrading;
    private Grain _grain;
    [SerializeField]
    private float _timer=0;

    [SerializeField]
    private float timeToFadeOut = 0;

    private void Awake()
    {
        _globalPPVolume = GetComponent<PostProcessVolume>();
        _globalPPVolume.profile.TryGetSettings<DepthOfField>(out _dof);
        _globalPPVolume.profile.TryGetSettings<ColorGrading>(out _colorGrading);
        _globalPPVolume.profile.TryGetSettings<Grain>(out _grain);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }
    public void Death()
    {
        float maxTime = _timer + 10;

        _colorGrading.active = true;
        _grain.active = true;
        _dof.active = true;
        
        float maxFocus = _dof.focusDistance;
        
        Debug.Log(maxFocus);
        if (_timer < maxTime)
        {
            Debug.Log(_timer);
        }
        _timer = 0;
    }
}
