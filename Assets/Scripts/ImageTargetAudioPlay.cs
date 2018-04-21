using UnityEngine;
using Vuforia;

public class ImageTargetAudioPlay : MonoBehaviour,
ITrackableEventHandler
{
	private TrackableBehaviour mTrackableBehaviour;
	private AudioSource audio;

	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		audio = GetComponent<AudioSource>();
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			
			// Play audio when target is found
			audio.Play();
		}
		else
		{
			// Stop audio when target is lost
			// audio.Stop();
		}
	}

	public void stopSound()
	{
		audio.Stop();
	}
	
}
