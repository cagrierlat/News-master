
namespace News.BLL.Intefaces.UnitWork
{
    public interface IUnitWork
    {
        IBaseAppRepository BaseAppRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ITagRepository TagRepository { get; }
    }
}
