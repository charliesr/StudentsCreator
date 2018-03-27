using StudentCreator.Models;

namespace StudentCreator.Services.Text
{
    public interface IFormat
    {
        string StringPointer { get;  }
        void Add<T>(T value) where T : class;
    }
}
