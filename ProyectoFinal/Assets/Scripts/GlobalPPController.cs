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
    private Vignette _vignette;   
    private float _timer=0;

    //[SerializeField]
    //private float timeToFadeOut = 0;

    private void Awake()
    {
        _globalPPVolume = GetComponent<PostProcessVolume>();
        _globalPPVolume.profile.TryGetSettings<DepthOfField>(out _dof);
        _globalPPVolume.profile.TryGetSettings<ColorGrading>(out _colorGrading);
        _globalPPVolume.profile.TryGetSettings<Grain>(out _grain);
        _globalPPVolume.profile.TryGetSettings<Vignette>(out _vignette);
    }

    IEnumerator DOFAndVignette()
    {
        float maxTime = _timer + 5;
        float maxFocus = _dof.focusDistance.value;
        while (_timer < maxTime)
        {
            _dof.focusDistance.value -= 0.2f;
            _vignette.intensity.value += 0.02f;
            yield return new WaitForSeconds(0.1f);
            _timer += 0.2f;
        }
    }
    public void Death()
    {   
        _colorGrading.active = true;
        _grain.active = true;
        _dof.active = true;
        _vignette.active = true;
               
        StartCoroutine(DOFAndVignette());
               
        _timer = 0;
    }

    public void Alive()
    {
        _colorGrading.active = false;
        _grain.active = false;
        _dof.active = false;
        _vignette.active = false;
    }
}
