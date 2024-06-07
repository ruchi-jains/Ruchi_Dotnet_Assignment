using demo_dependency_injection.DTO;

namespace demo_dependency_injection.Interface
{
    public interface IDemoService
    {
        Task<DemoDTO> Adddemo(DemoDTO demodto);
    }
}
