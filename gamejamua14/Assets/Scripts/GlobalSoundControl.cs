using UnityEngine;
using System.Collections;

public class GlobalSoundControl : MonoBehaviour
{
		public AudioSource[] AudioSources;
		public AudioClip[] AtmosphereClips;
		public AudioClip[] SpiderClips;
		public AudioClip[] PiranhasClips;
		public AudioClip[] PanelsClips;
		public AudioClip[] RobotsClips;
		public AudioClip[] BossesClips;
		public AudioClip DieClips;
		[Range(0.1f, 1f)]
		public  float
				fadeSteps;
		private  int currentAudioSource;
		private  AudioClip[] CurrentTheme;
		private  bool switchingTheme;
		public float MAX_MUSIC_VOLUME;
		public float MIN_MUSIC_VOLUME = 0.1f;
	
		void Start ()
		{
				StaticRefs.Refs.GlobalSound = this;
				currentAudioSource = 0;
				MAX_MUSIC_VOLUME = AudioSources [0].volume;
				switchingTheme = false;
				CurrentTheme = AtmosphereClips;
				PlayNextClip ();
		}
	
		void Update ()
		{
				if (switchingTheme == true) {				
						if (AudioSources [currentAudioSource].volume < MAX_MUSIC_VOLUME) {	
								FadeIn ();
						}
						if (AudioSources [getSecondaryAudioSource ()].volume > MIN_MUSIC_VOLUME) {
								FadeOut ();
						} else {
								AudioSources [getSecondaryAudioSource ()].Stop ();
								switchingTheme = false;
								setDefaultVolumes ();
						}
				} else {
						if (!AudioSources [currentAudioSource].isPlaying) {
								SetCurrentAudioSource ();
								PlayNextClip ();
						}
				}
		}
	
		public void PlayDeathSound ()
		{
				StartPlaying (DieClips);
		
		}
	
		public void StartPlaying (AudioClip a_audioClip, bool a_loop = false)
		{
				foreach (AudioSource a_source in AudioSources) {
						if (!a_source.isPlaying) {
								a_source.clip = a_audioClip;
								a_source.loop = a_loop;
								a_source.Play ();
								return;
						}
				}
		}
	
		private void PlayNextClip ()
		{
				AudioSources [currentAudioSource].clip = CurrentTheme [Random.Range (0, CurrentTheme.Length)];
				AudioSources [currentAudioSource].loop = false;
				AudioSources [currentAudioSource].Play ();
		}
	
		private void PlayClip (int clip, AudioClip[] theme)
		{
				AudioSources [currentAudioSource].clip = theme [clip];
				AudioSources [currentAudioSource].loop = false;
				AudioSources [currentAudioSource].Play ();
		}
	
		private void SetCurrentAudioSource ()
		{
				if (currentAudioSource == 0) {
						currentAudioSource = 1;
				} else {
						currentAudioSource = 0;
				}
		}
	
		private int getSecondaryAudioSource ()
		{
				if (currentAudioSource == 0) {
						return 1;
				} else {
						return 0;
				}
		}
	
		private void setSwitchingVolumes ()
		{
				AudioSources [currentAudioSource].volume = (float)MIN_MUSIC_VOLUME;
				AudioSources [getSecondaryAudioSource ()].volume = (float)MAX_MUSIC_VOLUME;
		}
	
		private void setDefaultVolumes ()
		{
				AudioSources [currentAudioSource].volume = (float)MAX_MUSIC_VOLUME;
				AudioSources [getSecondaryAudioSource ()].volume = (float)MAX_MUSIC_VOLUME;
		}
	
		private void FadeIn ()
		{
				AudioSources [currentAudioSource].volume += ((float)fadeSteps) * Time.deltaTime;
				print ("Fade in:" + AudioSources [currentAudioSource].volume);
		}
	
		private void FadeOut ()
		{
				AudioSources [getSecondaryAudioSource ()].volume -= ((float)fadeSteps) * Time.deltaTime;
				print ("Fade out:" + AudioSources [getSecondaryAudioSource ()].volume);
		}
	
		private void ChangeAudioSource ()
		{
		}
	
		private void changeTheme (AudioClip[] theme)
		{
				switchingTheme = true;
				CurrentTheme = theme;
				SetCurrentAudioSource ();
				setSwitchingVolumes ();
				PlayNextClip ();
		}
	
		public void ChangeToSpiders ()
		{
				changeTheme (SpiderClips);			
		}

		public void ChangeToPiranhas ()
		{
				changeTheme (PiranhasClips);			
		}

		public void ChangeToPanels ()
		{
				changeTheme (PanelsClips);			
		}

		public void ChangeToRobots ()
		{
				changeTheme (RobotsClips);			
		}
	
		public void ChangeToAtmosphere ()
		{
				changeTheme (AtmosphereClips);
		}
		
		public void ChangeToBoss (int theme)
		{
				PlayClip (theme, BossesClips);
		}
	
}
