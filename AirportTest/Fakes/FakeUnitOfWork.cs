using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirportTests.Fakes
{
    class FakeUnitOfWork : IUnitOfWork
    {
        public void DropDB()
        {
            
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (typeof(T) == typeof(Flight))
            {
                var fake = A.Fake<IRepository<Flight>>();
                A.CallTo(() => fake.Create(A<Flight>._)).DoesNothing();
                A.CallTo(() => fake.Update(A<int>._, A<Flight>._)).DoesNothing();
                return (IRepository<T>)A.Fake<IRepository<Flight>>();
            }
            else if (typeof(T) == typeof(Crew))
            {
                var fake = A.Fake<IRepository<Crew>>();
                A.CallTo(() => fake.Create(A<Crew>._)).DoesNothing();
                A.CallTo(() => fake.Update(A<int>._, A<Crew>._)).DoesNothing();
                return (IRepository<T>)A.Fake<IRepository<Crew>>();
            }
            else if (typeof(T) == typeof(Departure))
            {
                var fake = A.Fake<IRepository<Departure>>();
                A.CallTo(() => fake.Create(A<Departure>._)).DoesNothing();
                A.CallTo(() => fake.Update(A<int>._, A<Departure>._)).DoesNothing();
                return (IRepository<T>)A.Fake<IRepository<Departure>>();
            }
            else if (typeof(T) == typeof(Pilot))
            {
                var fake = A.Fake<IRepository<Pilot>>();
                A.CallTo(() => fake.Create(A<Pilot>._)).DoesNothing();
                A.CallTo(() => fake.Update(A<int>._, A<Pilot>._)).DoesNothing();
                return (IRepository<T>)A.Fake<IRepository<Pilot>>();
            }
            else if (typeof(T) == typeof(Plane))
            {
                var fake = A.Fake<IRepository<Plane>>();
                A.CallTo(() => fake.Create(A<Plane>._)).DoesNothing();
                A.CallTo(() => fake.Update(A<int>._, A<Plane>._)).DoesNothing();
                return (IRepository<T>)A.Fake<IRepository<Plane>>();
            }
            else if (typeof(T) == typeof(PlaneType))
            {
                var fake = A.Fake<IRepository<PlaneType>>();
                A.CallTo(() => fake.Create(A<PlaneType>._)).DoesNothing();
                A.CallTo(() => fake.Update(A<int>._, A<PlaneType>._)).DoesNothing();
                return (IRepository<T>)A.Fake<IRepository<PlaneType>>();
            }
            else if (typeof(T) == typeof(Stewardess))
            {
                var fake = A.Fake<IRepository<Stewardess>>();
                A.CallTo(() => fake.Create(A<Stewardess>._)).DoesNothing();
                A.CallTo(() => fake.Update(A<int>._, A<Stewardess>._)).DoesNothing();
                return (IRepository<T>)A.Fake<IRepository<Stewardess>>();
            }
            else if (typeof(T) == typeof(Ticket))
            {
                var fake = A.Fake<IRepository<Ticket>>();
                A.CallTo(() => fake.Create(A<Ticket>._)).DoesNothing();
                A.CallTo(() => fake.Update(A<int>._, A<Ticket>._)).DoesNothing();
                return (IRepository<T>)A.Fake<IRepository<Ticket>>();
            }
            else
            {
                throw new TypeAccessException("Wrong type of repo");
            }
        }

        public void SaveChanges()
        {
           
        }

        public void SeedDB()
        {
           
        }
    }
}
