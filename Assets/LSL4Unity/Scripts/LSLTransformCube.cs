using UnityEngine;
using LSL;

public class LSLTransformCube : MonoBehaviour
{
    private liblsl.StreamInlet inlet;
    private float[] sample;

    public GameObject[] targetObjects; // Array of GameObjects to be controlled

    void Start()
    {
        var streamInfos = liblsl.resolve_stream("type", "Unity.Position");
        inlet = new liblsl.StreamInlet(streamInfos[0]);
        sample = new float[3];
    }

    void Update()
    {
        if (inlet.pull_sample(sample, 0) > 0)
        {
            foreach (var obj in targetObjects)
            {
                obj.transform.position = new Vector3(sample[0], sample[1], sample[2]);
            }
        }
    }
}
