using UnityEngine;
using Vuforia;

public class TestTorchLightEffect : MonoBehaviour, ITrackableEventHandler {

	private TrackableBehaviour _mTrackableBehaviour;
	private float _distance;
	private Renderer _renderer;
	private Material _mat;
	private bool _isTrackableActive;
	private bool _mFlashEnabled;

	private bool _firstRepereReached;
	private bool _lastRepereReached;

	public AnimationPopup AnimationPopupScript;
	
	// Use this for initialization
	void Start ()
	{
		_mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		
		if (_mTrackableBehaviour)
		{
			_mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
		
		_renderer = GameObject.Find("Plane").GetComponentInChildren<Renderer>();
		_distance = 0.0f;

		_mat = _renderer.sharedMaterial;

		_isTrackableActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (_isTrackableActive != true) return;
		var delta = Camera.main.transform.position - _mTrackableBehaviour.transform.position;
		_distance = delta.magnitude;
			
		//Pour la compilation sur mobile
		//float radius = distance / 100.0f;
			
		//Pour la compilation sur desktop
		float radius = _distance / 200.0f;

		if (radius > 0.1f)
		{
			radius = 0.1f;
		}
		_mat.SetFloat("_Radius", radius);

		var rotationCamera = Camera.main.transform.rotation;
		var rotationTarget= _mTrackableBehaviour.transform.rotation;
		var rotation = rotationCamera * Quaternion.Inverse(rotationTarget);
		var rotationX = Mathf.Abs(rotation.x);

		// Mapping de la valeur à passer au shader pour simuler la perspective lorsque
		// le device n'est pas parallèle au livre (mapping nécessaire pour ne pas trop déformer l'halo)
		const float rotationLow = 0.5f;
		const float rotationHigh = 0.9f;
		var mappedRotationShader = Mathf.Lerp(rotationLow, rotationHigh, rotationX);

		_mat.SetFloat("_Rotation", mappedRotationShader);

		////////////
		//
		// Détection du passage de l'utilisateur dans le texte
		//
		////////////
		
		var distanceX = Camera.main.transform.position.x;
			
		// On utilise l'axe Z de la caméra car le plane est perpendiculaire au plan XY donc l'axe vertical du plane 
		// correspond à l'axe z de la caméra
		var distanceZ = Camera.main.transform.position.z;
			
						
		// Plus on avance dans le text plus distanceX augmente et plus distanceY diminue
		// Reperes xy en haut à gauche du text
		const float firstRepereX = -5.5f;
		const float firstRepereY = 0.0f;
			
		// Reperes xy en bas à droite du text
		const float lastRepereX = -1.0f;
		const float lastRepereY = -7f;
			
		// Si repere en haut à gauche détecté
		if (distanceX < firstRepereX && distanceZ > firstRepereY)
		{
			Debug.Log("first repere reached");
			_firstRepereReached = true;
		}

		// Si repere en bas à droite détecté
		if (distanceX < lastRepereX && distanceZ < lastRepereY )
		{
			Debug.Log("last repere reached");
			_lastRepereReached = true;
		}
			
		// Si tout les repères ont été détecté
		if (_firstRepereReached != true || _lastRepereReached != true) return;
		AnimationPopup(targetName:"hiddenText");	
		Debug.Log("Content unlocked  !");
	}
	
	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) 
		{
			OnTrackingFound();
			
		}
		else if (previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NOT_FOUND)
		{
			OnTrackingLost();
		}

		_mFlashEnabled = !_mFlashEnabled;
	}

	private void OnTrackingFound()
	{
		_isTrackableActive = true;
	}

	private void OnTrackingLost()
	{
		_isTrackableActive = false;
	}

	private void AnimationPopup(string targetName)
	{
		AnimationPopupScript.MoveNotification(targetName);
	}
}
