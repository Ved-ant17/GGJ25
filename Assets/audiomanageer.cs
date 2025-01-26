using UnityEngine;

public class audiomanageer : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip background;

    private void Start(){
        musicSource.clip = background;
        musicSource.Play();
    }
}
