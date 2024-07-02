
using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Serialization.HybridRow.Schemas;
using Ruchi_Employee_management_system.Common;
using Ruchi_Employee_management_system.Entity;

using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Ruchi_Employee_management_system.CosmosDB
{
    public class CosmosDBService : ICosmosDBService
        {
            public CosmosClient _cosmosClient;
            private readonly Container _container;
        

        public CosmosDBService(IConfiguration configuration)
            {
                _cosmosClient = new CosmosClient(Credentials.CosmosEndpoint, Credentials.PrimaryKey);
                _container = _cosmosClient.GetContainer(Credentials.databaseName, Credentials.containerName);
            
        }
            public async Task<EmployeeBasicDetailsEntity> AddEmployee(EmployeeBasicDetailsEntity employeebasic)
            {
                var response = await _container.CreateItemAsync(employeebasic);
                return employeebasic;
            }

        public async Task<EmployeeAdditionalDetailsEntity> AddAdditionalDetails(EmployeeAdditionalDetailsEntity employeeAdditional)
        {
            var response = await _container.CreateItemAsync(employeeAdditional);
            return employeeAdditional;
        }


        public async Task<List<EmployeeBasicDetailsEntity>> GetAllEmployeeList()
        {
            var response = _container.GetItemLinqQueryable<EmployeeBasicDetailsEntity>(true).Where(q => q.Active == true && q.Archived == false && q.DocumentType == "management").ToList();
            return response;
        }

        public async Task<List<EmployeeAdditionalDetailsEntity>> GetAllAdditionalDetailsList()
        {
            var response = _container.GetItemLinqQueryable<EmployeeAdditionalDetailsEntity>(true).Where(q => q.Active == true && q.Archived == false && q.DocumentType == "management").ToList();
            return response;
        }
        public async Task<EmployeeBasicDetailsEntity> GetEmployeeByUId(string uId)
        {
            var response = _container.GetItemLinqQueryable<EmployeeBasicDetailsEntity>(true).Where(q => q.UId == uId).FirstOrDefault();
            return response;
        }

        public async Task<EmployeeAdditionalDetailsEntity> GetAdditionalByUId(string uId)
        {
            var response = _container.GetItemLinqQueryable<EmployeeAdditionalDetailsEntity>(true).Where(q => q.EmployeeBasicDetailsUId == uId).FirstOrDefault();
            return response;
        }

        public async Task UpsertItem(EmployeeBasicDetailsEntity item)
        {
            await _container.UpsertItemAsync(item);
            
        }

        public async Task DeleteEmployee(string Id)
        {
            await _container.DeleteItemAsync<EmployeeBasicDetailsEntity>(Id, new Microsoft.Azure.Cosmos.PartitionKey(Id));
        }

        public async Task<EmployeeAdditionalDetailsEntity> UpdateItem(EmployeeAdditionalDetailsEntity employeeAdditionalDetailsEntity)
        {
            var response = await _container.UpsertItemAsync(employeeAdditionalDetailsEntity);
            return response;
        }

    }
    }
