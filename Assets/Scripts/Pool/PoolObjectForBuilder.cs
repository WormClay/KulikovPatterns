using UnityEngine;
namespace Asteroids
{
	public sealed class PoolObjectForBuilder : MonoBehaviour
	{

		public PoolContainerForBuilder Pool { get; private set; }

		public void SetPool(PoolContainerForBuilder pool)
		{
			Pool = pool;
		}

		public void Recycle()
		{
			Pool?.Recycle(this);
		}
	}
}