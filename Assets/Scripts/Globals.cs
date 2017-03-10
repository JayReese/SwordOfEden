using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EmitterMovement { Static, Orbit };

public enum DataQueryType { Enemies };

public static class Globals
{
    // The camea's orthographic bounds extensivon method.
    public static Bounds OrthographicBounds(this Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
}
