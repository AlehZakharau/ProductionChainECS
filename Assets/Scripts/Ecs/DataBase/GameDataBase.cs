namespace UnityTemplateProjects
{
    public interface IGameDataBase
    {
        public GameData GameData { get; set; }
    }
    public class GameDataBase : IGameDataBase
    {
        public GameData GameData { get; set; }
    }
}