using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            try
            {
                return _context.Persons.SingleOrDefault(x => x.Id.Equals(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }

        public List<Person> CreateRange(List<Person> persons)
        {
            try
            {
                _context.AddRange(persons);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return persons;
        }


        public Person Update(Person person)
        {
            //verifica se já exiuste com o respectivo id
            //*Eu voltaria exception se nãol tiver, para não dar a falsa impressão de que salvou 
            if (!Exists(person.Id)) { return new Person(); }

            //se encontrou, vaki alterar os novos valores das propriedades 
            var result = _context.Persons.SingleOrDefault(x => x.Id.Equals(person.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(x => x.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private bool Exists(long id)
        {
            var result = _context.Persons.Any(x => x.Id.Equals(id));
            return result;
        }
    }
}
