using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

	List<AudioSource> musicSources;

	[SerializeField] AudioClip Background;
	[SerializeField] AudioClip lava;
	[SerializeField] AudioClip sand;
	[SerializeField] AudioClip ice;
	[SerializeField] AudioClip metro_boomin;


}
