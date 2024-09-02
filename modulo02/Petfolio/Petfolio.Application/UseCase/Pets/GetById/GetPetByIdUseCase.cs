using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCase.Pets.GetById;
public class GetPetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        return new ResponsePetJson
        {
            Id = id,
            Name = "Maria",
            Type = Communication.Enums.PetType.Cat,
            Birthday = new DateTime(year: 2020, month: 03, day: 02)
        };
    }
}
