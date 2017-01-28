/**
 * Author:      ksami
 * Version:     Unity 5.5
 *              iTween 2.0.7 https://www.assetstore.unity3d.com/en/#!/content/84
 * Description: Uses the iTween package to animate the object the script
 *              is attached to by hopping (vertically moving up and down)
 *              only while the object is moving
 */

using UnityEngine;
using System.Collections;

public class MoveHop : MonoBehaviour {
    private bool isAnimated = false;
    private Vector3 prevPosition;

    void Start() {
        // Set up animation type (hopping)
        // also starts hopping as long as not paused
        iTween.MoveBy(gameObject, iTween.Hash("y", 0.1, "easeType", "easeInOutExpo", "loopType", "pingPong", "time", 0.1, "delay", .05));
        prevPosition = transform.position;
    }

    void Update() {
        // if object is animated and not moving in the x-z plane
        if (isAnimated && (transform.position.x == prevPosition.x && transform.position.z == prevPosition.z)) {
            isAnimated = false;
            iTween.Pause(gameObject);
        // if object is not already hopping
        } else if (!isAnimated) {
            isAnimated = true;
            iTween.Resume(gameObject);
        }
        prevPosition = transform.position;
    }
}
