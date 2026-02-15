namespace ApiQuiz.Logic.GameService
{
    public interface IGameCreator
    {
        public Task<IGame> CreateGame();
    }
}
