using MainApp.Models;

namespace MainApp.Data;

public class DataContext<T> where T : class
{
    private readonly List<T> _list = [];

    public IEnumerable<T> Items()
    {
        return _list;
    }

    public bool Save(T item) 
    {
        _list.Add(item);
        return true;
    }
}
