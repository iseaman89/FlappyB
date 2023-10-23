namespace Pipes
{
    public class PipeFactory
    {
        private readonly Pipe _pipe;

        public PipeFactory(Pipe pipe) => _pipe = pipe;

        public Pipe Create() => UnityEngine.Object.Instantiate(_pipe);
    }
}