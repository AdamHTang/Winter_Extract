/*
 *  Created by: Adam Tang
 *  Date Created: Sept 15, 2021
 *  
 *  Last Edited by:
 *  Last Updated: Sept 15, 2021
 *  
 *  Description: This controls the boundaries of the game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsLock : MonoBehaviour
{
    public Rect levelBounds;    // The x,y and w,h of the bounding rectangle will be stored in the levelBounds rectangle.

    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, levelBounds.xMin, levelBounds.xMax),
                                         transform.position.y,
                                         Mathf.Clamp(transform.position.z, levelBounds.yMin, levelBounds.yMax));
    }   // End LateUpdate()

    private void OnDrawGizmosSelected()
    {
        const int cubeDepth = 1;
        Vector3 boundsCenter = new Vector3(levelBounds.xMin + levelBounds.width * 0.5f,
                                          0,
                                          levelBounds.yMin + levelBounds.height * 0.5f);

        Vector3 boundsHeight = new Vector3(levelBounds.width, cubeDepth, levelBounds.height);
        Gizmos.DrawWireCube(boundsCenter, boundsHeight);

    }   // End OnDrawGizmosSelected()

}
