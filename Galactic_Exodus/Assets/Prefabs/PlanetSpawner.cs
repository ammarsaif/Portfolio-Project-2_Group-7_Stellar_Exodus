using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
	[SerializeField] private Transform[] _prefabs;
	[SerializeField] private float _speed = 5f;
	[SerializeField] private float _lifeTime = 5f;
	[SerializeField] private float _spawnRateMin = 1f;
	[SerializeField] private float _spawnRateMax = 10f;
	[SerializeField] private float _xRange = 4f;
    [SerializeField] private float minSize = 1f;
    [SerializeField] private float maxSize = 2f;

    private List<Transform> _spawnedObject = new List<Transform>();
	private Queue<Transform> _prefabQueue = new Queue<Transform>();
	private float _timer;

	private void Start()
	{
		_timer = Random.Range(_spawnRateMin, _spawnRateMax);

		foreach(Transform t in _prefabs)
		{
			_prefabQueue.Enqueue(t);
		}
	}

	private void Update()
	{
		_timer -= Time.deltaTime;

		if (_timer <= 0)
		{
			_timer = Random.Range(_spawnRateMin, _spawnRateMax);

			Transform planet = _prefabQueue.Dequeue();
			_prefabQueue.Enqueue(planet);

			Transform t = Instantiate(planet, transform);
			_spawnedObject.Add(t);

			t.position += Vector3.right * Random.Range(-_xRange, _xRange);
			t.localScale = t.localScale * Random.Range(minSize, maxSize);

            Destroy(t.gameObject, _lifeTime);
		}

		foreach (Transform t in _spawnedObject)
		{
			if (t == null)
			{
				_spawnedObject.Remove(t);
				continue;
			}

			t.position += Vector3.down * Time.deltaTime * _speed;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position - Vector3.right * _xRange, transform.position + Vector3.right * _xRange);
	}
}