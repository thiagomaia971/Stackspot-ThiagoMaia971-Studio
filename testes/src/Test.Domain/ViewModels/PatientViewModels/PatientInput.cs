using Test.Domain.ViewModels.Base;

namespace Test.Domain.ViewModels.PatientViewModels;

public class PatientInput : InputDto
{
    public PatientInput()
    {
        Id = Guid.NewGuid().ToString();
    }

}