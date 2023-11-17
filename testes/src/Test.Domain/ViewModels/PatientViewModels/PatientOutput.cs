using Test.Domain.ViewModels.Base;

namespace Test.Domain.ViewModels.PatientViewModels;

public class PatientOutput : OutputDto
{
    public string Nome { get; set; }
    public DateTime Data { get; set; }
}