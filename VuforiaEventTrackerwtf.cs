using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;
using Vuforia;
using Kino; 

/// <summary>
///     A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class VuforiaEventTrackerwtf : MonoBehaviour, ITrackableEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;

    #endregion // PRIVATE_MEMBER_VARIABLES

    #region UNTIY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            GameObject mainCamera = GameObject.Find("Main Camera");
			AnalogGlitch glitchy = mainCamera.GetComponent <AnalogGlitch> ();
			glitchy.setGlitchboolean(true); 

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            
            if (mTrackableBehaviour.TrackableName == "orangefiducial") {
			    nearfuturetest thefutures = mainCamera.GetComponent <nearfuturetest> ();
			    thefutures.whichFiducial("orange"); 
            }

            if (mTrackableBehaviour.TrackableName == "cupfiducial") {
			    nearfuturetest thefutures = mainCamera.GetComponent <nearfuturetest> ();
			    thefutures.whichFiducial("cup"); 
            }

            // if (mTrackableBehaviour.TrackableName == "postitfiducial") {
			//     nearfuturetest thefutures = mainCamera.GetComponent <nearfuturetest> ();
			//     thefutures.whichFiducial("postit"); 
            // }

            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

            GameObject mainCamera = GameObject.Find("Main Camera");
            nearfuturetest thefutures = mainCamera.GetComponent <nearfuturetest> ();
			thefutures.whichFiducial("NULL"); 
            
            GameObject uiElements = GameObject.Find("UI Base Dividers");

            for (int i = 1; i < SceneManager.sceneCount; i++) {
				Scene currentscene = SceneManager.GetSceneAt(i);
				Debug.Log("Current SCENE is '" + currentscene.name + "'.");
				SceneManager.UnloadSceneAsync(currentscene.name);
			}

            OnTrackingLost();
        }
        else
        {
            for (int i = 1; i < SceneManager.sceneCount; i++) {
				Scene currentscene = SceneManager.GetSceneAt(i);
				Debug.Log("Current SCENE is '" + currentscene.name + "'.");
				SceneManager.UnloadSceneAsync(currentscene.name);
			}
            
            GameObject mainCamera = GameObject.Find("Main Camera");
            nearfuturetest thefutures = mainCamera.GetComponent <nearfuturetest> ();
			thefutures.whichFiducial("null"); 

            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS
    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    }
    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
    }

    #endregion // PRIVATE_METHODS
}