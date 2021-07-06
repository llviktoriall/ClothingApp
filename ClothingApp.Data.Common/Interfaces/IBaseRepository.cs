using System.Threading.Tasks;

namespace ClothingApp.Data.Common.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>Создание объекта</summary>
        Task CreateAsync(T item);

        /// <summary>Обновление объекта</summary>
        Task UpdateAsync(T item);

        /// <summary>Получение объекта</summary>
        Task<T> GetByIdAsync(long id);

        /// <summary> Запись существует, проверка по Id </summary>
        Task<bool> ExistsAsync(long id);

        /// <summary>
        /// Удаление объекта</summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(long id);

    }
}
