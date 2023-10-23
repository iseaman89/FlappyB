namespace PlayerStuff
{
    public class PlayerFactory
    {
        private readonly Player _player;

        public PlayerFactory(Player player) => _player = player;

        public Player Create() => UnityEngine.Object.Instantiate(_player);
    }
}