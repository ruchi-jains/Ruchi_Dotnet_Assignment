using demo_dependency_injection.CosmosDB;
using demo_dependency_injection.Entities;
using demo_dependency_injection.Interface;
using demo_dependency_injection.DTO;

namespace demo_dependency_injection.Services
{
    public class DemoService : IDemoService
    {
        public readonly ICosmosDBService _cosmosDBService;

        public DemoService(ICosmosDBService cosmosDBservice)
        {
            _cosmosDBService = cosmosDBservice;
        }
        public async Task<DemoDTO> Adddemo(DemoDTO demodto)
        { 
            DemoEntity demo = new DemoEntity();
            demo.Id = Guid.NewGuid().ToString();
            demo.UId = demodto.Id;
            demo.RollNo = demodto.RollNo;
            demo.Email = demodto.Email;
            return demo;
        }

    }
}

