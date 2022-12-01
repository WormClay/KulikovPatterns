using UnityEngine;
using System.Collections.Generic;

namespace Asteroids
{
	public sealed class PoolContainerForBuilder : IService
	{
		private readonly Stack<PoolObjectForBuilder> _store;
		private Transform _rootPool;
		private GameObjectBuilder _bulletBuilder;
		private string _spritePath;
		private Sprite _sprite;
		private int counter;
		

		public PoolContainerForBuilder(string spritePath, string rootName, int capacityPool)
		{
			_store = new Stack<PoolObjectForBuilder>(capacityPool);
			_spritePath = spritePath;
			if (!_rootPool)
			{
				_rootPool = new GameObject(rootName).transform;
			}
			Init(capacityPool);
		}

		private bool LoadSprite()
		{
			_sprite = Resources.Load<Sprite>(_spritePath);
			if (_sprite == null)
			{
				Debug.LogWarning("Cant load sprite " + _spritePath);
				return false;
			}
			return true;
		}


		public PoolObjectForBuilder Get(Transform transform)
		{
			if (_sprite == null)
			{
				if (!LoadSprite())
				{
					return null;
				}
			}


			PoolObjectForBuilder poolObject;
			if (_store.Count > 0)
			{
				poolObject = _store.Pop();
			}
			else
			{
				//poolObject = Object.Instantiate(_prefab).AddComponent<PoolObject>();
				_bulletBuilder = new GameObjectBuilder();
				counter++;
				GameObject go = _bulletBuilder.Visual.Name("Bullet"+counter).Sprite(_sprite).Physics.CircleCollider2D(0.29f).Rigidbody2D(0.01f, 0).Script.Add<Bullet>().Add<PoolObjectForBuilder>();
				go.GetComponent<Bullet>().Init(2,1);
				poolObject = go.GetComponent<PoolObjectForBuilder>();
				poolObject.SetPool(this);
				poolObject.transform.parent = _rootPool;
			}

			poolObject.transform.position = transform.position;
			poolObject.transform.rotation = transform.rotation;
			poolObject.gameObject.SetActive(true);
			return poolObject;
		}

		public void Recycle(PoolObjectForBuilder poolObject)
		{
			if (poolObject != null && poolObject.Pool == this)
			{
				poolObject.transform.position = _rootPool.position;
				poolObject.transform.rotation = _rootPool.rotation;
				poolObject.gameObject.SetActive(false);
				if (!_store.Contains(poolObject))
				{
					_store.Push(poolObject);
				}
			}
		}

		private void Init(int capacity)
		{
			PoolObjectForBuilder[] poolObjects = new PoolObjectForBuilder[capacity];
			for (int i = 0; i < capacity; i++)
			{
				poolObjects[i] = Get(_rootPool);
			}
			for (int i = 0; i < capacity; i++)
			{
				poolObjects[i].Recycle();
			}
		}
	}
}
