using System.Collections;

namespace FireMapper
{
    public interface IDataMapper
    {
        IEnumerable GetAll();
        object GetById(object keyValue);
        void Add(object obj);
        void Update(object obj);
        void Delete(object keyValue);
    }
}
