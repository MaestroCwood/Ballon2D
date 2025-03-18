using UnityEngine;
using UnityEngine.UI;

public class MuteTogle : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Toggle toggle;



    private void OnEnable()
    {

        toggle.onValueChanged.AddListener(TogleMute);
        audioSource.mute = !toggle.isOn;
    }

    void TogleMute(bool isOn)
    {
        audioSource.mute = !isOn; ;
    }

    private void OnDisable()
    {
        toggle.onValueChanged.RemoveListener(TogleMute);
    }
}
