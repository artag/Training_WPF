using Demo.Business;

namespace Demo.Infrastructure
{
    public interface IPersonRepository
    {
        /// <summary>
        /// Сохраняет Person.
        /// </summary>
        /// <param name="person">Person, который требуется сохранить.</param>
        /// <returns>
        /// Общее количество сохранений.
        /// (для демонстрации, что создается и используется только один экземпляр сервиса).
        /// </returns>
        int Save(Person person);
    }
}
