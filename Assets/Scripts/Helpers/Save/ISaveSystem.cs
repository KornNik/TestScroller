
namespace SideScroller.Helpers.Save
{
    interface ISaveSystem<T>
    {
        void Save(T serializableObject);
        T Load();
        bool CheckDirectory();
    }
}
