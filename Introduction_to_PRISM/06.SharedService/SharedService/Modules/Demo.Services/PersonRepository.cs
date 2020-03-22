using System;
using Demo.Business;
using Demo.Infrastructure;

namespace Demo.Services
{
    public class PersonRepository : IPersonRepository
    {
        /// <summary>
        /// Количество сохранений. Для демонстрации, что сервис создан в единственном экземпляре.
        /// </summary>
        private int _count = 0;

        public int Save(Person person)
        {
            _count++;
            person.LastUpdated = DateTime.Now;

            return _count;
        }
    }
}
