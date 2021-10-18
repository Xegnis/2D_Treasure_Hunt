using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	Transform tf;

	[SerializeField]
	float shakeTime;

	[SerializeField]
	float intensity;
	[SerializeField]
	float decreaseFactor;

	static float defaultTime;
	static float shakeAmount;
	static float shakeDuration;

	void Awake()
	{
		tf = GetComponent<Transform>();
	}

	void Start()
	{
		defaultTime = shakeTime;
		shakeAmount = intensity;
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
			tf.position = GetComponent<CameraMovement>().playerT.position + Random.insideUnitSphere * shakeAmount;
			tf.position = new Vector3(tf.position.x, tf.position.y, -10);

			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			shakeAmount = intensity;
		}
	}

	public static void Shake ()
    {
		Shake(defaultTime, shakeAmount);
    }

	public static void Shake(float time)
    {
		Shake(time, shakeAmount);
    }

	public static void Shake (float time, float intensity)
    {
		shakeDuration = time;
		shakeAmount = intensity;
    }
}
