
using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Serialization.HybridRow.Schemas;
using Ruchi_Employee_system.Common;
using Ruchi_Employee_system.Entity;


namespace Ruchi_Employee_system.CosmosDB
{
    public class CosmosDBService : ICosmosDBService
        {
            public CosmosClient _cosmosClient;
            private readonly Container _container;

            public CosmosDBService()
            {
                _cosmosClient = new CosmosClient(Credentials.CosmosEndpoint, Credentials.PrimaryKey);
                _container = _cosmosClient.GetContainer(Credentials.databaseName, Credentials.containerName);
            }
            public async Task<EmployeeBasicDetailsEntity> AddEmployee(EmployeeBasicDetailsEntity employeebasic)
            {
                var response = await _container.CreateItemAsync(employeebasic);
                return employeebasic;
            }
     

        public async Task<List<EmployeeBasicDetailsEntity>> GetAllEmployeeList()
        {
            var response = _container.GetItemLinqQueryable<EmployeeBasicDetailsEntity>(true).Where(q => q.Active == true && q.Archived == false && q.DocumentType == "management").ToList();
            return response;
        }

        public async Task<List<EmployeeBasicDetailsEntity>> GetAllEmployeeByRole(string role)
        {
            var response = _container.GetItemLinqQueryable<EmployeeBasicDetailsEntity>(true).Where(q => q.Role == role).ToList();
            return response;
        }
   
        public async Task<EmployeeBasicDetailsEntity> GetEmployeeByUId(string uId)
        {
            var response = _container.GetItemLinqQueryable<EmployeeBasicDetailsEntity>(true).Where(q => q.UId == uId).FirstOrDefault();
            return response;
        }

  
        public async Task ReplaceAsync(EmployeeBasicDetailsEntity employeebasic)
        {
            var response = await _container.ReplaceItemAsync(employeebasic,employeebasic.DocumentType);

        }

    }
    }
