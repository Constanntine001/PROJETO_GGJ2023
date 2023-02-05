// Maded by Pedro M Marangon
using PedroUtils;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	[SerializeField] private List<AudioClip> musics;
    [SerializeField] private AudioSource source;
    [Range(0, 1), SerializeField] private float musicVolumeWhileOnShop = 0.5f;
    [Range(0, 1), SerializeField] private float normalMusiVolume = 1f;
    private Timer timer;

	private void Awake() => StartMusic();

	private void StartMusic()
    {
        AudioClip clip = GetRandom.Element(musics);

        source.clip = clip;

        source.Play();

        timer = new Timer("Music Timer", clip.length, StartMusic, true, false);
    }

    public void EnterShop() => source.volume = musicVolumeWhileOnShop;
    public void ExitShop() => source.volume = normalMusiVolume;

}