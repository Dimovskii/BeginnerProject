using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerSpawner : MonoBehaviour
    {
        private GameObject _player;
        private Vector3 _spawnPosition;

        public void Init(GameObject player)
        {
            _player = player;
            Create();
        }
        private void Create() 
        {
            _spawnPosition = new Vector3(0f, 0f, 0f);
            _player = Instantiate(_player, _spawnPosition, Quaternion.identity);
        }
    }
}