using Business.Abstract;
using Business.DTO;
using Domain.Entities;
using EntityFramework.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> repository;
        private readonly IUnitOfWork unitOfWork;
        public EmployeeService(IRepository<Employee> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public IQueryable<Employee> EmployeesAsQueryable()
        {
            return repository.GetAllAsQueryable();
        }


        public ReturnObjectDTO GetEmployee(int id)
        {
            var employee = EmployeesAsQueryable().Select(x => new EmployeeDTO()
            {
                Id = x.Id
                                                                                        ,
                FirstName = x.FirstName
                                                                                        ,
                MiddleName = x.MiddleName
                                                                                        ,
                LastName = x.LastName
                                                                                        ,
                IsActive = x.IsActive
                                                                                        ,
                DateCreated = x.DateCreated
            }).FirstOrDefault(x => x.Id == id);
            return new ReturnObjectDTO() { data = employee, successMessage = "Process is successful." };
        }
        public async Task<ReturnObjectDTO> GetEmployeeAsync(int id)
        {
            var employee = await EmployeesAsQueryable().Select(x => new EmployeeDTO()
            {
                Id = x.Id
                                                                                        ,
                FirstName = x.FirstName
                                                                                        ,
                MiddleName = x.MiddleName
                                                                                        ,
                LastName = x.LastName
                                                                                        ,
                IsActive = x.IsActive
                                                                                        ,
                DateCreated = x.DateCreated
            }).FirstOrDefaultAsync(x => x.Id == id);
            return new ReturnObjectDTO() { data = employee, successMessage = "Process is successful." };
        }



        public ReturnObjectDTO GetAllEmployees()
        {
            var employees = repository.GetAllAsQueryable().Select(x => new EmployeeDTO()
            {
                Id = x.Id
                                                                                        ,
                FirstName = x.FirstName
                                                                                        ,
                MiddleName = x.MiddleName
                                                                                        ,
                LastName = x.LastName
                                                                                        ,
                IsActive = x.IsActive
                                                                                        ,
                DateCreated = x.DateCreated
            }).ToList();
            return new ReturnObjectDTO() { data = employees, successMessage = "Process is successful." };
        }
        public async Task<ReturnObjectDTO> GetAllEmployeesAsync()
        {
            var employees = await repository.GetAllAsQueryable().Select(x => new EmployeeDTO()
            {
                Id = x.Id
                                                                                        ,
                FirstName = x.FirstName
                                                                                        ,
                MiddleName = x.MiddleName
                                                                                        ,
                LastName = x.LastName
                                                                                        ,
                IsActive = x.IsActive
                                                                                        ,
                DateCreated = x.DateCreated
            }).ToListAsync();
            return new ReturnObjectDTO() { data = employees, successMessage = "Process is successful." };
        }




        public ReturnObjectDTO AddEmployee(EmployeeDTO employee)
        {
            try
            {
                var entity = new Employee()
                {
                    FirstName = employee.FirstName,
                    MiddleName = employee.MiddleName,
                    LastName = employee.LastName,
                    IsActive = true,
                    DateCreated = DateTime.Now
                };

                repository.Add(entity);
                unitOfWork.Commit();

                employee.Id = entity.Id;
                return new ReturnObjectDTO() { data = employee, successMessage = "Process is successful." };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful." };
            }
        }

        public async Task<ReturnObjectDTO> AddEmployeeAsync(EmployeeDTO employee)
        {
            try
            {
                var entity = new Employee()
                {
                    FirstName = employee.FirstName,
                    MiddleName = employee.MiddleName,
                    LastName = employee.LastName,
                    IsActive = true,
                    DateCreated = DateTime.Now
                };

                await repository.AddAsync(entity);
                await unitOfWork.CommitAsync();

                employee.Id = entity.Id;
                return new ReturnObjectDTO() { data = employee, successMessage = "Process is successful." };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful." };
            }
        }


        public ReturnObjectDTO UpdateEmployee(int id, EmployeeDTO employee, string updatedBy = "")
        {
            if (id != employee.Id)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful. No Record Information to be Updated." };
            }

            var entity = repository.GetById(id);
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful. No Record Information to be Updated.(2)" };
            }

            entity.FirstName = employee.FirstName;
            entity.MiddleName = employee.MiddleName;
            entity.LastName = employee.LastName;

            try
            {
                repository.Update(entity);
                unitOfWork.Commit();
                return new ReturnObjectDTO() { data = employee, successMessage = "Process is successful." };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful." };
            }
        }
        public async Task<ReturnObjectDTO> UpdateEmployeeAsync(int id, EmployeeDTO employee, string updatedBy = "")
        {
            if (id != employee.Id)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful. No Record Information to be Updated." };
            }

            var entity = await repository.GetByIdAsync(id); 
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful. No Record Information to be Updated.(2)" };
            }

            entity.FirstName = employee.FirstName;
            entity.MiddleName = employee.MiddleName;
            entity.LastName = employee.LastName;

            try
            {
                repository.Update(entity);
                await unitOfWork.CommitAsync();
                return new ReturnObjectDTO() { data = employee, successMessage = "Process is successful." };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful." };
            }
        }

        public ReturnObjectDTO SoftDeleteEmployee(int id, EmployeeDTO employee, string updatedBy = "")
        {
            if (id != employee.Id)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful. No Record Information to be Deleted." };
            }

            var entity = repository.GetById(id); 
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful. No Record Information to be Deleted.(2)" };
            }

            entity.IsActive = false;

            try
            {
                repository.Update(entity);
                unitOfWork.Commit();

                /*employee.FirstName = entity.FirstName;
                employee.MiddleName = entity.MiddleName;
                employee.LastName = entity.LastName;
                employee.IsActive = entity.IsActive;*/

                return new ReturnObjectDTO() { /*data = employee,*/ successMessage = "Process is successful." };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful." };
            }
        }
        public async Task<ReturnObjectDTO> SoftDeleteEmployeeAsync(int id, EmployeeDTO employee, string updatedBy = "")
        {
            if (id != employee.Id)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful. No Record Information to be Deleted." };
            }

            var entity = await repository.GetByIdAsync(id); 
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful. No Record Information to be Deleted.(2)" };
            }

            entity.IsActive = false;

            try
            {
                repository.Update(entity);
                await unitOfWork.CommitAsync();

                /*employee.FirstName = entity.FirstName;
                employee.MiddleName = entity.MiddleName;
                employee.LastName = entity.LastName;
                employee.IsActive = entity.IsActive;*/

                return new ReturnObjectDTO() { /*data = employee,*/ successMessage = "Process is successful." };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful." };
            }
        }
        public ReturnObjectDTO HardDeleteEmployee(int id, string updatedBy = "")
        {
            var entity = repository.GetById(id);
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful. No Record Information to be Deleted.(3)" };
            }
            try
            {
                repository.Delete(entity);
                unitOfWork.Commit();
                return new ReturnObjectDTO() { successMessage = "Process is successful." };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful." };
            }

        }

        public async Task<ReturnObjectDTO> HardDeleteEmployeeAsync(int id, string updatedBy = "")
        {
            var entity = await repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful. No Record Information to be Deleted.(3)" };
            }
            try
            {
                repository.Delete(entity);
                await unitOfWork.CommitAsync();
                return new ReturnObjectDTO() { successMessage = "Process is successful." };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "Process is NOT successful." };
            }

        }

    }
}
